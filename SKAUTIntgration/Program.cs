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
        static void Main(string[] args)
        {
            Login();
            var ruleRunner = new RuleActionAgregator();
            ruleRunner.SetRules();
            ruleRunner.UpdateRulesValue(sessionToken);
            var xmlForm = ruleRunner.MakeRequest();
            XMLFormater.XMLSaver(xmlForm);
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
    }
}
