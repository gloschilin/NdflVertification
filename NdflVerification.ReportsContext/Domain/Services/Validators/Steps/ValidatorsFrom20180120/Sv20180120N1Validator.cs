using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.ValidatorsFrom20180120
{
    /*
     * Docs
     * https://docs.google.com/spreadsheets/d/1Scty8gUqMALQsWVHTYp0Rezp13_Gb4xYww9u1Shls54/edit#gid=1326035220
     */

    public interface IEsssComplexValidator
    {

    }

    public class Sv20180120N1Validator: BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N1Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N1Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var lsum = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e =>
                e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПосл3М);

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.НачислСВ));

            return lsum == rsum;
        }
    }

    public class Sv20180120N2Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N2Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N2Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var lsum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e =>
                e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.НачислСВДоп.СумВсегоПосл3М));

            var lsum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(e =>
                e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.НачислСВДоп.СумВсегоПосл3М));

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.НачислСВ));

            return lsum1 + lsum2 == rsum;
        }
    }

    public class Sv20180120N3Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {

        public Sv20180120N3Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
     
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N3Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var quarter = _reportQuarterHelper.GetQuarter(entity);

            var lsum = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.Сум1Посл3М);

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(s => s.Месяц.ToInt() == quarter * 3 - 2).Sum(c => c.СумВыпл));

            return lsum == rsum;
        }
    }

    public class Sv20180120N4Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {

        public Sv20180120N4Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
            
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N4Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var quarter = _reportQuarterHelper.GetQuarter(entity);

            var lsum = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.Сум2Посл3М);

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(s => s.Месяц.ToInt() == quarter * 3 - 1).Sum(c=>c.СумВыпл));

            return lsum == rsum;
        }
    }

    public class Sv20180120N5Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {

        public Sv20180120N5Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
            
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N5Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var quarter = _reportQuarterHelper.GetQuarter(entity);

            var lsum = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.Сум3Посл3М);

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Where(s => s.Месяц.ToInt() == quarter * 3).Sum(c => c.СумВыпл));

            return lsum == rsum;
        }
    }

    public class Sv20180120N6Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N6Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N6Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var lsum = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М);

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.СумВыпл));

            return lsum == rsum;
        }
    }

    public class Sv20180120N7Validator : BaseReportStepValidator<AllEssReports>
    {
        public Sv20180120N7Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<AllEssReports> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N7Validator;

        public override bool IsSpecificatiedBy(AllEssReports entity)
        {
            var lsumQ1 = entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер) ?? 0;

            var lsumQ2 = entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер) ?? 0;

            var lsumQ3 = entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер) ?? 0;

            var lsumQ4 = entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер) ?? 0;

            //===

            var rsumQ1 = entity.Esss1?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.СумВыпл)) ?? 0;

            var rsumQ2 = entity.Esss2?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                             e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.СумВыпл)) ?? 0;

            var rsumQ3 = entity.Esss3?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                             e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.СумВыпл)) ?? 0;

            var rsumQ4 = entity.Esss4?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                             e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.СумВыпл)) ?? 0;

            return
                lsumQ1 == rsumQ1
                && (entity.Esss2 == null || lsumQ2 == rsumQ1 + rsumQ2)
                && (entity.Esss3 == null || lsumQ3 == rsumQ1 + rsumQ2 + rsumQ3)
                && (entity.Esss4 == null || lsumQ4 == rsumQ1 + rsumQ2 + rsumQ3 + rsumQ4);

        }
    }

    public class Sv20180120N8Validator : BaseReportStepValidator<AllEssReports>
    {
        public Sv20180120N8Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<AllEssReports> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N8Validator;

        public override bool IsSpecificatiedBy(AllEssReports entity)
        {
            var lsumQ1 = entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПер) ?? 0;

            var lsumQ2 = entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПер) ?? 0;

            var lsumQ3 = entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПер) ?? 0;

            var lsumQ4 = entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПер) ?? 0;

            //===

            var rsumQ1 = entity.Esss1?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.НачислСВ)) ?? 0;

            var rsumQ2 = entity.Esss2?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                             e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.НачислСВ)) ?? 0;

            var rsumQ3 = entity.Esss3?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                             e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.НачислСВ)) ?? 0;

            var rsumQ4 = entity.Esss4?.Документ.РасчетСВ.ПерсСвСтрахЛиц.Sum(e =>
                             e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(c => c.НачислСВ)) ?? 0;

            return
                lsumQ1 == rsumQ1
                && (entity.Esss2 == null || lsumQ2 == rsumQ1 + rsumQ2)
                && (entity.Esss3 == null || lsumQ3 == rsumQ1 + rsumQ2 + rsumQ3)
                && (entity.Esss4 == null || lsumQ4 == rsumQ1 + rsumQ2 + rsumQ3 + rsumQ4);

        }
    }

    public class Sv20180120N9Validator : BaseReportStepValidator<AllEssReports>
    {
        public Sv20180120N9Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<AllEssReports> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N9Validator;

        public override bool IsSpecificatiedBy(AllEssReports entity)
        {
            var lsumQ1 = entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                        .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s=>s.НачислСВДоп.СумВсегоПер)) ?? 0
                        + 
                        entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                            .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0;

            var lsumQ2 = entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0
                         +
                         entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0;

            var lsumQ3 = entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0
                         +
                         entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0;

            var lsumQ4 = entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0
                         +
                         entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.НачислСВДоп.СумВсегоПер)) ?? 0;

            //===

            var rsumQ1 = entity.Esss1?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.НачислСВ));

            var rsumQ2 = entity.Esss2?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.НачислСВ));

            var rsumQ3 = entity.Esss3?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.НачислСВ));

            var rsumQ4 = entity.Esss4?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.НачислСВ));

            return
                lsumQ1 == rsumQ1
                && (entity.Esss2 == null || lsumQ2 == rsumQ1 + rsumQ2)
                && (entity.Esss3 == null || lsumQ3 == rsumQ1 + rsumQ2 + rsumQ3)
                && (entity.Esss4 == null || lsumQ4 == rsumQ1 + rsumQ2 + rsumQ3 + rsumQ4);

        }
    }

    public class Sv20180120N10Validator : BaseReportStepValidator<AllEssReports>
    {
        public Sv20180120N10Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<AllEssReports> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N10Validator;

        public override bool IsSpecificatiedBy(AllEssReports entity)
        {
            var lsumQ1 = entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М) ?? 0
                         -
                         entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПосл3М) ?? 0;

            var lsumQ2 = entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М) ?? 0
                         -
                         entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПосл3М) ?? 0;

            var lsumQ3 = entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М) ?? 0
                         -
                         entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПосл3М) ?? 0;

            var lsumQ4 = entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М) ?? 0
                         -
                         entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПосл3М) ?? 0;

            //====

            var rsumQ1 = entity.Esss1?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС));

            var rsumQ2 = entity.Esss2?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС));

            var rsumQ3 = entity.Esss3?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС));

            var rsumQ4 = entity.Esss4?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС));

            return (entity.Esss1 == null || lsumQ1 == rsumQ1)
                   && (entity.Esss2 == null || lsumQ2 == rsumQ2)
                   && (entity.Esss3 == null || lsumQ3 == rsumQ3)
                   && (entity.Esss4 == null || lsumQ4 == rsumQ4);
        }
    }

    public class Sv20180120N11Validator : BaseReportStepValidator<AllEssReports>
    {
        public Sv20180120N11Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<AllEssReports> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N11Validator;

        public override bool IsSpecificatiedBy(AllEssReports entity)
        {
            var lsumQ1 = entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                        .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер) ?? 0
                        +
                        entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                            .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПер) ?? 0;

            var lsumQ2 = entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер) ?? 0
                         +
                         entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПер) ?? 0;
            
            var lsumQ3 = entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер) ?? 0
                         +
                         entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПер) ?? 0;

            var lsumQ4 = entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер) ?? 0
                         +
                         entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС.БазПревышОПС.СумВсегоПер) ?? 0;


            //===

            var rsumQ1 = entity.Esss1?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС)) ?? 0;

            var rsumQ2 = entity.Esss2?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС)) ?? 0;

            var rsumQ3 = entity.Esss3?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС)) ?? 0;

            var rsumQ4 = entity.Esss4?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК.Sum(s => s.ВыплОПС)) ?? 0;

            return
                lsumQ1 == rsumQ1
                && (entity.Esss2 == null || lsumQ2 == rsumQ1 + rsumQ2)
                && (entity.Esss3 == null || lsumQ3 == rsumQ1 + rsumQ2 + rsumQ3)
                && (entity.Esss4 == null || lsumQ4 == rsumQ1 + rsumQ2 + rsumQ3 + rsumQ4);

        }
    }

    public class Sv20180120N12Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {

        public Sv20180120N12Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N12Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {

            var quarter = _reportQuarterHelper.GetQuarter(entity);

            var lsum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.Сум1Посл3М));

            var lsum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.Сум1Посл3М));

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(s => s.Месяц.ToInt() == quarter * 3 -2).Sum(c => c.ВыплСВ));

            return lsum1 + lsum2 == rsum;
        }
    }

    public class Sv20180120N13Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N13Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N13Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var quarter = _reportQuarterHelper.GetQuarter(entity);

            var lsum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.Сум2Посл3М));

            var lsum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.Сум2Посл3М));

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(s => s.Месяц.ToInt() == quarter * 3 - 1)
                    .Sum(c => c.ВыплСВ));

            return lsum1 + lsum2 == rsum;
        }
    }

    public class Sv20180120N14Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N14Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N14Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var quarter = _reportQuarterHelper.GetQuarter(entity);

            var lsum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.Сум3Посл3М));

            var lsum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.Сум3Посл3М));

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(s => s.Месяц.ToInt() == quarter * 3)
                    .Sum(c => c.ВыплСВ));

            return lsum1 + lsum2 == rsum;
        }
    }

    public class Sv20180120N15Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N15Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N15Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var lsum1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.СумВсегоПосл3М));

            var lsum2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.СумВсегоПосл3М));

            var rsum = entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ
                    .Sum(c => c.ВыплСВ));

            return lsum1 + lsum2 == rsum;
        }
    }

    public class Sv20180120N16Validator : BaseReportStepValidator<AllEssReports>
    {
        public Sv20180120N16Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<AllEssReports> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N16Validator;

        public override bool IsSpecificatiedBy(AllEssReports entity)
        {
            var lsumQ1 = entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                    .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s=>s.БазНачислСВДоп.СумВсегоПер)) ?? 0
                    +
                    entity.Esss1?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                    .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0;

            var lsumQ2 = entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0
                         +
                         entity.Esss2?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0;

            var lsumQ3 = entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0
                         +
                         entity.Esss3?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0;

            var lsumQ4 = entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_42812.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0
                         +
                         entity.Esss4?.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                             .Sum(e => e.РасчСВ_ОПС428.РасчСВ_4283.Sum(s => s.БазНачислСВДоп.СумВсегоПер)) ?? 0;

            //====

            var rsumQ1 = entity.Esss1?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.ВыплСВ));

            var rsumQ2 = entity.Esss2?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.ВыплСВ));

            var rsumQ3 = entity.Esss3?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.ВыплСВ));

            var rsumQ4 = entity.Esss4?.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .Sum(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Sum(s => s.ВыплСВ));

            return
                lsumQ1 == rsumQ1
                && (entity.Esss2 == null || lsumQ2 == rsumQ1 + rsumQ2)
                && (entity.Esss3 == null || lsumQ3 == rsumQ1 + rsumQ2 + rsumQ3)
                && (entity.Esss4 == null || lsumQ4 == rsumQ1 + rsumQ2 + rsumQ3 + rsumQ4);

        }
    }

    public class Sv20180120N17Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N17Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N17Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.Select(e => e.ДанФЛПолуч.СНИЛС)
                .GroupBy(e => e).All(e => e.Count() == 1);
        }
    }

    public class Sv20180120N18Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N18Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N18Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var period = entity.Документ.Период;
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.All(e => e.Период == period);
        }
    }

    public class Sv20180120N19Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N19Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N19Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var period = entity.Документ.ОтчетГод;
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.All(e => e.ОтчетГод == period);
        }
    }

    public class Sv20180120N20Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N20Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N20Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.All(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.All(s => s.СумВыпл >= 0));
        }
    }

    public class Sv20180120N21Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N21Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N21Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.All(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.All(s => s.ВыплОПС >= 0));
        }
    }

    public class Sv20180120N22Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N22Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N22Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.All(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.All(s => s.ВыплОПСДог >= 0));
        }
    }

    public class Sv20180120N23Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N23Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N23Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц.All(e =>
                e.СвВыплСВОПС.СвВыпл.СвВыплМК.All(s => s.НачислСВ >= 0));
        }
    }

    public class Sv20180120N24Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N24Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N24Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .All(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.All(s => s.ВыплСВ >= 0));
        }
    }

    public class Sv20180120N25Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N25Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N25Validator;
        public override bool IsSpecificatiedBy(Файл entity)
        {
            return entity.Документ.РасчетСВ.ПерсСвСтрахЛиц
                .All(e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.All(s => s.НачислСВ >= 0));
        }
    }

    public class Sv20180120N27Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N27Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Файл> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N27Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var v1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПер >= 0);

            var v2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПосл3М >= 0);

            var v3 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум1Посл3М >= 0);

            var v4 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум2Посл3М >= 0);

            var v5 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС.НачислСВНеПрев.Сум3Посл3М >= 0);

            return v1 && v2 && v3 && v4 && v5;
        }
    }

    public class Sv20180120N28Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N28Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N28Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var v1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.БазНачислСВДоп.СумВсегоПер >= 0));

            var v2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.БазНачислСВДоп.СумВсегоПосл3М >= 0));

            var v3 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.БазНачислСВДоп.Сум1Посл3М >= 0));

            var v4 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.БазНачислСВДоп.Сум2Посл3М >= 0));

            var v5 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.БазНачислСВДоп.Сум3Посл3М >= 0));

            return v1 && v2 && v3 && v4 && v5;
        }
    }

    public class Sv20180120N29Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N29Validator(IValidationResultHandler validationResultHandler, 
            IReportQuarterHelper<Файл> reportQuarterHelper) 
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N29Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var v1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.НачислСВДоп.СумВсегоПер >= 0));

            var v2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.НачислСВДоп.СумВсегоПосл3М >= 0));

            var v3 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.НачислСВДоп.Сум1Посл3М >= 0));

            var v4 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.НачислСВДоп.Сум2Посл3М >= 0));

            var v5 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_42812.All(s => s.НачислСВДоп.Сум3Посл3М >= 0));

            return v1 && v2 && v3 && v4 && v5;
        }
    }

    public class Sv20180120N30Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N30Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N30Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var v1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.БазНачислСВДоп.СумВсегоПер >= 0));

            var v2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.БазНачислСВДоп.СумВсегоПосл3М >= 0));

            var v3 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.БазНачислСВДоп.Сум1Посл3М >= 0));

            var v4 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.БазНачислСВДоп.Сум2Посл3М >= 0));

            var v5 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.БазНачислСВДоп.Сум3Посл3М >= 0));

            return v1 && v2 && v3 && v4 && v5;
        }
    }

    public class Sv20180120N31Validator : BaseReportStepValidator<Файл>, IEsssComplexValidator
    {
        public Sv20180120N31Validator(IValidationResultHandler validationResultHandler,
            IReportQuarterHelper<Файл> reportQuarterHelper)
            : base(validationResultHandler, reportQuarterHelper)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv20180120N31Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            var v1 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.НачислСВДоп.СумВсегоПер >= 0));

            var v2 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.НачислСВДоп.СумВсегоПосл3М >= 0));

            var v3 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.НачислСВДоп.Сум1Посл3М >= 0));

            var v4 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.НачислСВДоп.Сум2Посл3М >= 0));

            var v5 = entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .All(e => e.РасчСВ_ОПС428.РасчСВ_4283.All(s => s.НачислСВДоп.Сум3Посл3М >= 0));

            return v1 && v2 && v3 && v4 && v5;
        }
    }
}
