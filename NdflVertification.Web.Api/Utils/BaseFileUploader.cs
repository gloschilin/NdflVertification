using System.IO;
using System.Web;
using NdflVerification.ReportsContext.Domain.Services.Factories;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{
    public abstract class BaseFileUploader<TReport> : IFileUploader
    {
        private readonly IReportFactory<TReport> _reportFactory;
        private readonly IReportValidator<TReport> _validator;

        protected BaseFileUploader(IReportFactory<TReport> reportFactory, IReportValidator<TReport> validator)
        {
            _reportFactory = reportFactory;
            _validator = validator;
        }

        public abstract ReportType Type { get; }

        protected abstract string FileName { get; }

        public bool TryUpload(HttpPostedFileBase file, int actionUserId)
        {
            string path = $"~/Files/{actionUserId}";

            //check dir
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }

            if (!Directory.Exists(HttpContext.Current.Server.MapPath($"{path}/tmp")))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath($"{path}/tmp"));
            }

            // сохраняем файл в папку Files в проекте
            file.SaveAs(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"));

            if (!_reportFactory.Allow(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}")))
            {
                File.Delete(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"));
                return false;
            }

            TReport result;
            if (!_reportFactory.TryReadFromLocalFile(
                HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"), out result))
            {
                File.Delete(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"));
                return false;
            }

            //try valid file
            if (!_validator.TryValidate(result))
            {
                File.Delete(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"));
                return false;
            }

            if (File.Exists(HttpContext.Current.Server.MapPath($"{path}/{FileName}")))
            {
                File.Delete(HttpContext.Current.Server.MapPath($"{path}/{FileName}"));
            }
            File.Copy(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"),
                HttpContext.Current.Server.MapPath($"{path}/{FileName}"));
            File.Delete(HttpContext.Current.Server.MapPath($"{path}/tmp/{FileName}"));

            return true;
        }

        public bool Exists(int actionUserId)
        {
            return File.Exists(Path(actionUserId));
        }

        public string Path(int actionUserId)
        {
            string path = $"~/Files/{actionUserId}";
            return HttpContext.Current.Server.MapPath($"{path}/{FileName}");
        }

        public void Delete(int actionUserId)
        {
            if (System.IO.File.Exists(Path(actionUserId)))
            {
                File.Delete(Path(actionUserId));
            }
        }
    }
}