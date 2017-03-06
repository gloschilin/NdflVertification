﻿using System.IO;
using System.Xml.Linq;

namespace NdflVerification.ReportsContext.Domain.Services.Factories
{
    /// <summary>
    /// Фабрика получения отчетов
    /// </summary>
    /// <typeparam name="TReport"></typeparam>
    public interface IReportFactory<out TReport>
    {
        /// <summary>
        /// Получение отчета из потока
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        TReport ReadFromStream(Stream stream);

        /// <summary>
        /// Получение отчета из Xml документа
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        TReport ReadFromXml(XDocument xmlDocument);

        /// <summary>
        /// Чтение отчета из локального фала
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        TReport ReadFromLocalFile(string pathToFile);
    }
}
