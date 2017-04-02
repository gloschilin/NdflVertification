using System;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv1123Validator : BaseReportStepValidator<Файл>
    {
        public Sv1123Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1123Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПер,
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1122Validator : BaseReportStepValidator<Файл>
    {
        public Sv1122Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1122Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум3Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум3Посл3М
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1121Validator : BaseReportStepValidator<Файл>
    {
        public Sv1121Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1121Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум2Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум2Посл3М
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум2Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1120Validator : BaseReportStepValidator<Файл>
    {
        public Sv1120Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1120Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум1Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум1Посл3М
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум1Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1119Validator : BaseReportStepValidator<Файл>
    {
        public Sv1119Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1119Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1118Validator : BaseReportStepValidator<Файл>
    {
        public Sv1118Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1118Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПер))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1117Validator : BaseReportStepValidator<Файл>
    {
        public Sv1117Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1117Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПосл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1116Validator : BaseReportStepValidator<Файл>
    {
        public Sv1116Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1116Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПер <=
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПосл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1115Validator : BaseReportStepValidator<Файл>
    {
        public Sv1115Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1115Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум3Посл3М
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум3Посл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1114Validator : BaseReportStepValidator<Файл>
    {
        public Sv1114Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1114Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум2Посл3М
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум2Посл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1113Validator : BaseReportStepValidator<Файл>
    {
        public Sv1113Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1113Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум1Посл3М
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум1Посл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1112Validator : BaseReportStepValidator<Файл>
    {
        public Sv1112Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1112Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПосл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1111Validator : BaseReportStepValidator<Файл>
    {
        public Sv1111Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1111Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер 
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.СумВсегоПер)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1110Validator : BaseReportStepValidator<Файл>
    {
        public Sv1110Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1110Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1109Validator : BaseReportStepValidator<Файл>
    {
        public Sv1109Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1109Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер,
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1108Validator : BaseReportStepValidator<Файл>
    {
        public Sv1108Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1108Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.Кол3Посл3М.ToInt() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум3Посл3М <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1107Validator : BaseReportStepValidator<Файл>
    {
        public Sv1107Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1107Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.Кол2Посл3М.ToInt() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум2Посл3М <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1106Validator : BaseReportStepValidator<Файл>
    {
        public Sv1106Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1106Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.Кол1Посл3М.ToInt() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум1Посл3М <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1105Validator : BaseReportStepValidator<Файл>
    {
        public Sv1105Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1105Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПосл3М.ToInt() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПосл3М <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1104Validator : BaseReportStepValidator<Файл>
    {
        public Sv1104Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1104Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПер.ToInt() > 0
                    && файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1103Validator : BaseReportStepValidator<Файл>
    {
        public Sv1103Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1103Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            throw new NotImplementedException();
        }
    }

    public class Sv1102Validator : BaseReportStepValidator<Файл>
    {
        public Sv1102Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1102Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПосл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.Кол3Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1101Validator : BaseReportStepValidator<Файл>
    {
        public Sv1101Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1101Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПосл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.Кол2Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv1100Validator : BaseReportStepValidator<Файл>
    {
        public Sv1100Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv1100Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПосл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.Кол1Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv199Validator : BaseReportStepValidator<Файл>
    {
        public Sv199Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv199Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПосл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv198Validator : BaseReportStepValidator<Файл>
    {
        public Sv198Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv198Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            throw  new NotImplementedException();
        }
    }

    public class Sv197Validator : BaseReportStepValidator<Файл>
    {
        public Sv197Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv197Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПер.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv196Validator : BaseReportStepValidator<Файл>
    {
        public Sv196Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv196Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.Кол2Посл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.Кол2Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv195Validator : BaseReportStepValidator<Файл>
    {
        public Sv195Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv195Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.Кол1Посл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.Кол1Посл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv194Validator : BaseReportStepValidator<Файл>
    {
        public Sv194Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv194Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПосл3М.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПосл3М.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv193Validator : BaseReportStepValidator<Файл>
    {
        public Sv193Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv193Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолСтрахЛицВс.КолВсегоПер.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.КолЛицНачСВВс.КолВсегоПер.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv192Validator : BaseReportStepValidator<Файл>
    {
        public Sv192Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv192Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.СумВсегоПосл3М,
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv191Validator : BaseReportStepValidator<Файл>
    {
        public Sv191Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv191Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.СумВсегоПер,
                    + 0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv19Validator : BaseReportStepValidator<Файл>
    {
        public Sv19Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv19Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПосл3М,
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv189Validator : BaseReportStepValidator<Файл>
    {
        public Sv189Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv189Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПер,
                    + 0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv188Validator : BaseReportStepValidator<Файл>
    {
        public Sv188Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv188Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПосл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv187Validator : BaseReportStepValidator<Файл>
    {
        public Sv187Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv187Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПер,
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv186Validator : BaseReportStepValidator<Файл>
    {
        public Sv186Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv186Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум3Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.Сум3Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv185Validator : BaseReportStepValidator<Файл>
    {
        public Sv185Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv185Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум2Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.Сум2Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv184Validator : BaseReportStepValidator<Файл>
    {
        public Sv184Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv184Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.Сум1Посл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.Сум1Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv183Validator : BaseReportStepValidator<Файл>
    {
        public Sv183Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv183Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПосл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПосл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv182Validator : BaseReportStepValidator<Файл>
    {
        public Sv182Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv182Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВ.СумВсегоПер,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВНеПрев.СумВсегоПер
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НачислСВПрев.СумВсегоПер))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv178Validator : BaseReportStepValidator<Файл>
    {
        public Sv178Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv178Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум2Посл3М
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазПревышОПС.Сум2Посл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv179Validator : BaseReportStepValidator<Файл>
    {
        public Sv179Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv179Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум3Посл3М
                    < файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазПревышОПС.Сум3Посл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Sv18Validator : BaseReportStepValidator<Файл>
    {
        public Sv18Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv18Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПер,
                    0+ файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }


    public class Sv181Validator : BaseReportStepValidator<Файл>
    {
        public Sv181Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv181Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (!AllEquals(файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.СумВсегоПосл3М,
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум1Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум2Посл3М
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум3Посл3М))
                {
                    return false;
                }
            }
            return true;
        }
    }

}