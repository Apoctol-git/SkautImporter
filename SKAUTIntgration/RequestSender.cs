using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace SKAUTIntgration
{
    public class RequestSender
    {
        
        static public string SendGetRequest(string token, string url)
        {
            using (var request = new HttpRequest())
            {
                request.UserAgent = "";
                request.AddHeader("ScoutAuthorization", token);
                string content = request.Get(url).ToString();
                return content;
            }
        }
        static public string SendPostRequest(string token, string url, string json)
        {
            using (var request = new HttpRequest())
            {
                try
                {
                    request.UserAgent = "";
                    request.AddHeader("ScoutAuthorization", token);
                    string content = request.Post(url,json, "application/json").ToString();
                    return content;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Нажмите люубую клавишу что бы закрыть программу");
                    Console.ReadKey();
                    System.Environment.Exit(500);
                    return null;
                }

            }
        }
        static public string SendLoginRequest(string url, string loginData)
        {
            using (var request = new HttpRequest())
            {
                request.UserAgent = "";
                string content = request.Post(url, loginData, "application/json").ToString();
                return content;
            }
        }
    }
}
