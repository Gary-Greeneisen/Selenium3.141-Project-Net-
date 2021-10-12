using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AcceptanceTests.Common.Library;
using AcceptanceTests.Config;

namespace AcceptanceTests.Common.Utilities
{
    public partial class XmlDataFiles
    {



        public XmlNode rootNode(string filename, string startingNode)
        {

            //Get project/file dir
            var dataDir = Libary.GetDataFileDir();
            var fileDir = dataDir + filename;

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);


            XmlNode root = doc.DocumentElement.SelectSingleNode(startingNode);

            return root;

        }

        private void ExampleTestMethod1()
        {

            //Get project/file dir
            var projectDir = Libary.GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\Example\";
            var fileDir = dataFileDir + "XMLTestFile1.xml";

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);

            //Find the root tag
            //The XmlNodeList reads all the nodes = "/Student"
            //This example has (1)-root node = "/Student"
            //
            //XmlNodeList allNodes = doc.DocumentElement.SelectNodes("/Student");
            XmlNode root = doc.DocumentElement.SelectSingleNode("/Student");

            //Read the file data into program variables
            var firstname = root.SelectSingleNode("firstname").InnerText.Trim();
            var lastname = root.SelectSingleNode("lastname").InnerText.Trim();
            var age = Int32.Parse(root.SelectSingleNode("age").InnerText.Trim());

            //Read (1)-or more Services
            var services = root.SelectSingleNode("services").InnerText.Trim();
            services = services.Replace("\r\n", " ").Replace(" ", "");
            List<String> servicesList = services.Split(',').ToList();

        }

        private void ExampleTestMethod2()
        {
            //First get the current environment from the appSettings section
            var environment = AppConfig.GetAppSettingsValue("Environment");

            //Get project/file dir
            var projectDir = Libary.GetProjectDir();
            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\" + environment + "\\";
            var fileDir = dataFileDir + "XMLTestFile1.xml";

            //Load the filename
            XmlDocument doc = new XmlDocument();
            doc.Load(fileDir);

            //Find the root tag
            //The XmlNodeList reads all the nodes = "/Student"
            //This example has (1)-root node = "/Student"
            //
            //XmlNodeList allNodes = doc.DocumentElement.SelectNodes("/Student");
            XmlNode root = doc.DocumentElement.SelectSingleNode("/Student");

            //Read the file data into program variables
            var firstname = root.SelectSingleNode("firstname").InnerText.Trim();
            var lastname = root.SelectSingleNode("lastname").InnerText.Trim();
            var age = Int32.Parse(root.SelectSingleNode("age").InnerText.Trim());

            //Read (1)-or more Services
            var services = root.SelectSingleNode("services").InnerText.Trim();
            services = services.Replace("\r\n", " ").Replace(" ", "");
            List<String> servicesList = services.Split(',').ToList();


        }







    } //end public partial class XmlDataFiles

} //end namespace AcceptanceTests.Common.Utilities
