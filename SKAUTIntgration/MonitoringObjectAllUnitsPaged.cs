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
        public string TargetCatalog { get; set; }
        public bool IsActivated { get; set; }
        public DateTime Period { get; set; }
        public string SendParameter { get; set; }
        
        private int countObject;
        private string urlCount;

        public MonitoringObjectAllUnitsPaged(string baseURL)
        {
            Name = "MonitoringObject";
            UrlServer = baseURL +  @"/spic/units/rest/getAllUnitsPaged";
            urlCount = baseURL + @"/spic/units/rest/";
        }
        public void RequestNeedParameter()
        {
            SetCountObject();
            var serializer = new JavaScriptSerializer();
            SendParameter = serializer.Serialize(new { Offset = "0", Count = countObject });
            if (!IsActivated) // Заглушка на случай, если мониторинги обновлять не надо, а запросить статистики надо.
            {
                ResponseParser(RequestResultArray()["0"]);
            }
        }
        public List<List<XMLelement>> ResponseParser(string response) 
        {
            Dictionary<string, string> unitsAndTypes = new Dictionary<string, string>();
            var objectArray = response.Split('{', '}', '[', ']');
            //var itterator = 0;
            //foreach (var item in objectArray)
            //{
            //    if (item.Length>10)
            //    {
            //        itterator++;
            //    }
            //}
            List<List<XMLelement>> resultArray = new List<List<XMLelement>>();
            //itterator = 0;
            foreach (var item in objectArray)
            {
                if (item.Length > 10)
                {
                    var resultElement = new List<XMLelement>();
                    var valueArray = item.Split(',');
                    string unitId = null;
                    string unitTypeId = null;
                    foreach (var value in valueArray)
                    {
                        var workArr = value.Split(':');
                        if (workArr.Length==1)
                        {
                            resultElement.Add(new XMLelement(workArr[0],null));
                        }
                        else
                        {
                            resultElement.Add(new XMLelement(workArr[0], workArr[1]));
                        }
                        if (workArr[0] == "\"UnitId\"")
                        {
                            unitId = workArr[1];
                        }
                        if (workArr[0] == "\"UnitTypeId\"")
                        {
                            unitTypeId = workArr[1];
                        }
                        
                    }
                    unitsAndTypes.Add(unitId, unitTypeId);
                    resultArray.Add( resultElement);
                    //itterator++;
                }
            }
            Program.UnitsAndTypes = unitsAndTypes;
            return resultArray;
        }
        public Dictionary<string, string> RequestResultArray()
        {
            var result = new Dictionary<string, string>();
            var resp = RequestSender.SendPostRequest(Token, UrlServer, SendParameter);
            result.Add("0", resp);
            return result;
        }
        public void SetCountObject()
        {
             countObject = int.Parse(RequestSender.SendGetRequest(Token, urlCount));
        }
    }
}
