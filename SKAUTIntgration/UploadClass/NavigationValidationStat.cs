using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class NavigationValidationStat:BaseStaticticReqestClass,IRuleRequster
    {
        public NavigationValidationStat(string baseUrl, DateTime period)
        {
            Name = "NavigationValidationStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged monitoring)
        {
            SetAllUrl(UrlServer, "NavigationValidation");
            unitsId = monitoring.unitsId;
        }


    }
}
