using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    public class XMLelement
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public XMLelement(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
