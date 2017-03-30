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
            @"C:\Users\Loschilin\Downloads\NO_NDFL2_7708_7708_7708710346770801001_20170329_fc1bfad1-b73b-43be-a2c5-688469cb8e75.xml";

        private const string PathToSixNdflFile =
            @"C:\Users\Loschilin\Downloads\NO_NDFL6_7708_7708_7708710346770801001_20170329_4d069f09-094e-4a22-8b99-3daf3273f27c.xml";

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
            System.Console.WriteLine($"{checkReportType} : {validationResultType}");
            //System.Console.WriteLine($"{_textDictionary[checkReportType.ToString()]} : {validationResultType}");
        }
    }
}
