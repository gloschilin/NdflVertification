using Microsoft.Practices.Unity;

namespace NdflVerification.Texts
{
    public static class TextsInstaller
    {
        public static void Install(IUnityContainer container)
        {
            container.RegisterType<ITextRepository, TextReporsitory>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITextDictionary, TextDictionary>(new PerResolveLifetimeManager());
        }
    }
}