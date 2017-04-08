using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Web;
using NdflVerification.ReportsContext.Domain.Services.Validators;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVerification.Texts;

namespace NdflVertification.Web.Api.Utils
{
    [DataContract]
    public class WebValidationInfo
    {
        public WebValidationInfo(ValidationResultType status, string message)
        {
            Status = status;
            Message = message;
        }

        public WebValidationInfo()
        {
        }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public ValidationResultType Status { get; set; }

        [DataMember]
        public string Label { get; set; }
    }

    public class WebValidationResultHandler: IValidationResultHandler
    {
        private readonly ITextDictionary _textDictionary;

        public WebValidationResultHandler(ITextDictionary textDictionary)
        {
            _textDictionary = textDictionary;
        }

        public void Handle(CheckReportType checkReportType, ValidationResultType validationResultType)
        {
            Debug.WriteLine($"{checkReportType} : {validationResultType}");
            var result = (HttpContext.Current.Items["WebValidationResultHandler"] as List<WebValidationInfo>) ?? new List<WebValidationInfo>();
            var message = _textDictionary[checkReportType.ToString()] ?? checkReportType.ToString();
            //var message = checkReportType.ToString();
            result.Add(new WebValidationInfo(validationResultType, message)
            {
                Label = checkReportType.ToString()
            });
            HttpContext.Current.Items["WebValidationResultHandler"] = result;
        }
    }
}