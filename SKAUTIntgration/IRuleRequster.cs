using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    //Интерфейс для работы с запросами после логирования. Каждый класс-запрос должен реализовывать интерфейс
    interface IRuleRequster
    {
        string Token { get; set; }
        string UrlServer { get; set; }
        bool IsActivated { get; set; }
        Dictionary<string, string> SendParameter { get; set; }
        Dictionary<string, string> ResponseParameter { get; set; }
    }
}
