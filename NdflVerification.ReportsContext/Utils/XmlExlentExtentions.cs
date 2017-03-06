using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;

namespace NdflVerification.ReportsContext.Utils
{
    /// <summary>
    /// Расширения для чтения данных из XML
    /// </summary>
    internal static class XmlExlentExtentions
    {
        /// <summary>
        /// Получение дочернего узла. В случае его отсутствия будет исключение.
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static XElement GetChildNode(this XElement xmlElement, string nodeName)
        {
            XElement result;
            if (!xmlElement.TryGetChildNode(nodeName, out result))
            {
                throw new Exception($"Не найден узел {nodeName}");
            }

            return result;
        }

        /// <summary>
        /// Получение дочернего узла
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <param name="nodeName"></param>
        /// <param name="childNode"></param>
        /// <returns></returns>
        public static bool TryGetChildNode(this XElement xmlElement, string nodeName, out XElement childNode)
        {
            childNode = xmlElement.Element(nodeName);
            return childNode != null;
        }

        /// <summary>
        /// Получение дочернего узла. В случае его отсутствия будет выдано исключение 
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static XElement GetChildNode(this XDocument xmlDocument, string nodeName)
        {
            XElement result;
            if (!xmlDocument.TryGetChildNode(nodeName, out result))
            {
                throw new Exception($"Не найден узел {nodeName}");
            }

            return result;
        }

        /// <summary>
        /// Получение дочернего узла
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="nodeName"></param>
        /// <param name="childNode"></param>
        /// <returns></returns>
        public static bool TryGetChildNode(this XDocument xmlDocument, string nodeName, out XElement childNode)
        {
            childNode = xmlDocument.Element(nodeName);
            return childNode != null;
        }

        /// <summary>
        /// Получение корневого узла по указанному имени. 
        /// В случае несовпадении имен или его отсутствия будет выдано исключение
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static XElement GetRootNode(this XDocument xmlDocument, string nodeName)
        {
            XElement xmlElement;
            if (!xmlDocument.TryGetRootNode(nodeName, out xmlElement))
            {
                throw new Exception($"Не найден корневой узел {nodeName}");
            }

            return xmlElement;
        }

        /// <summary>
        /// Получение корневого узла по его имени
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="nodeName"></param>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        public static bool TryGetRootNode(this XDocument xmlDocument, string nodeName, out XElement rootNode)
        {
            rootNode = xmlDocument.Root;

            if (rootNode!=null && rootNode.Name != nodeName)
            {
                rootNode = null;
            }

            return rootNode != null;
        }

        /// <summary>
        /// Получение значения атрибута элемента
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <param name="attributeName"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryGetAttributeValue(this XElement xmlElement, string attributeName, out string result)
        {
            var attribute = xmlElement.Attribute(attributeName);
            result = attribute?.Value;
            return attribute != null;
        }

        /// <summary>
        /// Получение значения атрибута элемента. В случае его отсутствия будет выдано исключение
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string GetAttributeValue(this XElement xmlElement, string attributeName)
        {
            string result;
            if (xmlElement.TryGetAttributeValue(attributeName, out result))
            {
                return result;
            }

            throw new Exception($"Не удалось найти атрибут {attributeName} элемента {xmlElement.Name}");
        }

        /// <summary>
        /// Получение значения атрибута элемента. В случае его отсутствия будет выдано исключение
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static T GetAttributeValue<T>(this XElement xmlElement, string attributeName)
        {
            string result;
            if (xmlElement.TryGetAttributeValue(attributeName, out result))
            {
                return ConvertValue<T>(result);
            }

            throw new Exception($"Не удалось найти атрибут {attributeName} элемента {xmlElement.Name}");
        }

        private static T ConvertValue<T>(object obj)
        {
            //CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";

            if (obj == null || obj == DBNull.Value)
                return default(T);
            if (obj.GetType() == typeof(T))
                return (T)obj;

            if (typeof(decimal) == typeof(T))
            {
                return (T)(object)decimal.Parse(obj.ToString(), new NumberFormatInfo() { NumberDecimalSeparator = "."});
            }

            var type = typeof(T);
            type = Nullable.GetUnderlyingType(type) ?? type; // шобы Nullable работала


            if (obj.GetType() == type)
                return (T)obj;
            
            return (T)TypeDescriptor.GetConverter(type).ConvertFrom(obj);

        }
    }
}