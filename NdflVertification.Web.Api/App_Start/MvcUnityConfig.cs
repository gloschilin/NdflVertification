using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using NdflVerification.ReportsContext;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.Texts;
using NdflVertification.Web.Api.Utils;

namespace NdflVertification.Web.Api.App_Start
{

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class MvcUnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            IocInstaller.Install(container);
            TextsInstaller.Install(container);
            container.RegisterType<IValidationResultHandler, WebValidationResultHandler>();

            container.RegisterType<IEnumerable<IConcreteFileUploader>, IConcreteFileUploader[]>();
            container.RegisterType<IConcreteFileUploader, Esss1Uploader>("Esss1Uploader");
            container.RegisterType<IConcreteFileUploader, Esss2Uploader>("Esss2Uploader");
            container.RegisterType<IConcreteFileUploader, Esss3Uploader>("Esss3Uploader");
            container.RegisterType<IConcreteFileUploader, Esss4Uploader>("Esss4Uploader");
            container.RegisterType<IConcreteFileUploader, Ndfl61Uploader>("Ndfl61Uploader");
            container.RegisterType<IConcreteFileUploader, Ndfl62Uploader>("Ndfl62Uploader");
            container.RegisterType<IConcreteFileUploader, Ndfl63Uploader>("Ndfl63Uploader");
            container.RegisterType<IConcreteFileUploader, Ndfl64Uploader>("Ndfl64Uploader");

            container.RegisterType<IFileUploader, FileUploader>(new ContainerControlledLifetimeManager());

            container.RegisterType<IReportInfoBuilder<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six.Файл>, NdflInfoBuilder>(new ContainerControlledLifetimeManager());
            container.RegisterType<IReportInfoBuilder<NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss.Файл>, EsssInfoBuilder>(new ContainerControlledLifetimeManager());

        }
    }
}
