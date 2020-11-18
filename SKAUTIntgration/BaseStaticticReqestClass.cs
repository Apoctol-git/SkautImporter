using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SKAUTIntgration
{
    public abstract class BaseStaticticReqestClass // Базовый класс для наследования статистик. 
    {
        /*
         Параметры которые нужны каждому запросу, что бы не копировать много раз.
             */
        public string Token { get; set; }
        public string Name { get; set; }
        public string UrlServer { get; set; }
        public string TargetCatalog { get; set; }
        public bool IsActivated { get; set; }
        public DateTime Period { get; set; }
        /*
         * Сессия запроса идёт в четыре этапа
         * Начало сессии
         * Добавление статистики в запрос
         * Построение статистик
         * Выгрузка статистики
         * Каждый запрос имеет свой url как ниже
         * 
         */
        private string urlStartStatSession = "/spic/StatisticsController/rest/StartStatisticsSession";
        private string addStatisticToRequest = null;
        private string urlBuildStatistic = "/spic/StatisticsController/rest/StartBuild";
        protected string getStatistics = null;
        private List<string> JSONparameterStart = new List<string>(); // список тел начала сессии
        protected List<string> JSONRunSession = new List<string>(); // Список ID запущенных сессий

        // Метод должен вызываться из дочернего класса, и компоновать конкретные Url котороые сейчас null
        public void SetAllUrl (string baseUrl, string UrlServer)
        {
            var temp = baseUrl + urlStartStatSession;
            urlStartStatSession = temp;
            temp = baseUrl + urlBuildStatistic;
            urlBuildStatistic = temp;
            addStatisticToRequest =baseUrl + "/spic/" + UrlServer + "/rest/AddStatisticsRequest";
            getStatistics = baseUrl+"/spic/" + UrlServer + "/rest/GetStatistics";
        }
        //подготовка тела запроса в Json который отправляется в открытие сессии статистик
        public void JSONprepare(DateTime periodStart) //ВНИМАНИЕ!!!!! Стоит временная заглушка на типе объекта. Снять при необходимости!
        {
            var serializer = new JavaScriptSerializer();
            var begin = (periodStart - new DateTime(1970, 1, 1)).TotalMilliseconds;
            var end = (periodStart.AddDays(1) - new DateTime(1970, 1, 1)).TotalMilliseconds;
            foreach (var item in Program.UnitsAndTypes)
            {
                var json= serializer.Serialize(new
                {
                    Period = new
                    {
                        Begin = "/Date("+begin+")/",
                        End = "/Date(" + end + ")/"
                    },
                    TargetObject = new
                    {
                        ObjectTypeId = "0F1E3A4A-88F5-4166-9BE8-76033DD85D08",//item.Value,
                        ObjectId = item.Key
                    }
                });
                JSONparameterStart.Add(json);
            }
        }
        //Метод подготавливает все статистики для выгрузки.
        public void PrepareStatistic(string token)
        {
            foreach (var item in JSONparameterStart)
            {
                var statisticcSessionRecponse = RequestSender.SendPostRequest(token, urlStartStatSession, item);
                string statisticSessionId = GetSessionStaticticId(statisticcSessionRecponse);
                var ser = new JavaScriptSerializer();
                var json = ser.Serialize(new { StatisticsSessionId  = statisticSessionId });
                JSONRunSession.Add(json);
                var addedStatistic = RequestSender.SendPostRequest(token, addStatisticToRequest, json);
                var buildedStatistic = RequestSender.SendPostRequest(token, urlBuildStatistic, json);
            }
        }

        public List<List<XMLelement>> ResponseParser(string response)
        {
            List<List<XMLelement>> resultArray = new List<List<XMLelement>>();
            var objectArray = SeparateResponse(response.Split('{', '}', '[', ']'));
            var resultElement = new List<XMLelement>();
            foreach (var item in objectArray)
            {
                var valueArray = item.Split(',');
                foreach (var value in valueArray)
                {
                    if (value!="")
                    {
                        try
                        {
                            var workArr = value.Split(':');
                            resultElement.Add(new XMLelement(workArr[0], workArr[1]));
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                resultArray.Add(resultElement);
            }
            return resultArray;
        }
        private string GetSessionStaticticId(string response)
        {
            var resultArray = response.Split(':', ',', '}','"');
            return resultArray[17];
        }
        private List<string> SeparateResponse(string[] objectArray)
        {
            List<string> workArray = new List<string>();
            var isFind = false;
            foreach (var item in objectArray)
            {
                if (item ==",\"Statistics\":" || isFind)
                {
                    isFind = true;
                    if (item != ",\"Statistics\":")
                    {
                        workArray.Add(item);
                    }
                    
                }
            }
            return workArray;
        }
    }
}
