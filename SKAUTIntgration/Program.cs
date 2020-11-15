using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SKAUTIntgration
{
    class Program
    {
        static string sessionToken;
        
        static void Main()
        {
            Login();
            //var baseURL = @"http://spic.scout365.ru:8081";
            var INI = GetINIManager(@"C:\Users\Apoctol\source\repos\SKAUTIntgration\SKAUTIntgration\bin\Debug\config.ini");
            var param = GetConfigParameter(INI);
            var baseURL = param[1];
            var ruleRunner = new RuleActionAgregator();
            ruleRunner.SetRules(baseURL);
            ruleRunner.UpdateRulesValue(INI, sessionToken);
            var xmlForm = ruleRunner.MakeRequest();
            XMLFormater.XMLSaver(param[0],xmlForm);
        }
        static void Login() // Верхнеуровневая процедура логирования
        {
            bool isRepeat = true;
            while (isRepeat)
            {
                var loginreq = new LoginRequester();
                Console.WriteLine("Введите логин");
                var login = (string)Console.ReadLine();
                Console.WriteLine("Введите пароль");
                var password = (string)Console.ReadLine();
                var data = loginreq.Login(login, password);
                if (data[0] == "true" && data[1] == "true")
                {
                    sessionToken = data[2];
                    isRepeat = false;
                }
            }

        }
        static INIManager GetINIManager(string path)
        {
            INIManager INI = new INIManager(path);
            return INI;
        }
        static string[] GetConfigParameter(INIManager INI)
        {
            var rootCatalog = INI.GetPrivateString("RootCatalog", "BasePath");
            var BaseURL = INI.GetPrivateString("BaseURL", "RootURL");
            string[] result = { rootCatalog, BaseURL };
            return result;
        }
    }
}
