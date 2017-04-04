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
            for (var i = 0; i < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Length; i++)
            {
                if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС.НачислСВНеПрев.Сум1Посл3М !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.СвВыпл.СвВыплМК.Where(c =>
                            c.Месяц.ToInt() == 1).Sum(s => s.НачислСВ))
                {
                    return false;
                }

                if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС.НачислСВНеПрев.Сум2Посл3М !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.СвВыпл.СвВыплМК.Where(c =>
                            c.Месяц.ToInt() == 2).Sum(s => s.НачислСВ))
                {
                    return false;
                }

                if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС.НачислСВНеПрев.Сум3Посл3М !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.СвВыпл.СвВыплМК.Where(c =>
                            c.Месяц.ToInt() == 3).Sum(s => s.НачислСВ))
                {
                    return false;
                }

                if (
                    entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС428.РасчСВ_42812.Sum(s =>
                            s.НачислСВДоп.Сум1Посл3М) +
                    entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС428.РасчСВ_4283.Sum(s =>
                            s.НачислСВДоп.Сум1Посл3М)
                    !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(c =>
                            c.Месяц.ToInt() == 1).Sum(s => s.НачислСВ))
                {
                    return false;
                }

                if (
                    entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС428.РасчСВ_42812.Sum(s =>
                            s.НачислСВДоп.Сум2Посл3М) +
                    entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС428.РасчСВ_4283.Sum(s =>
                            s.НачислСВДоп.Сум2Посл3М)
                    !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(c =>
                            c.Месяц.ToInt() == 2).Sum(s => s.НачислСВ))
                {
                    return false;
                }

                if (
                    entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС428.РасчСВ_42812.Sum(s =>
                            s.НачислСВДоп.Сум3Посл3М) +
                    entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС428.РасчСВ_4283.Sum(s =>
                            s.НачислСВДоп.Сум3Посл3М)
                    !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(c =>
                            c.Месяц.ToInt() == 3).Sum(s => s.НачислСВ))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
