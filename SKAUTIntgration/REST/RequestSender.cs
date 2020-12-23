using SKAUTIntgration.REST;
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
        //static string proxyUrl;
        //static int proxyPort;
        //static string proxyUserName;
        //static string proxyPassword;
        static Proxy proxy;
        static bool IsProxyActivated =false;
        static public void SetProxy (string proxyUrl, int proxyPort, string proxyUserName, string proxyPassword)
        {
            //RequestSender.proxyUrl = proxyUrl;
            //RequestSender.proxyPort = proxyPort;
            //RequestSender.proxyUserName = proxyUserName;
            //RequestSender.proxyPassword = proxyPassword;
            proxy = new Proxy(0, proxyUrl, proxyPort, proxyUserName, proxyPassword);
            IsProxyActivated = true;
        }
        static public string GetRequest(string token, string url)
        {
            using (var request = new HttpRequest())
            {
               
                if (IsProxyActivated)
                {
                    request.Proxy = proxy;
                }
                request.UserAgent = "";
                request.AddHeader("ScoutAuthorization", token);
                string content = request.Get(url).ToString();
                return content;
            }
        }
        static public string SendGetRequest(string token, string url)
        {
            try
            {
               return GetRequest(token, url);
            }
            catch (HttpException)
            {
                return ResendGetRequest(token, url, 1);
            }
        }
        static private string ResendGetRequest(string token, string url, int iteration )
        {
            try
            {
                return GetRequest(token, url);
            }
            catch (HttpException)
            {

                throw;
            }
        }
        static public string PostRequest(string token, string url, string json)
        {
            using (var request = new HttpRequest())
            {
                //try
                //{
                if (IsProxyActivated)
                {
                    request.Proxy = proxy;
                }
                request.UserAgent = "";
                request.AddHeader("ScoutAuthorization", token);
                string content = request.Post(url,json, "application/json").ToString();
                return content;
                //}
                //catch (Exception ex)
                //{

                //    Console.WriteLine(ex.Message);
                //    //Console.WriteLine("Нажмите люубую клавишу что бы закрыть программу");
                //    //Console.ReadKey();
                //    System.Environment.Exit(500);
                //    return null;
                //}

            }
        }
        static public string SendPostRequest(string token, string url, string json)
        {
            try
            {
                return PostRequest(token, url, json);
            }
            catch (HttpException)
            {
                return ResendPostRequest(token, url, json, 1);
            }
        }
        static private string ResendPostRequest(string token, string url, string json, int iteration)
        {
            try
            {
                return PostRequest(token, url, json);
            }
            catch (HttpException)
            {

                throw;
            }
        }
        static public string SendLoginRequest(string url, string loginData)
        {
            using (var request = new HttpRequest())
            {
                if (IsProxyActivated)
                {
                    request.Proxy = proxy;
                    //request.Proxy.Host = proxyUrl;
                    //request.Proxy.Port = proxyPort;
                    //request.Proxy.Username = proxyUserName;
                    //request.Proxy.Password = proxyPassword;
                }
                request.UserAgent = "";
                string content = request.Post(url, loginData, "application/json").ToString();
                return content;
            }
        }
    }
}
