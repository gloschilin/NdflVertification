﻿using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
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
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПер !=
                    0
                    + файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.НеОбложенСВ.СумВсегоПосл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }
}