﻿using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv167Validator : BaseReportStepValidator<Файл>
    {
        public Sv167Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv167Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            foreach (
                var файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс in entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС)
            {
                if (файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.БазНачислСВ.Сум1Посл3М !=
                    файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.ВыплНачислФЛ.Сум1Посл3М
                    - файлДокументРасчетСвОбязПлатСвРасчСвОпсОмс.РасчСВ_ОПС.НеОбложенСВ.Сум1Посл3М)
                {
                    return false;
                }
            }
            return true;
        }
    }
}