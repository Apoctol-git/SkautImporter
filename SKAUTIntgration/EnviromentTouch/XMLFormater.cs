using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SKAUTIntgration
{
    public class XMLFormater//:IFormater
    {
        //public void Saver(string basePath, List<SavingDocument> documents)
        //{
        //    var i = 0;
        //    string lastName = null;
        //    foreach (var array in documents)
        //    {
        //        if (array.Name!=lastName)
        //        {
        //            lastName = array.Name;
        //            i = 0;
        //        }
        //        foreach (var item in array.SavingElevents)
        //        {
        //            if (item !=null)
        //            {
        //                var xdoc = FormXML(array.Name, item);
        //                SaveXML(basePath+array.Path, array.Name+i, xdoc);
        //                i++;
        //            }

        //        }          
        //    }
        //}
        XDocument FormXML(string elementName, List<XMLelement> datas)
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
        void SaveXML(string path, string elementName, XDocument newDoc)
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
