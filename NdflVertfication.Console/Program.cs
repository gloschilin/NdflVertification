using System;
using System.Linq;
using System.Reflection;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;

namespace NdflVertfication.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] typelist = GetTypesInNamespace(
                Assembly.GetAssembly(typeof(Файл)), 
                "NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss")
                .Where(e=>e.IsClass).ToArray();
            for (int i = 0; i < typelist.Length; i++)
            {
                System.Console.WriteLine(typelist[i].Name);
            }

            System.Console.ReadLine();
        }

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

    }

    
}
