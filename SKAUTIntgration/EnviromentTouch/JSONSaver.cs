using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SKAUTIntgration.EnviromentTouch
{
    public class JSONSaver
    {
        private string rootCatalog;

        public JSONSaver(string rootCatalog)
        {
            this.rootCatalog = rootCatalog;
        }

        public void Write(string targetCatalog, string unitId, string json)
        {
            string path = rootCatalog + targetCatalog + "JSON" + @"\" ;
            string name = unitId + ".json";
            try
            {
                using (StreamWriter sw = new StreamWriter(path+name, false, Encoding.UTF8))
                {
                    sw.WriteLine(json);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(path);
                Write(targetCatalog, unitId, json);
            }

        }
    }
}
