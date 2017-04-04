using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using NdflVerification.ReportsContext.Domain;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.NdflValidators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.SixNdflValidators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.TwoNdflValidators;

namespace NdflVerification.ReportsContext
{
    public static class IocInstaller
    {
        private static void IntallEsss(IUnityContainer container)
        {
            var mscorlib = typeof(BaseReportStepValidator<Файл>).Assembly;
            var types =
                mscorlib.GetTypes()
                    .Where(e => typeof (BaseReportStepValidator<Файл>).IsAssignableFrom(e) && !e.IsAbstract)
                    .ToList();
            foreach (var type in types)
            {
                container.RegisterType(typeof (IReportStepValidator<Файл>), type, type.FullName);
            }
        }

        public static void Install(IUnityContainer container)
        {
            IntallEsss(container);

            container.RegisterType(typeof (IReportFactory<>), typeof (ReportFactory<>), new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlReportBuilder<SixNdfl>, NdflSixXsdReportBuilder>(new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlReportBuilder<TwoNdfl>, NdflTwoXsdReportBuilder>(new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlReportBuilder<Файл>, XmlEsssBuilder>(new ContainerControlledLifetimeManager());

            container.RegisterType(typeof (IReportValidator<>), typeof (ReportValidator<>), new ContainerControlledLifetimeManager());

            container.RegisterType(typeof (IEnumerable<IReportStepValidator<SixNdfl>>), typeof (IReportStepValidator<SixNdfl>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<TwoNdfl>>), typeof(IReportStepValidator<TwoNdfl>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<Reports>>), typeof(IReportStepValidator<Reports>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<Файл>>), typeof(IReportStepValidator<Файл>[]), new ContainerControlledLifetimeManager());

            container.RegisterType<IReportStepValidator<Reports>, ReportsInnAndKppStepValidator>("ReportsInnAndKppStepValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<Reports>, ReportsYearValidator>("ReportsYearValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<Reports>, ReportTotalEmployeeCountValidator>("ReportTotalEmployeeCountValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<Reports>, ReportTotalSumDividendsValidator>("ReportTotalSumDividendsValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<Reports>, ReportTotalSumNotHoldTaxesValidator>("ReportTotalSumNotHoldTaxesValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<Reports>, ReportTotalSumTaxesValidator>("ReportTotalSumTaxesValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<Reports>, ReportTotalSumValidator>("ReportTotalSumValidator", new ContainerControlledLifetimeManager());

            container.RegisterType<IReportStepValidator<SixNdfl>, SixNdflPeriodStepValidator>("SixNdflPeriodStepValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<SixNdfl>, SixNdflRateStepValidator>("SixNdflRateStepValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<SixNdfl>, SixNdflFormStepValidator>("SixNdflFormStepValidator", new ContainerControlledLifetimeManager());

            container.RegisterType<IReportStepValidator<TwoNdfl>, TwoNdflFormStepValidator>("TwoNdflFormStepValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<TwoNdfl>, TwoNdflRateStepValidator>("TwoNdflRateStepValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<TwoNdfl>, TwoNdflSignStepValidator>("TwoNdflSignStepValidator", new ContainerControlledLifetimeManager());
            container.RegisterType<IReportStepValidator<TwoNdfl>, TwoNdflYearValidator>("TwoNdflYearValidator", new ContainerControlledLifetimeManager());
        }
    }
}
