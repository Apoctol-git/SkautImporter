using Microsoft.Win32;
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
            //path = Environment.CurrentDirectory + @"\SKAUTIntegrationLog.txt";
            RegistryKey reg = Registry.ClassesRoot;
            path = reg.OpenSubKey("SKAUT_ROOT").GetValue("").ToString()+@"\SKAUTIntegrationLog.txt";
        }
        public void WriteLog(string message)
        {
            using (var writer = new StreamWriter(path,true, Encoding.UTF8))
            {
                var text = DateTime.Now.TimeOfDay + message;
                writer.WriteLine(text);
            }
        }
        public void WriteExeption(string message, string stackTrace)
        {
            using (var writer = new StreamWriter(path, true, Encoding.UTF8))
            {
               writer.WriteLine(DateTime.Now.TimeOfDay+" : "+message);
               writer.WriteLine("По адресу:"+ stackTrace);
            }
        }
        public void WriteKeyNotFoundExeption(string message, string keyValue)
        {
            using (var writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                writer.WriteLine(DateTime.Now.TimeOfDay + " : "+message);
                writer.WriteLine("Ключ: " + keyValue + " не найден");
            }
        }
        public void RemoveOldLogs()
        {
            File.Delete(path);
        }
    }
}
