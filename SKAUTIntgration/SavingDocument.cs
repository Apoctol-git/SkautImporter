using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration
{
    public  class SavingDocument
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public List<List<XMLelement>> XMLElevents { get; private set; }

        public SavingDocument(string name, string path, List<List<XMLelement>> xMLElevents)
        {
            Name = name;
            Path = path;
            XMLElevents = xMLElevents;
        }
    }
}
