using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class DiscreteSensorStat:BaseStaticticReqestClass,IRuleRequster
    {
        public DiscreteSensorStat(string baseUrl, DateTime period)
        {
            Name = "DiscreteSensorStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter()
        {
            SetAllUrl(UrlServer, "DiscreteSensor");
        }
    }
}
