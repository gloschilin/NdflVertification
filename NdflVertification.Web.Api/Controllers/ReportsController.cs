using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using NdflVerification.ReportsContext.Domain.Services.Validators.Enums;
using NdflVertification.Web.Api.Utils;

namespace NdflVertification.Web.Api.Controllers
{
    public class UploadedFileInfo
    {
        public string Name { get; private set; }
        public HttpPostedFileBase File { get; private set; }

        public UploadedFileInfo(string name, HttpPostedFileBase file)
        {
            Name = name;
            File = file;
        }
    }

    public class UploadedFileInfoArrayBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var files = controllerContext.HttpContext.Request.Files;
            var list = new List<UploadedFileInfo>();

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var name = files.AllKeys[i];
                var fileInfo = new UploadedFileInfo(name, file);
                list.Add(fileInfo);
            }

            return list.ToArray();
        }
    }

    public class ReportsController : Controller
    {
        private readonly IEnumerable<IFileUploader> _fileUploaders;

        public ReportsController(IEnumerable<IFileUploader> fileUploaders)
        {
            _fileUploaders = fileUploaders;
        }

        [HttpGet]
        [Route("~/reports/{actionUserId}/upload")]
        public ActionResult Index(int actionUserId)
        {
            ViewBag.ActionUserId = actionUserId;
            return View();
        }

        [HttpOptions]
        [Route("~/reports/{actionUserId}/upload")]
        public ActionResult LoadOptions(int actionUserId, HttpPostedFileBase file)
        {
            return Json("ok");
        }

        [HttpPost]
        [Route("~/reports/{actionUserId}/upload")]
        public ActionResult Load(int actionUserId, UploadedFileInfo[] files)
        {
            var result = new UploadFileResult();

            foreach (var httpPostedFileBase in files)
            {
                if (httpPostedFileBase == null)
                {
                    continue;
                }

                foreach (var fileUploader in _fileUploaders)
                {
                    if (!fileUploader.TryUpload(httpPostedFileBase.File, actionUserId)) continue;

                    switch (fileUploader.Type)
                    {
                        case ReportType.SixNdfl:
                            result.Ndfl6 = true;
                            break;
                        case ReportType.Esss:
                            result.Esss = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                }
            }

            var info = new ReportsInfo();

            foreach (var fileUploader in _fileUploaders)
            {
                var exists = fileUploader.Exists(actionUserId);

                switch (fileUploader.Type)
                {
                    case ReportType.SixNdfl:
                        info.Ndfl6 = exists;
                        break;
                    case ReportType.Esss:
                        info.Esss = exists;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            result.FilesExists = info;

            return new XmlResult(result);
        }

        
    }

    [DataContract]
    public class UploadFileResult
    {
        public UploadFileResult()
        {
            FilesExists = new ReportsInfo();
            Esss = false;
            Ndfl6 = false;
        }

        [DataMember]
        public bool Esss { get; set; }

        [DataMember]
        public bool Ndfl6 { get; set; }

        [DataMember]
        public ReportsInfo FilesExists { get; set; }
    }

    [DataContract]
    public class ReportsInfo
    {
        public ReportsInfo()
        {
            Esss = false;
            Ndfl6 = false;
        }

        [DataMember]
        public bool Esss { get; set; }

        [DataMember]
        public bool Ndfl6 { get; set; }
    }


    public class XmlResult : ActionResult
    {
        private object objectToSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResult"/> class.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize to XML.</param>
        public XmlResult(object objectToSerialize)
        {
            this.objectToSerialize = objectToSerialize;
        }

        /// <summary>
        /// Gets the object to be serialized to XML.
        /// </summary>
        public object ObjectToSerialize
        {
            get { return this.objectToSerialize; }
        }

        /// <summary>
        /// Serialises the object that was passed into the constructor to XML and writes the corresponding XML to the result stream.
        /// </summary>
        /// <param name="context">The controller context for the current request.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.objectToSerialize != null)
            {
                context.HttpContext.Response.Clear();
                var xs = new System.Xml.Serialization.XmlSerializer(this.objectToSerialize.GetType());
                context.HttpContext.Response.ContentType = "text/xml";
                xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);
            }
        }
    }
}