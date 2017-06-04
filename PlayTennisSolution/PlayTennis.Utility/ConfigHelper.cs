using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Utility
{
    /// <summary>
    /// 配置文件帮助类
    /// 20170604-caohua
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValueByKey(string key)
        {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                result = ConfigurationManager.AppSettings[key];
            }
            return result;
        }
        /// <summary>
        /// 读取配置文件，并预设置默认值
        /// </summary>
        /// <param name="nowData"></param>
        /// <param name="configKey"></param>
        public static void ReadConfig(ref string nowData, string configKey)
        {
            var appidConfig = ConfigHelper.GetValueByKey(configKey);
            if (!string.IsNullOrEmpty(appidConfig))
            {
                nowData = appidConfig;
            }
        }

        public static void WriteValue(string keyName, string keyValue)
        {
            //Configuration config = WebConfigurationManager.OpenWebConfiguration(null);

            //AppSettingsSection app = config.AppSettings;

            //app.Settings.Add("x", "this is X");

            //config.Save(ConfigurationSaveMode.Modified);
        }

        public static string GetConfigValueOrDefault(string apiKey, string defaultValue)
        {
            var conValue = ConfigHelper.GetValueByKey(apiKey);
            if (string.IsNullOrEmpty(conValue))
            {
                return defaultValue;
            }
            else
            {
                return conValue;
            }
        }
    }
}
