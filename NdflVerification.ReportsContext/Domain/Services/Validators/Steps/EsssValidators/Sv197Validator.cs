﻿using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
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
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолСтрахЛицВс.КолВсегоПер.ToInt() <
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОМС.КолЛицНачСВВс.КолВсегоПер.ToInt())
                {
                    return false;
                }
            }
            return true;
        }
    }
}