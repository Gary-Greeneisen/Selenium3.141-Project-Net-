using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Config
{
    public static class AppConfig
    {
        /// <summary>
        /// Get the value corresponding to the key from App.config settings
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns></returns>
        public static string GetAppSettingsValue(string key)
        {
            //return ConfigurationSettings.AppSettings[key];
            return ConfigurationManager.AppSettings[key].ToString();
        }

        /// <summary>
        /// Get the section value corresponding to the key from 
        /// Custom ConfigSections Section
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns></returns>
        public static string GetAppSectionValue(string key)
        {

            //First get the current environment from the appSettings section
            var environment = ConfigurationManager.AppSettings["Environment"].ToString();



            //Next get the section value based on the "Environment"
            var sections = ConfigurationManager.GetSection(environment) as NameValueCollection;
            return sections[key].ToString();


        }

    } //end  public static class AppConfig


} //end namespace AcceptanceTests.Config
