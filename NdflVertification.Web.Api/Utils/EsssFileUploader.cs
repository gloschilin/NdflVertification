using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{
    public class Esss4Uploader : BaseConcreteFileUploader<Файл>
    {
        public Esss4Uploader(Esss4ReprotFactory reportFactory, IReportValidator<Файл> validator)
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.Esss4;
        protected override string FileName => "esss_4.file";
    }

    public class Esss3Uploader : BaseConcreteFileUploader<Файл>
    {
        public Esss3Uploader(Esss3ReprotFactory reportFactory, IReportValidator<Файл> validator)
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.Esss3;
        protected override string FileName => "esss_3.file";
    }

    public class Esss2Uploader : BaseConcreteFileUploader<Файл>
    {
        public Esss2Uploader(Esss2ReprotFactory reportFactory, IReportValidator<Файл> validator)
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.Esss2;
        protected override string FileName => "esss_2.file";
    }

    public class Esss1Uploader : BaseConcreteFileUploader<Файл>
    {
        public Esss1Uploader(Esss1ReprotFactory reportFactory, IReportValidator<Файл> validator) 
            : base(reportFactory, validator)
        {
        }

        public override ReportType Type => ReportType.Esss1;
        protected override string FileName => "esss_1.file";
    }
}