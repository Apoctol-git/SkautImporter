using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.SOAP
{
    public class CSVPrinter
    {
        public void Print(string basePath, string documentPath, DateTime Period, List<object> documents)
        {
            foreach (var document in documents)
            {
                var logger = new Logger();
               var notCatched = true;
                while (notCatched)
                {
                    try
                    {
                        var path = basePath + documentPath + @"\";
                        //var unitId = document.UnitId == "-1" ? i.ToString() : "_" + document.UnitId;
                        var period = Period.Year.ToString() + Period.Month.ToString() + Period.Day.ToString();
                        var name = period + "_" +documentPath  +  ".csv";//document.Name"_" + unitId +
                        using (StreamWriter streamReader = new StreamWriter(path + name,true, Encoding.UTF8))
                        {
                            using (CsvWriter csvWriter = new CsvWriter(streamReader, System.Globalization.CultureInfo.CurrentCulture))
                            {
                                //if (savingElevent.Count!=0)
                                //{
                                //    foreach (var item in savingElevent)
                                //    {
                                //csvWriter.Configuration.RegisterClassMap(savingElevent[0].GetCurrentClassMap(csvWriter));
                                //csvWriter.Configuration.Delimiter = ",";
                                csvWriter.WriteRecords(documents);

                            }
                        }
                        notCatched = false;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Directory.CreateDirectory(basePath + documentPath);
                    }
                }
                //}
                //logger.WriteLog(document.Name, document.UnitId, "сохранён");
            }
        }
    }
}
