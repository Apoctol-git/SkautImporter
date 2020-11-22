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
        private void PrepairParameters()
        {
            JSONprepare(Period);
            PrepareStatistic(Token);
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
    }
}
