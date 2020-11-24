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
        string urlLogin = @"/spic/auth/rest/login";
        
        public string[] Login(string login, string password, string baseURL)
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
            var responseJson = RequestSender.SendLoginRequest(baseURL + urlLogin, json);
            var array = responseJson.Split('"',':',','); //Разборка JSON ответа.
            string[] resultArray =  { array[9], array[13], array[18] }; // Возможно нужно будет переделать. Задать вопрос.
            return resultArray;
        }
    }
}
