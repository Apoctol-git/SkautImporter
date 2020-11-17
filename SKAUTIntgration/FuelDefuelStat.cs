using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    public class FuelDefuelStat:BaseStaticticReqestClass,IRuleRequster
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string UrlServer { get; set; }
        public string TargetCatalog { get; set; }
        public bool IsActivated { get; set; }
        public DateTime Period { get; set; }
        public FuelDefuelStat(string baseUrl, DateTime period)
        {
            Name = "FuelingDefuelingStatistic";
            UrlServer = baseUrl;
            Period = period;
        }
        public void RequestNeedParameter()
        {
            SetAllUrl(UrlServer, "fdstat");
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
