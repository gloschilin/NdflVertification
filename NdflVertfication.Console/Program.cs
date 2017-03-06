using Microsoft.Practices.Unity;
using NdflVerification.ReportsContext;
using NdflVerification.ReportsContext.Domain;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.Texts;

namespace NdflVertfication.Console
{
    class Program
    {
        private static readonly IUnityContainer Container;

        static Program()
        {
            Container = new UnityContainer();
            Container.RegisterType<IValidationResultHandler, WriteToConsoleExceptionHanlder>(new ContainerControlledLifetimeManager());
            IocInstaller.Install(Container);
            TextsInstaller.Install(Container);
        }
        private const string PathToTwoNdflFile =
            @"C:\Users\Loschilin\Downloads\NO_NDFL2_7708_7708_7708710346770801001_20170302_464f46b7-aac4-407c-b197-dccb1e05a8be.xml";

        private const string PathToSixNdflFile =
            @"C:\Users\Loschilin\Downloads\NO_NDFL6_7708_7708_7708710346770801001_20170302_285f7da1-d07c-4454-b189-b997123a040b.xml";

        static void Main(string[] args)
        {
            var reportTwoFactory = Container.Resolve<IReportFactory<TwoNdfl>>();
            var reportTwo = reportTwoFactory.ReadFromLocalFile(PathToTwoNdflFile);

            var reportSixFactory = Container.Resolve<IReportFactory<SixNdfl>>();
            var reportSix = reportSixFactory.ReadFromLocalFile(PathToSixNdflFile);

            var sixValidator = Container.Resolve<IReportValidator<SixNdfl>>();
            var twoValidator = Container.Resolve<IReportValidator<TwoNdfl>>();
            var totalValidator = Container.Resolve<IReportValidator<Reports>>();

            sixValidator.Validate(reportSix);
            twoValidator.Validate(reportTwo);
            totalValidator.Validate(new Reports(reportSix, reportTwo));

            System.Console.ReadLine();

        }
        
    }

    public class WriteToConsoleExceptionHanlder: IValidationResultHandler
    {
        private readonly ITextDictionary _textDictionary;

        public WriteToConsoleExceptionHanlder(ITextDictionary textDictionary)
        {
            _textDictionary = textDictionary;
        }

        public void Handle(CheckReportType checkReportType, ValidationResultType validationResultType)
        {
            System.Console.WriteLine($"{_textDictionary[checkReportType.ToString()]} : {validationResultType}");
        }
    }
}
