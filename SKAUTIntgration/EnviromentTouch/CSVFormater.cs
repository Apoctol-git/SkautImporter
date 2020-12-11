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
                //foreach (var savingElevent in document.SavingElevents)
                //{
                var savingElevent = document.SavingElevents;
                var notCatched = true;
                SetNextNumber();
                while (notCatched)
                {
                    try
                    {
                        var path = basePath + document.Path + @"\";
                        var unitId = document.UnitId == "-1" ? i.ToString() : "_" + document.UnitId;
                        var period = document.Period.Year.ToString() + document.Period.Month.ToString() + document.Period.Day.ToString();
                        var name = period+ "_" +document.Name+"_" +unitId+ ".csv";
                        using (StreamWriter streamReader = new StreamWriter(path + name,false, Encoding.UTF8))
                        {
                            using (CsvWriter csvWriter = new CsvWriter(streamReader, System.Globalization.CultureInfo.CurrentCulture))
                            {
                                //if (savingElevent.Count!=0)
                                //{
                                //    foreach (var item in savingElevent)
                                //    {
                                //csvWriter.Configuration.RegisterClassMap(savingElevent[0].GetCurrentClassMap(csvWriter));
                                //csvWriter.Configuration.Delimiter = ",";
                                csvWriter.WriteRecords(savingElevent);

                            }
                        }
                        notCatched = false;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Directory.CreateDirectory(basePath + document.Path);
                    }
                }
                //}
                logger.WriteLog(document.Name, document.UnitId, "сохранён");
            }
        }
        public void Saver(string basePath, int numberItteration, List<SavingDocument> documents)
        {

            foreach (var document in documents)
            {
                if (numberItteration == 0)
                {
                    DirectoryInfo directory = new DirectoryInfo(basePath + document.Path);
                    if (directory.Exists)
                    {
                        directory.Delete(true);
                    }
                }
                var logger = new Logger();
                //foreach (var savingElevent in document.SavingElevents)
                //{
                var savingElevent = document.SavingElevents;
                var notCatched = true;
                SetNextNumber();
                while (notCatched)
                {
                    try
                    {
                        var path = basePath + document.Path + @"\";
                        var unitId = document.UnitId == "-1" ? i.ToString() : "_" + document.UnitId;
                        var period = document.Period.Year.ToString() + 
                            (document.Period.Month<10?"0"+document.Period.Month.ToString(): document.Period.Month.ToString())
                            + (document.Period.Day<10?"0"+document.Period.Day.ToString(): document.Period.Day.ToString());
                        var name = period+ "_" +document.Name+"_" + numberItteration + ".csv";
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
                                csvWriter.WriteRecords(savingElevent);

                            }
                        }
                        notCatched = false;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Directory.CreateDirectory(basePath + document.Path);
                    }
                }
                //}
                logger.WriteLog(document.Name, document.UnitId, "сохранён");
            }
        }
        
        private void SetNextNumber()
        {
            i++;
        }

    }
}
