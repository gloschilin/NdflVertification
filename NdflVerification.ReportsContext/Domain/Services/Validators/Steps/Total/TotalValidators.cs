using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total26Validator : BaseReportStepValidator<Reports>
    {
        public Total26Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total26Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return entity.Esss.Документ.Период == entity.Ndfl6.Документ.Период
                   && entity.Esss.Документ.ОтчетГод == entity.Ndfl6.Документ.ОтчетГод;
        }
    }

    public class Total25Validator : BaseReportStepValidator<Reports>
    {
        public Total25Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total25Validator;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            var ndflFl = entity.Ndfl6.Документ.СвНП.Item as ФайлДокументСвНПНПФЛ;
            var ndflUl = entity.Ndfl6.Документ.СвНП.Item as ФайлДокументСвНПНПЮЛ;

            var esssFl =
                entity.Esss.Документ.СвНП.Item as Factories.XsdImplement.Esss.ФайлДокументСвНПНПФЛ;
            var esssUl =
                entity.Esss.Документ.СвНП.Item as Factories.XsdImplement.Esss.ФайлДокументСвНПНПЮЛ;

            return Compare(ndflUl, esssUl);
        }

        private static bool Compare(ФайлДокументСвНПНПФЛ ndfl, Factories.XsdImplement.Esss.ФайлДокументСвНПНПФЛ esss)
        {
            if (ndfl == null && esss == null)
            {
                return true;
            }

            if (ndfl == null || esss == null)
            {
                return false;
            }

            return true;
        }

        private static bool Compare(ФайлДокументСвНПНПЮЛ ndfl, Factories.XsdImplement.Esss.ФайлДокументСвНПНПЮЛ esss)
        {
            if (ndfl == null && esss == null)
            {
                return true;
            }

            if (ndfl == null || esss == null)
            {
                return false;
            }

            return ndfl.ИННЮЛ == esss.ИННЮЛ;
        }
    }

    public class Total24Validator : BaseReportStepValidator<Reports>
    {
        public Total24Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total24Validator;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return (entity.Esss.Документ.КНД == "1151099" || entity.Ndfl6.Документ.КНД == "1151099");
        }
    }

    public class Total23Validator : BaseReportStepValidator<Reports>
    {
        public Total23Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total23Validator;

        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return (entity.Esss.Документ.КНД == "1151111" || entity.Ndfl6.Документ.КНД == "1151111");
        }
    }

    public class Total22Validator : BaseReportStepValidator<Reports>
    {
        public Total22Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total22Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Esss == null || entity.Ndfl6 == null)
            {
                return true;
            }

            return entity.Ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Sum(e => e.НачислДох)
                   - entity.Ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.Sum(e => e.НачислДохДив)
                   ==
                   entity.Esss.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Sum(
                       e => e.РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер);
        }
    }

    public class Total21Validator : BaseReportStepValidator<Reports>
    {
        public Total21Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Total21Validator;
        public override bool IsSpecificatiedBy(Reports entity)
        {
            if (entity.Ndfl6 != null && entity.Esss == null)
            {
                return false;
            }

            return true;
        }
    }
}
