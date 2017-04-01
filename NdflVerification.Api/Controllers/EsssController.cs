using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NdflVerification.ReportsContext.Domain.Services.Factories.XsdImplement.Esss;
using NdflVerification.ReportsContext.Domain.Services.Validators;

namespace NdflVerification.Api.Controllers
{
    /// <summary>
    /// Обработка данных отчета ЕССС
    /// </summary>
    public class EsssController : ApiController
    {
        private readonly IReportValidator<Файл> _esssValidator;
        
        public EsssController(IReportValidator<Файл> esssValidator)
        {
            _esssValidator = esssValidator;
        }

    }
}
