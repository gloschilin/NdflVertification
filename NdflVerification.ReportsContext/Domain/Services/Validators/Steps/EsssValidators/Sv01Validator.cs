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
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.SelectMany(e => e.РасчСВ_ОПС428?.РасчСВ_42812)
                .Sum(e => e.НачислСВДоп?.Сум3Посл3М);

            var sum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.SelectMany(e => e.РасчСВ_ОПС428?.РасчСВ_4283)
                .Sum(e => e.НачислСВДоп?.Сум3Посл3М);

            var sum3 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Where(e=> e.СвВыплСВОПС?.ВыплСВДоп !=null)
                .SelectMany(e => e.СвВыплСВОПС?.ВыплСВДоп?.ВыплСВДопМТ)
                .Where(e => e!=null && e.Месяц.ToInt() == 3).Sum(e => e?.НачислСВ);

            return sum1 + sum2 == sum3;
        }
    }

    public class Sv014Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// Общая сумма исчисленных СВ на ОПС за каждый месяц с базы, не превышающей предельной величины,
        ///  в целом по плательщику  сумме исчисленных СВ на ОПС за соответствующий месяц с базы,
        ///  не превышающей предельной величины, по каждому физическому лицу;
        ///  общая сумма исчисленных СВ на ОПС за каждый месяц по дополнительному тарифу в целом по плательщику 
        ///  сумме СВ на ОПС за каждый месяц по дополнительному тарифу по каждому физическому лицу
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv014Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv014Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.SelectMany(e => e.РасчСВ_ОПС428.РасчСВ_42812)
                .Sum(e => e.НачислСВДоп.Сум2Посл3М);
            
            var sum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.SelectMany(e => e.РасчСВ_ОПС428.РасчСВ_4283)
                .Sum(e => e.НачислСВДоп.Сум2Посл3М);

            var sum3 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Where(e=> e.СвВыплСВОПС.ВыплСВДоп !=null)
                .SelectMany(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ)
                .Where(e => e.Месяц.ToInt() == 2).Sum(e => e.НачислСВ);

            return sum1 + sum2 == sum3;
        }
    }

    public class Sv013Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// Общая сумма исчисленных СВ на ОПС за каждый месяц с базы, не превышающей предельной величины,
        ///  в целом по плательщику  сумме исчисленных СВ на ОПС за соответствующий месяц с базы,
        ///  не превышающей предельной величины, по каждому физическому лицу;
        ///  общая сумма исчисленных СВ на ОПС за каждый месяц по дополнительному тарифу в целом по плательщику 
        ///  сумме СВ на ОПС за каждый месяц по дополнительному тарифу по каждому физическому лицу
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv013Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv013Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум3Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК)
                .Where(e => e.Месяц.ToInt() == 3)
                .Sum(e => e.НачислСВ);

            return sum1 == sum2;
        }
    }

    public class Sv012Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// Общая сумма исчисленных СВ на ОПС за каждый месяц с базы, не превышающей предельной величины,
        ///  в целом по плательщику  сумме исчисленных СВ на ОПС за соответствующий месяц с базы,
        ///  не превышающей предельной величины, по каждому физическому лицу;
        ///  общая сумма исчисленных СВ на ОПС за каждый месяц по дополнительному тарифу в целом по плательщику 
        ///  сумме СВ на ОПС за каждый месяц по дополнительному тарифу по каждому физическому лицу
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv012Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv012Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум2Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК)
                .Where(e => e.Месяц.ToInt() == 2)
                .Sum(e => e.НачислСВ);

            return sum1 == sum2;
        }
    }

    public class Sv011Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// Общая сумма исчисленных СВ на ОПС за каждый месяц с базы, не превышающей предельной величины,
        ///  в целом по плательщику  сумме исчисленных СВ на ОПС за соответствующий месяц с базы,
        ///  не превышающей предельной величины, по каждому физическому лицу;
        ///  общая сумма исчисленных СВ на ОПС за каждый месяц по дополнительному тарифу в целом по плательщику 
        ///  сумме СВ на ОПС за каждый месяц по дополнительному тарифу по каждому физическому лицу
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv011Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv011Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум1Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК)
                .Where(e => e.Месяц.ToInt() == 1)
                .Sum(e => e.НачислСВ);
            
            return sum1 == sum2;
        }
    }

    public class Sv015Validator : BaseReportStepValidator<Файл>
    {
        public Sv015Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv015Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум3Посл3М)
                != entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(
                    e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(c => c.Месяц.ToInt() == 3).Sum(c => c.НачислСВ)))
            {
                return false;
            }

            return true;
        }
    }
}
