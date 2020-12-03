using System.Collections.Generic;
using SKAUTIntgration.TableCreator.Table;

namespace SKAUTIntgration.TableCreator
{
    internal class DiscreteSensorStatisticTableClass :BaseFieldFinder, IPrototype
    {
        List<string> Timestamp;
        List<string> Value;

        public DiscreteSensorStatisticTableClass()
        {
            Timestamp = new List<string>();
            Value = new List<string>();
            AddFieldRules("Timestamp", (string value) => Timestamp.Add(value));
            AddFieldRules("Value", (string value) => Value.Add(value));
        }
        public new List<ITable> GetTablesList()
        {
            var result = new List<ITable>();
            for (int i = 0; i < Timestamp.Count; i++)
            {
                result.Add(new DiscreteSensorStatisticTable(Timestamp[i], Value[i]));
            }
            return result;
        }
    }
}