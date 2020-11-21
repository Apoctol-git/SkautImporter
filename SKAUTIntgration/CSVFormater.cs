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
            var i = 0;
            string lastName = null;
            foreach (var document in documents)
            {
                foreach (var savingElevent in document.SavingElevents)
                {

                    if (document.Name != lastName)
                    {
                        lastName = document.Name;
                        i = 0;
                    }
                    var notCatched = true;
                    while (notCatched)
                    {
                        try
                        {
                            using (StreamWriter streamReader = new StreamWriter(basePath + document.Path + @"\" + document.Name + i + ".csv"))
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
                    i++;
                }
            }
        }
    }
}
