using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.Total
{
    public class Total25Validator : BaseReportStepValidator<Reports>
    {
        public Total25Validator(IValidationResultHandler validationResultHandler, IReportQuarterHelper<Reports> reportQuarterHelper) : base(validationResultHandler, reportQuarterHelper)
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
}