﻿using CsvHelper;
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
        protected List<string> unitsId;
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
        private List<XMLelement> JSONparameterStart = new List <XMLelement> (); // список тел начала сессии
        protected List<XMLelement> JSONRunSession = new List<XMLelement>(); // Список ID запущенных сессий

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
            foreach (var item in unitsId)
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
                        ObjectId = item
                    }
                });
                JSONparameterStart.Add(new XMLelement(item,json));
            }
        }
        //Метод подготавливает все статистики для выгрузки.

        public virtual string StartStatisticSession(string token, string json)
        {
            var statisticcSessionRecponse = RequestSender.SendPostRequest(token, urlStartStatSession, json);
            return statisticcSessionRecponse;
        }
        public virtual string AddStatistic (string token, string json)
        {
            var res =  RequestSender.SendPostRequest(token, addStatisticToRequest, json);
            return res;
        }
        public virtual string BuildStatistic(string token, string json)
        {
            var res = RequestSender.SendPostRequest(token, urlBuildStatistic, json);
            return res;
        }
        public Dictionary<string, string> RequestResultArray(int iterationNumber, int compare)
        {
            PrepairParameters(iterationNumber, compare);
            
            //foreach (var item in JSONRunSession)
            //{
  
            //}
            return GetResponseArray(iterationNumber,compare);
        }
        
        public List<string> ResponseParser(string response)
        {
            List<string> resultArray = new List<string>();
            var objectArray = SeparateResponse(response.Split('{', '}', '[', ']'));
            var resultElement = new List<XMLelement>();
            foreach (var item in objectArray)
            {
                var valueArray = item.Split(',');
                foreach (var value in valueArray)
                {
                    if (value != "")
                    {
                        try
                        {
                            var workArr = value.Split(':');
                            if (workArr[1].Contains("Date"))
                            {
                                var milisec = long.Parse(SepareteDateTime(GetUndoublequotesString(workArr[1])));
                                workArr[1] = CountDateTime(milisec).ToShortDateString() + " " + CountDateTime(milisec).ToShortTimeString();
                            }
                            resultElement.Add(new XMLelement(GetUndoublequotesString(workArr[0]), GetUndoublequotesString(workArr[1])));
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                resultArray.Add(GetStringFromArray(resultElement));
            }
            return resultArray;
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
        
        private void PrepairParameters(int iterationNumber, int compare)
        {
            //JSONprepare(Period);
            for (int i = iterationNumber * compare; i < (iterationNumber + 1) * compare; i++)
            {
                PrepareStatistic(Token, JSONparameterStart[i]);
            }

        }
        private void PrepareStatistic(string token, XMLelement item)
        {
            //foreach (var item in JSONparameterStart)
            //{
                var statisticcSessionRecponse = StartStatisticSession(token, item.Value);
                string statisticSessionId = GetSessionStaticticId(statisticcSessionRecponse);
                var ser = new JavaScriptSerializer();
                var json = ser.Serialize(new { StatisticsSessionId = statisticSessionId });
                JSONRunSession.Add(new XMLelement(item.Key, json));
                var addedStatistic = AddStatistic(token, json);
                var buildedStatistic = BuildStatistic(token, json);
            //}
        }
        private Dictionary<string, string> GetResponseArray(int iterationNumber, int compare)
        {
            var result = new Dictionary<string, string>();
            for (int i = iterationNumber * compare; i < (iterationNumber + 1) * compare; i++)
            {
                var item = JSONRunSession[i];
                result.Add(item.Key, RequestSender.SendPostRequest(Token, getStatistics, item.Value));
            }
            return result;
        }
        private string GetUndoublequotesString(string doublequotesString)
        {
            var workArray = doublequotesString.Split('"');
            return workArray.Length == 1 ? workArray[0] : workArray[1];
        }
        private string SepareteDateTime(string JSONdt)
        {
            return JSONdt.Split('(', ')', '+')[1];
        }
        private DateTime CountDateTime(long milisec)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(milisec);
        }

    }
}
