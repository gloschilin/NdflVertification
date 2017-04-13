using System.Security.Cryptography.X509Certificates;
using System.Web;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;

namespace NdflVertification.Web.Api.Utils
{
    public interface IFileUploader
    {
        ReportType Type { get; }
        bool TryUpload(HttpPostedFileBase file, int actionUserId);
        bool Exists(int actionUserId);
        string Path(int actionUserId);
        void Delete(int actionUserId);
    }
}
