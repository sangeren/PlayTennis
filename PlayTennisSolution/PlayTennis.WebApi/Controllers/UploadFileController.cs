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
        // GET: api/UploadFile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UploadFile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UploadFile
        public string Post()
        {
            var imageFile = HttpContext.Current.Request.Files["image1"];
            var result = FileHelper.SaveSingleFile(imageFile);
            return result.Item2;
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
