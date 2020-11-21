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
        public void RequestNeedParameter()
        {
            SetAllUrl(UrlServer, "NavigationValidation");
        }

        public List<string> RequestResultArray()
        {
            PrepairParameters();
            var result = new List<string>();
            foreach (var item in JSONRunSession)
            {
                result.Add(RequestSender.SendPostRequest(Token, getStatistics, item));
            }
            return result;
        }
        private void PrepairParameters()
        {
            JSONprepare(Period);
            PrepareStatistic(Token);
        }
    }
}
