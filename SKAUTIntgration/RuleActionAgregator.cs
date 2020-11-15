using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class RuleActionAgregator
    {
        List<IRuleRequster> rules = new List<IRuleRequster>();
        public void SetRules()
        {
            rules.Add(new MonitoringObjectAllUnitsPaged());
        }
        public void UpdateRulesValue(string token)
        {
            foreach (var item in rules)
            {
                item.IsActivated = true;
                item.Token = token;
                item.RequestNeedParameter();
            }
        }
        public Dictionary<string, Dictionary<string, string>[]> MakeRequest()
        {
            Dictionary<string,Dictionary<string, string>[]> responses = new Dictionary<string, Dictionary<string, string>[]>();
            foreach (var item in rules)
            {
                if (item.IsActivated)
                {
                    var resp = RequestSender.SendPostRequest(item.Token, item.UrlServer, item.SendParameter);
                    var responseAnswer = item.ResponseParser(resp);
                    responses.Add(item.Name,responseAnswer);
                }
            }
            return responses;
        }
    }
}
