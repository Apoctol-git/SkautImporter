﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class RuleActionAgregator
    {
        readonly List<IRuleRequster> rules = new List<IRuleRequster>();
        public void SetRules(string baseURL,DateTime period)
        {
            rules.Add(new MonitoringObjectAllUnitsPaged(baseURL,period));
            rules.Add(new FuelFlowStat(baseURL, period));
            rules.Add(new FuelDefuelStat(baseURL, period));
            rules.Add(new FuelEventStat(baseURL, period));
            rules.Add(new MotorModesStat(baseURL, period));
            rules.Add(new NavigationValidationStat(baseURL, period));
            rules.Add(new TrackPeriodStat(baseURL, period));
            rules.Add(new TrackPeriodsMileageStat(baseURL, period));
            rules.Add(new NavigationFiltrationStat(baseURL, period));
            rules.Add(new DiscreteSensorStat(baseURL, period));
        }
        public void UpdateRulesValue(INIManager INI, string token)
        {
            foreach (var item in rules)
            {
                item.IsActivated = INI.GetPrivateString(item.Name, "IsActive") == "true"?true:false;
                item.TargetCatalog = INI.GetPrivateString(item.Name, "TargetPath");
                item.Token = token;
                item.RequestNeedParameter();
            }
        }
        public List<SavingDocument> MakeRequest()
        {
            //Dictionary<string[],Dictionary<string, string>[]> responses = new Dictionary<string[], Dictionary<string, string>[]>();
            var logger = new Logger();
            logger.RemoveOldLogs();
            List<SavingDocument> responses = new List<SavingDocument>();
            foreach (var item in rules)
            {
                if (item.IsActivated)
                {
                    var respCollection = item.RequestResultArray();
                    logger.WriteLog(item.Name, "-1", "ответ получен");
                    foreach (var resp in respCollection)
                    {
                        var responseAnswer = item.ResponseParser(resp.Value);
                        responses.Add(new SavingDocument(item.Name, item.Period, resp.Key, item.TargetCatalog, responseAnswer));
                        logger.WriteLog(item.Name, resp.Key, "загружен");
                    }
                }
            }
            return responses;
        }
    }
}
