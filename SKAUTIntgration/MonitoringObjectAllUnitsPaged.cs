using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SKAUTIntgration
{
    class MonitoringObjectAllUnitsPaged: IRuleRequster
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string UrlServer {get;  set; }
        public bool IsActivated { get; set; }
        public string SendParameter { get; set; }
        
        private int countObject;

        public MonitoringObjectAllUnitsPaged()
        {
            Name = "MonitoringObjectS";
            UrlServer = @"http://spic.scout365.ru:8081/spic/units/rest/getAllUnitsPaged";
        }
        public void RequestNeedParameter()
        {
            SetCountObject();
            var serializer = new JavaScriptSerializer();
            SendParameter = serializer.Serialize(new { Offset = "0", Count = countObject });
        }
        public Dictionary<string, string>[] ResponseParser(string response) 
        {
            var objectArray = response.Split('{', '}', '[', ']');
            var itterator = 0;
            foreach (var item in objectArray)
            {
                if (item.Length>10)
                {
                    itterator++;
                }
            }
            Dictionary<string, string>[] resultArray = new Dictionary<string, string>[itterator];
            itterator = 0;
            foreach (var item in objectArray)
            {
                if (item.Length > 10)
                {
                    var resultElement = new Dictionary<string, string>();
                    var valueArray = item.Split(',');
                    foreach (var value in valueArray)
                    {
                        var workArr = value.Split(':');
                        workArr[0].Trim();
                        workArr[1].Trim();
                        resultElement.Add(workArr[0], workArr[1]);
                    }
                    resultArray[itterator] = resultElement;
                    itterator++;
                }
            }    
            return resultArray;
        }

        public void SetCountObject()
        {
            var url = @"http://spic.scout365.ru:8081/spic/units/rest/";
            this.countObject = int.Parse(RequestSender.SendGetRequest(Token, url));
        }
    }
}
