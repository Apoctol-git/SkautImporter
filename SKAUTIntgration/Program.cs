using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SKAUTIntgration
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunProgram(args);
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.WriteExeption("Непредвиденное исключение: "+ ex.Message + " Программа остановлена");
                throw;
            }
        }
        static void RunProgram(string[] args)
        {
            var INI = GetINIManager(Environment.CurrentDirectory + @"\config.ini");
            var param = GetConfigParameter(INI);
            var baseURL = param[1];
            var loginreq = new LoginRequester();
            var token = Login(baseURL, loginreq, args[0], args[1]);
            loginreq.SetINI(INI);
            var period = GetDateTime(args[2], args[3], args[4]);
            var ruleRunner = new RuleActionAgregator();
            IFormater formater = new CSVFormater();
            ruleRunner.SetMonitoring(baseURL, period);
            ruleRunner.UpdateMonitoring(INI, token);
            ruleRunner.SaveMonitoringObject(formater, param[0]);
            ruleRunner.SetLoginRequester(loginreq);
            ruleRunner.SetRules(baseURL, period);
            ruleRunner.UpdateRulesValue(INI, token);
            ruleRunner.MakeRequestAndSave(formater, param[0], int.Parse(param[2]));
        }
        static string Login(string baseURL, LoginRequester loginreq, string login, string password ) // Верхнеуровневая процедура логирования
        {
            bool isRepeat = true;
            string result = null;
            while (isRepeat)
            {

                //Console.WriteLine("Введите логин");
                //var login = (string)Console.ReadLine();
                //Console.WriteLine("Введите пароль");
                //var password = (string)Console.ReadLine();
                var data = loginreq.Login(login, password, baseURL);
                if (data[0] == "true" && data[1] == "true")
                {
                    result = data[2];
                    isRepeat = false;
                }
                if (isRepeat)
                {
                    Console.WriteLine("Ошибка. Повторите ввод логина и пароля");
                }
            }
            return result;
        }
        static DateTime GetDateTime(string dayS,string mountS, string yearS)
        {
            int day=0;
            int mounth=0;
            int year=0;
            var daySuc = false;
            var mounthSuc = false;
            var yearSuc = false;
           // Console.WriteLine("Введите запрашиваемое число месяца");
            while (!daySuc)
            {
                daySuc = int.TryParse(dayS, out day);
                if (!daySuc)
                {
                    Console.WriteLine("Повторите ввод числа месяца");
                }
            }
            //Console.WriteLine("Введите запрашиваемый номер месяца");
            while (!mounthSuc)
            {
                mounthSuc = int.TryParse(mountS, out mounth);
                if (!mounthSuc)
                {
                    Console.WriteLine("Повторите ввод месяца");
                }
            }
            //Console.WriteLine("Введите запрашиваемый год");
            while (!yearSuc)
            {
                yearSuc = int.TryParse(yearS, out year);
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
                //Console.WriteLine("Нажмите люубую клавишу что бы закрыть программу");
                //Console.ReadKey();
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
            var compare = INI.GetPrivateString("CompareValue", "Value");
            string[] result = { rootCatalog, BaseURL, compare };
            return result;
        }
    }
}
