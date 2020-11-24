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
        string Token { get; set; } // токен авторизация. Получается в классе LoginRequester
        string Name { get; set; } // Имя статистики которое указывается в названии папки и в XML документах
        string UrlServer { get; set; } // адрес на который ссылается запрос
        string TargetCatalog { get; set; }// каталог, в который складываются файлы с этого адреса
        bool IsActivated { get; set; } // параметр который считывается из конфиг файла. Отвечает за активность выгрузки данных
        //string SendParameter { get; set; } // здесь описываем JSON запроса пока убран как ненужный
        DateTime Period { get; set; } // Период запроса статистики
        List<List<XMLelement>> ResponseParser(string response); // Здесь должен быть метод, который разбивает JSON ответ на словарь из ключей и значений.
        void RequestNeedParameter();// Метод запрашивающий дополнительные сведения для запроса. По базе реализуется пустым
        Dictionary<string, string> RequestResultArray(); // Метод который отсылает запросы пачками на сервер. По одному за раз
    }
}
