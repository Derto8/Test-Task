using System;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace Junior_Backend_Test
{
    internal class XMLFile
    {
        public void GenerateXMLFile()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(@"Result.xml");

            XmlElement? xRoot = xDoc.DocumentElement;
            XmlNode? firstNode = xRoot?.FirstChild;
            if (firstNode != null) xRoot?.RemoveChild(firstNode);

            XmlNode? secondNode = xRoot?.FirstChild;
            if (secondNode != null) xRoot?.RemoveChild(secondNode);


            XmlElement dataElem = xDoc.CreateElement("data");

            string path = "../../../appsettings.json";
            string text = File.ReadAllText(path);
            var json = JObject.Parse(text);

            var sites = json["sites"].Select(token => token["site"]).ToArray();

            CheckSite check = new CheckSite();
            foreach (string s in sites)
            {
                string availability = check.CheckSiteAvailability(s);
                XmlText checkSiteText = xDoc.CreateTextNode($"Сайт: - {s} - {availability}");

                using(StreamWriter write = File.AppendText("log.txt"))
                {
                    Logging log = new Logging();
                    log.Log($"Сайт: - {s} - {availability}", write);
                    write.Close();
                }

                XmlElement checkSiteElem = xDoc.CreateElement("site");
                checkSiteElem.AppendChild(checkSiteText);

                dataElem.AppendChild(checkSiteElem);
            }
            xRoot?.AppendChild(dataElem);
            xDoc.Save(@"Result.xml");
        }

        public void PrintInformation()
        {
            string path = "../../../appsettings.json";
            string text = File.ReadAllText(path);
            var json = JObject.Parse(text);

            var sites = json["sites"].Select(token => token["site"]).ToArray();

            CheckSite check = new CheckSite();
            foreach (string s in sites)
            {
                string availability = check.CheckSiteAvailability(s);
                Console.WriteLine($"Сайт: - {s} - {availability}");

                using (StreamWriter write = File.AppendText("log.txt"))
                {
                    Logging log = new Logging();
                    log.Log($"Сайт: - {s} - {availability}", write);
                    write.Close();
                }
            }
        }
    }
}
