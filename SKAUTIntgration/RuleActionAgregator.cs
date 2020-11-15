using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class RuleActionAgregator
    {
        readonly List<IRuleRequster> rules = new List<IRuleRequster>();
        public void SetRules(string baseURL)
        {
            rules.Add(new MonitoringObjectAllUnitsPaged(baseURL));
        }
        public void UpdateRulesValue(INIManager INI, string token)
        {
            foreach (var item in rules)
            {
                item.IsActivated = INI.GetPrivateString(item.Name, "IsActive") == "true"?true:false;
                item.TargetCatalog = INI.GetPrivateString(item.Name, "TargetPath");
                item.Token = token;
                item.RequestNeedParameter();
            }
        }
        public Dictionary<string[], Dictionary<string, string>[]> MakeRequest()
        {
            Dictionary<string[],Dictionary<string, string>[]> responses = new Dictionary<string[], Dictionary<string, string>[]>();
            foreach (var item in rules)
            {
                if (item.IsActivated)
                {
                    var resp = RequestSender.SendPostRequest(item.Token, item.UrlServer, item.SendParameter);
                    var responseAnswer = item.ResponseParser(resp);
                    string[] param = { item.Name, item.TargetCatalog };
                    responses.Add(param,responseAnswer);
                }
            }
            return responses;
        }
    }
}
