using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace PlayTennis.Utility
{
    public class FileHelper
    {
        private static log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static Tuple<bool, string> SaveSingleFile(HttpPostedFile file)
        {
            try
            {
                var path = ConfigHelper.GetConfigValueOrDefault("imageFilePath", @"C:\webLogs\image\");
                if (Directory.Exists(path) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(path);
                }
                var fileSaveName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                file.SaveAs(path + fileSaveName);

                return new Tuple<bool, string>(true, fileSaveName);
            }
            catch (Exception ex)
            {
                _log.Error(JsonConvert.SerializeObject(ex));
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}
