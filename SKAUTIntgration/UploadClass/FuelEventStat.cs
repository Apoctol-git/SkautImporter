using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class FuelEventStat:BaseStaticticReqestClass,IRuleRequster
    {
        public FuelEventStat(string baseUrl, DateTime period)
        {
            Name = "FuelEventStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter()
        {
            SetAllUrl(UrlServer, "FuelEvent");
        }


    }
}
