using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SKAUTIntgration
{
    public class XMLFormater
    {
        static public void XMLSaver(Dictionary<string, Dictionary<string, string>[]> documents)
        {
            foreach (var array in documents)
            {
                foreach (var item in array.Value)
                {
                    var xdoc = formXML(array.Key, item);
                    saveXML(array.Key, xdoc);
                }          
            }
        }
        static XDocument formXML(string elementName, Dictionary<string,string> datas)
        {
            XDocument newDoc = new XDocument();
            XElement objectName = new XElement("lalal");
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
        static void saveXML(string elementName, XDocument newDoc)
        {
             newDoc.Save(elementName + ".xml");
        }
    }
}
