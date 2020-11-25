using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    public class CSVFormater : IFormater
    {
        private int i;
        public void Saver(string basePath, List<SavingDocument> documents)
        {
            foreach (var document in documents)
            {
                var logger = new Logger();
                foreach (var savingElevent in document.SavingElevents)
                {
                    var notCatched = true;
                    SetNextNumber();
                    while (notCatched)
                    {
                        try
                        {
                            var path = basePath + document.Path + @"\";
                            var unitId = document.UnitId == "-1" ? i.ToString() : "_" + document.UnitId;
                            var period = document.Period.Year + document.Period.Month + document.Period.Day;
                            var name = period+ "_" +document.Name+"_" +unitId+ ".csv";
                            using (StreamWriter streamReader = new StreamWriter(path + name))
                            {
                                using (CsvWriter csvReader = new CsvWriter(streamReader, System.Globalization.CultureInfo.CurrentCulture))
                                {
                                    if (savingElevent.Count!=0)
                                    {
                                        csvReader.Configuration.Delimiter = ",";
                                        csvReader.WriteRecords(savingElevent);
                                    }
                                }
                            }
                            notCatched = false;
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Directory.CreateDirectory(basePath + document.Path);
                        }
                    }
                }
                logger.WriteLog(document.Name, document.UnitId, "сохранён");
            }
        }
        private void SetNextNumber()
        {
            i++;
        }

    }
}
