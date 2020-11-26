using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class NavigationFiltrationStat:BaseStaticticReqestClass,IRuleRequster
    {
        public NavigationFiltrationStat(string baseUrl, DateTime period)
        {
            Name = "NavigationFiltrationStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged monitoring)
        {
            SetAllUrl(UrlServer, "NavigationFiltration");
            unitsId = monitoring.unitsId;
            JSONprepare(Period);
        }

    }
}
