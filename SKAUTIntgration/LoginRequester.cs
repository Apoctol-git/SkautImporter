using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SKAUTIntgration
{
    class LoginRequester
    {
        string url = @"http://spic.scout365.ru:8081/spic/auth/rest/login";
        
        public string[] Login(string login, string password)
        {
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(new
            {
                Login = login,
                Password = password,
                TimeZoneOlsonId = "Europe/Moscow",
                CultureName = "ru-ru",
                UiCulterName = "ru-ru"
            });
            var responseJson = RequestSender.SendLoginRequest(url, json);
            var array = responseJson.Split('"',':',','); //Разборка JSON ответа.
            string[] resultArray =  { array[9], array[13], array[18] }; // Возможно нужно будет переделать. Задать вопрос.
            return resultArray;
        }
    }
}
