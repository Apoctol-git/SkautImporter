using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class MotorModesStat : BaseStaticticReqestClass,IRuleRequster
    {
        public MotorModesStat(string baseUrl, DateTime period)
        {
            Name = "MotorModesStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter()
        {
            SetAllUrl(UrlServer, "MotorModes");
        }

    }
}
