using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class TrackPeriodsMileageStat:BaseStaticticReqestClass,IRuleRequster
    {
        public TrackPeriodsMileageStat(string baseUrl, DateTime period)
        {
            Name = "TrackPeriodsMileageStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged monitoring)
        {
            SetAllUrl(UrlServer, "trackPeriodsMileage");
            unitsId = monitoring.unitsId;
        }


    }
}
