using System;
using System.Linq;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVerification.ReportsContext.Domain.Services.Validators.Steps.EsssValidators
{
    public class Sv02Validator : BaseReportStepValidator<Файл>
    {
        /// <summary>
        /// недостоверные персональные данные: СНИЛС; Фамилия; Имя; Отчество.
        /// </summary>
        /// <param name="validationResultHandler"></param>
        public Sv02Validator(IValidationResultHandler validationResultHandler) : base(validationResultHandler)
        {
        }

        protected override CheckReportType CheckReportType => CheckReportType.Sv02Validator;

        public override bool IsSpecificatiedBy(Файл entity)
        {
            for (var i = 0; i < entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.Length; i++)
            {
                if (entity.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС[i].РасчСВ_ОПС.НачислСВНеПрев.Сум1Посл3М !=
                    entity.Документ.РасчетСВ.ПерсСвСтрахЛиц[i].СвВыплСВОПС.СвВыпл.СвВыплМК.Where(c => c.Месяц == "01")
                        .Sum(s => s.НачислСВ))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
