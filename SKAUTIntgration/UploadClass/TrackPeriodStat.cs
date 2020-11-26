using System;
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
        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged monitoring)
        {
            SetAllUrl(UrlServer, "TrackPeriod");
            unitsId = monitoring.unitsId;
            JSONprepare(Period);
        }
    }
}
