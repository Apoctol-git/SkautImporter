using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    class MonitoringObjectAllUnitsPaged: IRuleRequster
    {
        public string Token { get; set; }
        public string UrlServer { get; set; }
        public bool IsActivated { get; set; }
        public Dictionary<string, string> SendParameter { get; set; }
        public Dictionary<string, string> ResponseParameter { get; set; }
        private int countObject;
        public void SetCountObject()
        {
            var url = @"http://spic.scout365.ru:8081/spic/units/rest/";
            RequestSender.SendGetRequest(Token, url);
        }
        //public string UrlServer 
        ////    ()
        ////{
        ////    return @"http://spic.scout365.ru:8081/spic/units/rest/getAllUnitsPaged";
        ////}

        //public bool IsActivated()
        //{
        //    return true;
        //}
        //public Dictionary<string, string> SendParameter()
        //{
        //    var result = new Dictionary<string, string>();
        //    return result;
        //}
        //public Dictionary<string, string> ResponseParameter()
        //{
        //    var result = new Dictionary<string, string>();
        //    return result;
        //}
    }
}
