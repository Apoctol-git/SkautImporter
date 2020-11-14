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
        public XDocument newDoc;
        
        public XMLFormater()
        {
            newDoc =  new XDocument();
        }
        public void formXML(string elementName, Dictionary<string,string> datas)
        {
            XElement objectName = new XElement(elementName);
            foreach (var item in datas)
            {
                XElement datasName = new XElement("Name", item.Key);
                XElement datasValue = new XElement("Value", item.Value);
                objectName.Add(datasName);
                objectName.Add(datasValue);
            }
            newDoc.Add(objectName);
        }
        public void saveXML(string elementName)
        {
            newDoc.Save(elementName + ".xml");
        }
    }
}
