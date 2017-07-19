using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using NdflVerification.ReportsContext.Domain;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps;

namespace NdflVerification.ReportsContext
{
    public static class IocInstaller
    {
        private static void IntallEsss(IUnityContainer container)
        {
            var mscorlib = typeof(BaseReportStepValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>).Assembly;
            var types =
                mscorlib.GetTypes()
                    .Where(e => typeof (BaseReportStepValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>).IsAssignableFrom(e) && !e.IsAbstract)
                    .ToList();
            foreach (var type in types)
            {
                container.RegisterType(typeof (IReportStepValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>), type, type.FullName);
            }
        }

        private static void IntallTotal(IUnityContainer container)
        {
            var mscorlib = typeof(BaseReportStepValidator<Reports>).Assembly;
            var types =
                mscorlib.GetTypes()
                    .Where(e => typeof(BaseReportStepValidator<Reports>).IsAssignableFrom(e) && !e.IsAbstract)
                    .ToList();
            foreach (var type in types)
            {
                container.RegisterType(typeof(IReportStepValidator<Reports>), type, type.FullName);
            }
        }

        public static void Install(IUnityContainer container)
        {
            IntallEsss(container);
            IntallTotal(container);

            container.RegisterType(typeof (IReportFactory<Domain.Services.Factories.XsdImplement.Esss.Файл>), typeof (Esss1ReprotFactory), "Esss1ReprotFactory", new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IReportFactory<Domain.Services.Factories.XsdImplement.Esss.Файл>), typeof(Esss2ReprotFactory), "Esss2ReprotFactory", new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IReportFactory<Domain.Services.Factories.XsdImplement.Esss.Файл>), typeof(Esss3ReprotFactory), "Esss3ReprotFactory", new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IReportFactory<Domain.Services.Factories.XsdImplement.Esss.Файл>), typeof(Esss4ReprotFactory), "Esss4ReprotFactory", new ContainerControlledLifetimeManager());
            container.RegisterType<IEnumerable<IReportFactory<Domain.Services.Factories.XsdImplement.Esss.Файл>>, IReportFactory<Domain.Services.Factories.XsdImplement.Esss.Файл>[]>(new ContainerControlledLifetimeManager());

            container.RegisterType(typeof(IReportFactory<Domain.Services.Factories.XsdImplement.Six.Файл>), typeof(Ndfl6ReprotFactory), new ContainerControlledLifetimeManager());

            container.RegisterType(typeof(IXmlReportBuilder<>), typeof(ReportBuilder<>), new ContainerControlledLifetimeManager());

            container.RegisterType<IReportValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>, ReportValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>>(new ContainerControlledLifetimeManager());
            container.RegisterType<IReportValidator<Domain.Services.Factories.XsdImplement.Six.Файл>, ReportValidator<Domain.Services.Factories.XsdImplement.Six.Файл>>(new ContainerControlledLifetimeManager());
            container.RegisterType<IReportValidator<Reports>, TotalReportValidator>(new ContainerControlledLifetimeManager());

            container.RegisterType(typeof(IEnumerable<IReportStepValidator<Reports>>), typeof(IReportStepValidator<Reports>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>>), typeof(IReportStepValidator<Domain.Services.Factories.XsdImplement.Esss.Файл>[]), new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IEnumerable<IReportStepValidator<Domain.Services.Factories.XsdImplement.Six.Файл>>), typeof(IReportStepValidator<Domain.Services.Factories.XsdImplement.Six.Файл>[]), new ContainerControlledLifetimeManager());


            container.RegisterType<IReportQuarterHelper<Domain.Services.Factories.XsdImplement.Esss.Файл>, EsssQuarterHelper>(new ContainerControlledLifetimeManager());
            container.RegisterType<IReportQuarterHelper<Domain.Services.Factories.XsdImplement.Six.Файл>, SixNdflQuarterHelper>(new ContainerControlledLifetimeManager());
            container.RegisterType<IReportQuarterHelper<Reports>, TotalReportsQuarterHelper>(new ContainerControlledLifetimeManager());


        }
    }
}
