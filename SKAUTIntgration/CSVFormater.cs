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
        public void Saver(string basePath, List<SavingDocument> documents)
        {
            foreach (var document in documents)
            {
                var logger = new Logger();
                foreach (var savingElevent in document.SavingElevents)
                {

                    var notCatched = true;
                    while (notCatched)
                    {
                        try
                        {
                            var path = basePath + document.Path + @"\";
                            var unitId = document.UnitId == "-1" ? null : "_" + document.UnitId;
                            var name = document.Period.ToLongDateString()+"_" +document.Name+"_" +unitId+ ".csv";
                            using (StreamWriter streamReader = new StreamWriter(path + name))
                            {
                                using (CsvWriter csvReader = new CsvWriter(streamReader, System.Globalization.CultureInfo.CurrentCulture))
                                {


                                    csvReader.Configuration.Delimiter = ",";
                                    csvReader.WriteRecords(savingElevent);
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
    }
}
