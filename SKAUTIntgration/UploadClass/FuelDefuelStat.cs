using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    public class FuelDefuelStat:BaseStaticticReqestClass,IRuleRequster
    {

        public FuelDefuelStat(string baseUrl, DateTime period)
        {
            Name = "FuelingDefuelingStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged monitoring)
        {
            SetAllUrl(UrlServer, "fdstat");
            unitsId = monitoring.unitsId;
        }
    }
}
