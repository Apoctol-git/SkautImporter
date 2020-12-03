using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    public class DiscreteSensorStatisticTable: ITable
    {
        public string UnitId { get; set; }
        public string Timestamp { get; set; }
        public string Value { get; set; }
        public DiscreteSensorStatisticTable(string timestamp, string value)
        {
            Timestamp = timestamp;
            Value = value;
        }
        public void SetUnitId(string value)
        {
            UnitId = value;
        }
    }
}
