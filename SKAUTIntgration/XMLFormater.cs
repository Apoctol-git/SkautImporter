using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SKAUTIntgration
{
    public class XMLFormater
    {
        static public void XMLSaver(string basePath, Dictionary<string[], Dictionary<string, string>[]> documents)
        {
            var i = 0;
            string lastName = null;
            foreach (var array in documents)
            {
                if (array.Key[0]!=lastName)
                {
                    lastName = array.Key[0];
                    i = 0;
                }
                foreach (var item in array.Value)
                {
                    if (item !=null)
                    {
                        var xdoc = FormXML(array.Key[0], item);
                        SaveXML(basePath+array.Key[1], array.Key[0]+i, xdoc);
                        i++;
                    }

                }          
            }
        }
        static XDocument FormXML(string elementName, Dictionary<string,string> datas)
        {
            XDocument newDoc = new XDocument();
            XElement objectName = new XElement(elementName);
            foreach (var item in datas)
            {
                XElement datasName = new XElement("Name", item.Key);
                XElement datasValue = new XElement("Value", item.Value);
                objectName.Add(datasName);
                objectName.Add(datasValue);
            }
            newDoc.Add(objectName);
            return newDoc;
        }
        static void SaveXML(string path, string elementName, XDocument newDoc)
        {
            try
            {
                newDoc.Save(path+@"\"+ elementName + ".xml");
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(path);
                newDoc.Save(path + @"\" + elementName + ".xml");
            }
             
        }
    }
}
