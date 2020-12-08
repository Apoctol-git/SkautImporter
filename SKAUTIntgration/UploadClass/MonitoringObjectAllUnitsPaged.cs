using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SKAUTIntgration
{
    public class MonitoringObjectAllUnitsPaged: IRuleRequster
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string UrlServer {get;  set; }
        public string TargetCatalog { get; set; }
        public bool IsActivated { get; set; }
        public DateTime Period { get; set; }
        public string SendParameter { get; set; }
        
        public List<string> unitsId { get; private set; }
        private int countObject;
        private string urlCount;

        public MonitoringObjectAllUnitsPaged(string baseURL)
        {
            Name = "MonitoringObject";
            UrlServer = baseURL +  @"/spic/units/rest/getAllUnitsPaged";
            urlCount = baseURL + @"/spic/units/rest/";
        }

        public MonitoringObjectAllUnitsPaged(string baseURL, DateTime period) : this(baseURL)
        {
            Name = "MonitoringObject";
            UrlServer = baseURL + @"/spic/units/rest/getAllUnitsPaged";
            urlCount = baseURL + @"/spic/units/rest/";
            unitsId = new List<string>();
            Period = period;
        }

        public void RequestNeedParameter(MonitoringObjectAllUnitsPaged rule)
        {
            SetCountObject();
            var serializer = new JavaScriptSerializer();
            SendParameter = serializer.Serialize(new { Offset = "0", Count = countObject });
            IsActivated = true;
            //if (!IsActivated) // Заглушка на случай, если мониторинги обновлять не надо, а запросить статистики надо.
            //{
            //    ResponseParser(RequestResultArray(1,1)["-1"]);
            //}
        }
        public List<List<XMLelement>> ResponseParser(string response)
        {
            //Dictionary<string, string> unitsAndTypes = new Dictionary<string, string>();
            var objectArray = response.Split('{', '}', '[', ']');
            List<List<XMLelement>> resultArray = new List<List<XMLelement>>();
            //List<string> resultArray = new List<string>();
            foreach (var item in objectArray)
            {
                if (item.Length > 10)
                {
                    var resultElement = new List<XMLelement>();
                    var valueArray = item.Split(',');
                    //string unitId = null;
                    //string unitTypeId = null;
                    foreach (var value in valueArray)
                    {
                        var workArr = value.Split(':');
                        if (workArr.Length == 1)
                        {
                            resultElement.Add(new XMLelement(GetUndoublequotesString(workArr[0]), null));
                        }
                        else
                        {
                            resultElement.Add(new XMLelement(GetUndoublequotesString(workArr[0]), GetUndoublequotesString(workArr[1])));
                        }
                        if (workArr[0] == "\"UnitId\"")
                        {
                            unitsId.Add(GetUndoublequotesString(workArr[1]));
                        }
                        //if (workArr[0] == "\"UnitTypeId\"")
                        //{
                        //    unitTypeId = workArr[1];
                        //}

                    }
                    //if (unitsAndTypes.Count < 10)
                    //{
                    //    unitsAndTypes.Add(unitId, unitTypeId);
                    //}
                    resultArray.Add(resultElement);
                }
            }
            //Program.UnitsAndTypes = unitsAndTypes;
            return resultArray;
        }
        
        //public List<List<XMLelement>> ResponseParser(string response) 
        //{
        //    Dictionary<string, string> unitsAndTypes = new Dictionary<string, string>();
        //    var objectArray = response.Split('{', '}', '[', ']');
        //    List<List<XMLelement>> resultArray = new List<List<XMLelement>>();
        //    foreach (var item in objectArray)
        //    {
        //        if (item.Length > 10)
        //        {
        //            var resultElement = new List<XMLelement>();
        //            var valueArray = item.Split(',');
        //            string unitId = null;
        //            string unitTypeId = null;
        //            foreach (var value in valueArray)
        //            {
        //                var workArr = value.Split(':');
        //                if (workArr.Length==1)
        //                {
        //                    resultElement.Add(new XMLelement(GetUndoublequotesString(workArr[0]),null));
        //                }
        //                else
        //                {
        //                    resultElement.Add(new XMLelement(GetUndoublequotesString(workArr[0]), GetUndoublequotesString(workArr[1])));
        //                }
        //                if (workArr[0] == "\"UnitId\"")
        //                {
        //                    unitId = workArr[1];
        //                }
        //                if (workArr[0] == "\"UnitTypeId\"")
        //                {
        //                    unitTypeId = workArr[1];
        //                }
                        
        //            }
        //            if (unitsAndTypes.Count <10)
        //            {
        //                unitsAndTypes.Add(unitId, unitTypeId);
        //            }
        //            resultArray.Add( resultElement);
        //            //itterator++;
        //        }
        //    }
        //    Program.UnitsAndTypes = unitsAndTypes;
        //    return resultArray;
        //}
        public Dictionary<string, string> RequestResultArray(int iterationNumber, int compare)
        {
            var result = new Dictionary<string, string>();
            var resp = RequestSender.SendPostRequest(Token, UrlServer, SendParameter);
            result.Add("-1", resp);
            return result;
        }
        public void SetCountObject()
        {
            countObject = int.Parse(RequestSender.SendGetRequest(Token, urlCount));
        }
        private string GetUndoublequotesString(string doublequotesString)
        {
            var workArray = doublequotesString.Split('"');
            return workArray.Length==1?workArray[0]: workArray[1];
        }
        private string GetStringFromArray(List<XMLelement> array)
        {
            string result = null;
            foreach (var item in array)
            {
                var workstring = item.Key + " : " + item.Value + ";";
                result += workstring;
            }
            return result;
        }
    }
}
