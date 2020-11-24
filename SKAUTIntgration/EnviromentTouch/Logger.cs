using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    public class Logger
    {
        string path;

        public Logger()
        {
            path = Environment.CurrentDirectory + @"\Log.txt";
        }
        public void WriteLog(string loggingObject, string unitId, string status)
        {
            using (var writer = new StreamWriter(path,true, Encoding.UTF8))
            {
                var dinamicText = unitId == "-1" ? null : "Для объекта мониторинга " + unitId;
                var text = "Объект " + loggingObject + " " + dinamicText + " " + status;
                writer.WriteLine(text);
            }
        }
        public void RemoveOldLogs()
        {
            File.Delete(path);
        }
    }
}
