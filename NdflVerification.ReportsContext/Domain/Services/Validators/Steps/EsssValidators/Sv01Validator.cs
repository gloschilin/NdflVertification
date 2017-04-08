using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv01Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// Общая сумма исчисленных СВ на ОПС за каждый месяц с базы, не превышающей предельной величины,
        ///  в целом по плательщику  сумме исчисленных СВ на ОПС за соответствующий месяц с базы,
        ///  не превышающей предельной величины, по каждому физическому лицу;
        ///  общая сумма исчисленных СВ на ОПС за каждый месяц по дополнительному тарифу в целом по плательщику 
        ///  сумме СВ на ОПС за каждый месяц по дополнительному тарифу по каждому физическому лицу
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv01Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv01Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            //foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            //{
            //    foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсРасчСвОпс428РасчСв42812 in файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС428.РасчСВ_42812)
            //    {
            //        файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсРасчСвОпс428РасчСв42812.НачислСВДоп.Сум3Посл3М
            //            + 
            //    }

            //    foreach (var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсРасчСвОпс428РасчСв42812 in файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС428.РасчСВ_4283)
            //    {
            //        файлДокументРасчетСвОбязПлатСвРасчСвОпсОмсРасчСвОпс428РасчСв42812.НачислСВДоп.Сум3Посл3М
            //            +
            //    }
            //}

            return true;
        }
    }
}
