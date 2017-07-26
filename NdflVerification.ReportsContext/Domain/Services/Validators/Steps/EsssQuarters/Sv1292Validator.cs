using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssQuarters
{
    public class Sv1308Validator : BaseReportStepValidator<EsssReports>
    {
        public Sv1308Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<EsssReports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1308Validator;
        public override bool IsSpecificatiedBy(EsssReports entity)
        {
            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Current.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                var previousItem = entity.Previous?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                    .FirstOrDefault(e=>e.ДанФЛПолуч.СНИЛС == файлДокументРасчетСвПерсСвСтрахЛиц.ДанФЛПолуч.СНИЛС);

                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.ВыплОПСВс3 +
                    (previousItem?.СвВыплСВОПС.СвВыпл.ВыплОПСВс3 ?? 0) > 876000)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Sv1307Validator : BaseReportStepValidator<Файл>
    {
        public Sv1307Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1307Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.ВыплСВДоп.НачислСВВс3
                    != файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ
                    .Where(e => e.Месяц.ToInt() == month || e.Месяц.ToInt() == month+1 || e.Месяц.ToInt() == month+2)
                    .Sum(e => e.НачислСВ))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Sv1306Validator : BaseReportStepValidator<Файл>
    {
        public Sv1306Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1306Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.ВыплСВДоп.ВыплСВВс3
                    != файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ
                    .Where(e => e.Месяц.ToInt() == month || e.Месяц.ToInt() == month+1 || e.Месяц.ToInt() == month+2)
                    .Sum(e=>e.ВыплСВ))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Sv1305Validator : BaseReportStepValidator<Файл>
    {
        public Sv1305Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1305Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);

            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.НачислСВВс3
                    != файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(e => e.Месяц.ToInt() == month
                    || e.Месяц.ToInt() == month+1 || e.Месяц.ToInt() == month+2).Sum(e => e.НачислСВ))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Sv1304Validator : BaseReportStepValidator<Файл>
    {
        public Sv1304Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1304Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.ВыплОПСДогВс3
                    != файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(e => e.Месяц.ToInt() == month
                    || e.Месяц.ToInt() == month+1 || e.Месяц.ToInt() == month+2).Sum(e => e.ВыплОПСДог))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Sv1303Validator : BaseReportStepValidator<Файл>
    {
        public Sv1303Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1303Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.ВыплОПСВс3
                    != файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(e => e.Месяц.ToInt() == month
                    || e.Месяц.ToInt() == month+1 || e.Месяц.ToInt() == month+2).Sum(e => e.ВыплОПС))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Sv1302Validator : BaseReportStepValidator<Файл>
    {
        public Sv1302Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1302Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            foreach (var файлДокументРасчетСвПерсСвСтрахЛиц in entity.Документ.РасчетСВ.ПерсСвСтрахЛиц)
            {
                if (файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.СумВыплВс3
                    != файлДокументРасчетСвПерсСвСтрахЛиц.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(e=>e.Месяц.ToInt() == month
                    || e.Месяц.ToInt() == month + 1 || e.Месяц.ToInt() == month + 2).Sum(e=>e.СумВыпл))
                {
                    return false;
                }
            }

            return true;
        }
    }


    public class Sv1300Validator : BaseReportStepValidator<Файл>
    {
        public Sv1300Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1300Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity) + 2;
            var sum1 =
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                    e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(c => c.ВыплНачислФЛ.Сум3Посл3М));

            var sum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                    e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(c => c.ВыплНачислФЛ.Сум3Посл3М));

            var sum3 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ)
                .Where(e => e.Месяц.ToInt() == month).Sum(e => e.ВыплСВ);

            return sum1 + sum2 == sum3;
        }
    }

    public class Sv1299Validator : BaseReportStepValidator<Файл>
    {
        public Sv1299Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1299Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity) + 1;

            var sum1 =
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                    e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(c => c.ВыплНачислФЛ.Сум2Посл3М));

            var sum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                    e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(c => c.ВыплНачислФЛ.Сум2Посл3М));

            var sum3 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ)
                .Where(e => e.Месяц.ToInt() == month).Sum(e => e.ВыплСВ);

            return sum1 + sum2 == sum3;
        }
    }

    public class Sv1298Validator : BaseReportStepValidator<Файл>
    {
        public Sv1298Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1298Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);

            var sum1 =
                entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                    e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(c => c.ВыплНачислФЛ.Сум1Посл3М));

            var sum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                    e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(c => c.ВыплНачислФЛ.Сум1Посл3М));

            var sum3 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ)
                .Where(e => e.Месяц.ToInt() == month).Sum(e => e.ВыплСВ);

            return sum1 + sum2 == sum3;
        }
    }


    public class Sv1297Validator : BaseReportStepValidator<Файл>
    {
        public Sv1297Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1297Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity) + 2;
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e =>
                e.РасчСВ_ОПС.БазНачислСВ.Сум3Посл3М - e.РасчСВ_ОПС.БазПревышОПС.Сум3Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(n => n.Месяц.ToInt() == month).Sum(n => n.ВыплОПС));
            return sum2 == sum1;
        }
    }

    public class Sv1296Validator : BaseReportStepValidator<Файл>
    {
        public Sv1296Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1296Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity) + 1;
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e =>
                e.РасчСВ_ОПС.БазНачислСВ.Сум2Посл3М - e.РасчСВ_ОПС.БазПревышОПС.Сум2Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(n => n.Месяц.ToInt() == month).Sum(n => n.ВыплОПС));
            return sum2 == sum1;
        }
    }


    public class Sv1295Validator : BaseReportStepValidator<Файл>
    {
        public Sv1295Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1295Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e =>
                e.РасчСВ_ОПС.БазНачислСВ.Сум1Посл3М - e.РасчСВ_ОПС.БазПревышОПС.Сум1Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(n => n.Месяц.ToInt() == month).Sum(n => n.ВыплОПС));
            return sum2 == sum1;
        }
    }


    public class Sv1294Validator : BaseReportStepValidator<Файл>
    {
        public Sv1294Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1294Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity) + 2;
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОМС.ВыплНачислФЛ.Сум3Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(n => n.Месяц.ToInt() == month).Sum(n => n.СумВыпл));
            return sum1 == sum2;
        }
    }

    public class Sv1293Validator : BaseReportStepValidator<Файл>
    {
        public Sv1293Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1293Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОМС.ВыплНачислФЛ.Сум2Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(n => n.Месяц.ToInt() == month+1).Sum(n => n.СумВыпл));
            return sum1 == sum2;
        }
    }


    public class Sv1292Validator : BaseReportStepValidator<Файл>
    {
        public Sv1292Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1292Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var month = GetQuarterStartMonth(entity);
            var sum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e => e.РасчСВ_ОМС.ВыплНачислФЛ.Сум1Посл3М);
            var sum2 = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e=>e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(n=>n.Месяц.ToInt() == month).Sum(n=>n.СумВыпл));
            return sum1 == sum2;
        }
    }
}