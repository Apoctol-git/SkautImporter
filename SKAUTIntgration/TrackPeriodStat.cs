﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class TrackPeriodStat:BaseStaticticReqestClass,IRuleRequster
    {
        public TrackPeriodStat(string baseUrl, DateTime period)
        {
            Name = "TrackPeriodStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter()
        {
            SetAllUrl(UrlServer, "TrackPeriod");
        }

        public Dictionary<string, string> RequestResultArray()
        {
            PrepairParameters();
            var result = new Dictionary<string, string>();
            foreach (var item in JSONRunSession)
            {
                result.Add(item.Key, RequestSender.SendPostRequest(Token, getStatistics, item.Value));
            }
            return result;
        }
        private void PrepairParameters()
        {
            JSONprepare(Period);
            PrepareStatistic(Token);
        }
    }
}
