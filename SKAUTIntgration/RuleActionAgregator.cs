using SKAUTIntgration.TableCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class RuleActionAgregator
    {
        MonitoringObjectAllUnitsPaged monitoring;
        LoginRequester Login;
        readonly List<IRuleRequster> rules = new List<IRuleRequster>();
        public void SetMonitoring(string baseURL, DateTime period)
        {
            monitoring = new MonitoringObjectAllUnitsPaged(baseURL, period);
        }
        public void UpdateMonitoring(INIManager INI, string token)
        {
            monitoring.IsActivated = INI.GetPrivateString(monitoring.Name, "IsActive") == "true" ? true : false;
            monitoring.TargetCatalog = INI.GetPrivateString("ChildPath ", "TargetPath");
            monitoring.Token = token;
            monitoring.RequestNeedParameter(monitoring);
        }
        public void SaveMonitoringObject(IFormater saver, string rootCatalog)
        {
            var respCollection = monitoring.RequestResultArray(1, 1);
            List<SavingDocument> responses = new List<SavingDocument>();
            TableClassBuilder builder = new TableClassBuilder();
            builder.SetClassList();
            foreach (var resp in respCollection)
            {
                var responseAnswer = monitoring.ResponseParser(resp.Value);
                var document = new SavingDocument(monitoring.Name, monitoring.Period, resp.Key, monitoring.TargetCatalog);
                foreach (var item in responseAnswer)
                {
                    var table = builder.GetTable(monitoring.Name, item);

                    document.SavingElevents.Add(table);
                }
                responses.Add(document);
            }
            saver.Saver(rootCatalog, responses);
            //rules[0].IsActivated = false;
        }
        public void SetRules(string baseURL,DateTime period)
        {
            rules.Add(new FuelFlowStat(baseURL, period));
            rules.Add(new FuelDefuelStat(baseURL, period));
            //rules.Add(new FuelEventStat(baseURL, period));
            rules.Add(new MotorModesStat(baseURL, period));
            rules.Add(new NavigationValidationStat(baseURL, period));
            //rules.Add(new TrackPeriodStat(baseURL, period));
            rules.Add(new TrackPeriodsMileageStat(baseURL, period));
            rules.Add(new NavigationFiltrationStat(baseURL, period));
            rules.Add(new DiscreteSensorStat(baseURL, period));
        }
        public void SetLoginRequester(LoginRequester loginreq)
        {
            Login = loginreq;
        }
        public void UpdateRulesValue(INIManager INI, string token)
        {
            foreach (var item in rules)
            {
                item.IsActivated = INI.GetPrivateString(item.Name, "IsActive") == "true"?true:false;
                item.TargetCatalog = INI.GetPrivateString(item.Name, "TargetPath");
                item.Token = token;
                item.RequestNeedParameter(monitoring);
            }
        }
        public void MakeRequestAndSave(IFormater saver, string rootCatalog, int compare) 
        {
            //Dictionary<string[],Dictionary<string, string>[]> responses = new Dictionary<string[], Dictionary<string, string>[]>();
            var logger = new Logger();
            logger.RemoveOldLogs();
            var totalCount = GetArrayLeght(monitoring);
            var totalIterration = Math.Round((double)totalCount / compare);
            for (int i = 0; i < totalIterration; i++)
            {
                try
                {
                    var xmlForm = RequestMaker(logger,i,compare);
                    saver.Saver(rootCatalog, i, xmlForm);
                }
                catch (Exception)
                {
                    var token = Login.ReLogin();
                    UpdateRulesValue(Login.GetINI(), token);
                }

            }

        }
        private int GetArrayLeght (MonitoringObjectAllUnitsPaged monitoring)
        {
            return monitoring.unitsId.Count;
        }
        private List<SavingDocument> RequestMaker(Logger logger, int it, int compare)
        {
            List<SavingDocument> responses = new List<SavingDocument>();
            TableClassBuilder builder = new TableClassBuilder();
            builder.SetClassList();
            foreach (var item in rules)
            {
                if (item.IsActivated)
                {
                    var respCollection = item.RequestResultArray(it,compare);
                    logger.WriteLog(item.Name, "-1", "ответ получен");
                    foreach (var resp in respCollection)
                    {
                        var responseAnswer = item.ResponseParser(resp.Value);
                        //var name = resp.Key == "-1" ? item.Name : "Object-" + resp.Key;
                        var document = new SavingDocument(item.Name, item.Period, resp.Key, item.TargetCatalog);
                        foreach (var ra in responseAnswer)
                        {
                            var tablePrototype = builder.GetTable(item.Name, ra);
                            var tables = tablePrototype.GetTablesList();
                            foreach (var table in tables)
                            {
                                table.SetUnitId(resp.Key);
                                document.SavingElevents.Add(table);
                            }
                        }
                        responses.Add(document);
                        logger.WriteLog(item.Name, resp.Key, "загружен");
                    }
                }
            }
            return responses;
        }
        //private int UnitIdKeyFinder(string unitId, List<SavingDocument> array)
        //{
        //    for (int i = 0; i < array.Count; i++)
        //    {
        //        if (array[i].UnitId==unitId)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}
    }
}
