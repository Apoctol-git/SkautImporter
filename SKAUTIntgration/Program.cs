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
        public static Dictionary<string, string> UnitsAndTypes = new Dictionary<string, string>();
        static void Main()
        {
            Login();
            var period = GetDateTime();
            //var baseURL = @"http://spic.scout365.ru:8081";
            var INI = GetINIManager(Environment.CurrentDirectory+@"\config.ini");
            var param = GetConfigParameter(INI);
            var baseURL = param[1];
            var ruleRunner = new RuleActionAgregator();
            IFormater formater = new CSVFormater();
            ruleRunner.SetRules(baseURL,period);
            ruleRunner.UpdateRulesValue(INI, sessionToken);
            var xmlForm = ruleRunner.MakeRequest();
            formater.Saver(param[0],xmlForm);
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
                if (isRepeat)
                {
                    Console.WriteLine("Ошибка. Повторите ввод логина и пароля");
                }
            }

        }
        static DateTime GetDateTime()
        {
            int day=0;
            int mounth=0;
            int year=0;
            var daySuc = false;
            var mounthSuc = false;
            var yearSuc = false;
            Console.WriteLine("Введите запрашиваемое число месяца");
            while (!daySuc)
            {
                daySuc = int.TryParse(Console.ReadLine(),out day);
                if (!daySuc)
                {
                    Console.WriteLine("Повторите ввод числа месяца");
                }
            }
            Console.WriteLine("Введите запрашиваемый номер месяца");
            while (!mounthSuc)
            {
                mounthSuc = int.TryParse(Console.ReadLine(),out mounth);
                if (!mounthSuc)
                {
                    Console.WriteLine("Повторите ввод месяца");
                }
            }
            Console.WriteLine("Введите запрашиваемый год");
            while (!yearSuc)
            {
                yearSuc = int.TryParse(Console.ReadLine(),out year);
                if (!yearSuc)
                {
                    Console.WriteLine("Повторите ввод года");
                }
            }
            try
            {
                return new DateTime(year, mounth, day);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Нажмите люубую клавишу что бы закрыть программу");
                Console.ReadKey();
                System.Environment.Exit(500);
                return DateTime.Now;
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
