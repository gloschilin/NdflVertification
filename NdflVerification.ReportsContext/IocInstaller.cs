using System.Collections.Generic;
using Microsoft.Practices.Unity;
using NdflVerification.ReportsContext.Domain;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps;

namespace NdflVerification.ReportsContext
{
    public static class IocInstaller
    {
        public static void Install(IUnityContainer container)
        {
            container.RegisterType(typeof (IReportFactory<>), typeof (ReportFactory<>), new ContainerControlledLifetimeManager());
            //container.RegisterType<IXmlReportBuilder<SixNdfl>, NdflSixXmlReportBuilder>(new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlReportBuilder<SixNdfl>, NdflSixXsdReportBuilder>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IXmlReportBuilder<TwoNdfl>, NdflTwoXmlReportBuilder>(new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlReportBuilder<TwoNdfl>, NdflTwoXsdReportBuilder>(new ContainerControlledLifetimeManager());

            container.RegisterType(typeof (IReportValidator<>), typeof (ReportValidator<>), new ContainerControlledLifetimeManager());

            container.RegisterType(typeof (IEnumerable<IReportStepValidator<SixNdfl>>), typeof (IReportStepValidator<SixNdfl>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<TwoNdfl>>), typeof(IReportStepValidator<TwoNdfl>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<Reports>>), typeof(IReportStepValidator<Reports>[]), new ContainerControlledLifetimeManager());

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
