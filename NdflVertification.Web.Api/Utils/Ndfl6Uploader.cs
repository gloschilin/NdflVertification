using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Six;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{

    public class Ndfl61Uploader : BaseConcreteFileUploader<Файл>
    {
        public Ndfl61Uploader(Ndfl61ReportFactory reportFactory, IReportValidator<Файл> validator) 
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.SixNdfl1;
        protected override string FileName => "ndfl61.file";
    }

    public class Ndfl62Uploader : BaseConcreteFileUploader<Файл>
    {
        public Ndfl62Uploader(Ndfl62ReportFactory reportFactory, IReportValidator<Файл> validator)
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.SixNdfl2;
        protected override string FileName => "ndfl62.file";
    }

    public class Ndfl63Uploader : BaseConcreteFileUploader<Файл>
    {
        public Ndfl63Uploader(Ndfl63ReportFactory reportFactory, IReportValidator<Файл> validator)
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.SixNdfl3;
        protected override string FileName => "ndfl63.file";
    }

    public class Ndfl64Uploader : BaseConcreteFileUploader<Файл>
    {
        public Ndfl64Uploader(Ndfl64ReportFactory reportFactory, IReportValidator<Файл> validator)
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.SixNdfl4;
        protected override string FileName => "ndfl64.file";
    }
}