using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class FuelFlowStat:BaseStaticticReqestClass,IRuleRequster
    {
        public FuelFlowStat(string baseUrl, DateTime period)
        {
            Name = "FuelFlowStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged monitoring)
        {
            SetAllUrl(UrlServer, "FuelFlow");
            unitsId = monitoring.unitsId;
            JSONprepare(Period);
        }
    }
}
