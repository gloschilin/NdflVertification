using System.IO;
using System.Web;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{

    public class Ndfl6Uploader : BaseFileUploader<Файл>
    {
        public Ndfl6Uploader(IReportFactory<Файл> ndflReportFactory, IReportValidator<Файл> validator) 
            : base(ndflReportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.SixNdfl;
        protected override string FileName => "ndfl6.file";
    }
}