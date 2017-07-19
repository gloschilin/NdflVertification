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
        public WebValidationInfo(ValidationResultType status, string message, int quarter)
        {
            Quarter = quarter;
            Status = status;
            Message = message;
        }

        public WebValidationInfo()
        {
        }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public int Quarter { get; set; }

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
            
        }

        public void Handle(ValidationResult validationResult)
        {
            Debug.WriteLine($"{validationResult.СheckReportType} : {validationResult.ValidationResultType}");
            var result = (HttpContext.Current.Items["WebValidationResultHandler"] as List<WebValidationInfo>)
                ?? new List<WebValidationInfo>();
            var message = _textDictionary.GetText(validationResult.СheckReportType.ToString(), validationResult.Quarter)
                ?? validationResult.СheckReportType.ToString();
            result.Add(new WebValidationInfo(validationResult.ValidationResultType, message, validationResult.Quarter)
            {
                Label = validationResult.СheckReportType.ToString()
            });
            HttpContext.Current.Items["WebValidationResultHandler"] = result;
        }
    }
}