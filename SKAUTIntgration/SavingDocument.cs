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
        public DateTime Period { get; private set; }
        public string UnitId { get; private set; }
        public string Path { get; private set; }
        public List<List<XMLelement>> SavingElevents { get; private set; }

 
        public SavingDocument(string name, DateTime period, string unitId, string path, List<List<XMLelement>> savingElevents)
        {
            Name = name;
            Period = period;
            UnitId = unitId;
            Path = path;
            SavingElevents = savingElevents;
        }
    }
}
