using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{
    public class EsssUploader : BaseFileUploader<Файл>
    {
        public EsssUploader(IReportFactory<Файл> ndflReportFactory, IReportValidator<Файл> validator) 
            : base(ndflReportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.Esss;
        protected override string FileName => "esss.file";
    }
}