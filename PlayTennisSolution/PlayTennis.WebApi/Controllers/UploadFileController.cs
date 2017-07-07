using PlayTennis.Bll;
using PlayTennis.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PlayTennis.WebApi.Controllers
{
    public class UploadFileController : ApiController
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UploadFileController()
        {
            UserImageService = new UserImageService();
        }
        public UserImageService UserImageService { get; set; }

        // GET: api/UploadFile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UploadFile/5
        public List<string> Get(Guid id)
        {
            var host = ConfigHelper.GetConfigValueOrDefault("imageDownloadPath", "");

            return
                UserImageService.Entitys()
                    .Where(p => p.UserInformationId == (id) && p.IsDelete.Equals(false))
                    .Select(p => host + p.RelativePath)
                    .Take(9)
                    .ToList();
        }

        // POST: api/UploadFile
        public string Post(Guid userInforId)
        {
            _log.Info(userInforId);

            var imageFile = HttpContext.Current.Request.Files["image1"];
            var result = FileHelper.SaveSingleFile(imageFile);
            if (result.Item1.Equals(true))
            {
                UserImageService.AddImage(userInforId, result.Item2);
                var path = ConfigHelper.GetConfigValueOrDefault("imageDownloadPath", @"");

                return path + result.Item2;
            }
            else
            {
                throw new Exception(result.Item2);
            }
        }

        // PUT: api/UploadFile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UploadFile/5
        public void Delete(int id)
        {
        }
    }
}
