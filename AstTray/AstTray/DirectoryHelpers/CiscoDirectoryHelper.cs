using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace AstTray.DirectoryHelpers
{
    public class CiscoDirectoryHelper
    {
        /// <summary>
        /// Returns a list of DirectoryEntry from the Cisco Directory URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<DirectoryEntry> GetCiscoDirectory(string url)
        {
            List<DirectoryEntry> rtn = new List<DirectoryEntry>();

            WebClient wc = new WebClient();
            string response = wc.DownloadString(url);

            if (response.Contains("CiscoIPPhoneDirectory"))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);

                XmlNodeList entries = doc.SelectNodes("//CiscoIPPhoneDirectory//DirectoryEntry");
                foreach (XmlNode node in entries)
                {
                    if (node.Name == "DirectoryEntry")
                    {
                        DirectoryEntry tmp = new DirectoryEntry()
                        {
                            Name = node.SelectSingleNode("Name").InnerText,
                            Number = node.SelectSingleNode("Telephone").InnerText
                        };
                        rtn.Add(tmp);
                    }
                    //Console.WriteLine("Age = {0}, Gender = {1}", customer.Attributes["age"].Value, customer.Attributes["gender"].Value);
                }


                return rtn;
            }
            else
            {
                throw new Exception("Directory isn't Cisco Directory XML");
            }
        }

    }
}
