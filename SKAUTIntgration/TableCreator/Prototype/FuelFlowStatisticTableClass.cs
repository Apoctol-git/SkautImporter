using SKAUTIntgration.TableCreator.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator
{
    internal class FuelFlowStatisticTableClass: BaseFieldFinder, IPrototype
    {
        internal string SensorNumber { get; set; }

        internal string SensorTitle { get; set; }

        internal string MovementConsumptionL { get; set; }

        internal string EngineActiveWorkConsumptionL { get; set; }

        internal string EngineIdleConsumptionL { get; set; }

        internal string TotalConsumptionVolumeL { get; set; }

        internal string TotalConsumptionWeightKg { get; set; }
        internal List<string> SpicAnalogSensorValuePointTimestamp { get; set; }
        internal List<string> SpicAnalogSensorValuePointValue { get; set; }

        public FuelFlowStatisticTableClass()
        {
            SpicAnalogSensorValuePointTimestamp = new List<string>();
            SpicAnalogSensorValuePointValue = new List<string>();
            AddFieldRules("SensorNumber", (string value) => SensorNumber = value);
            AddFieldRules("SensorTitle", (string value) => SensorTitle = value);
            AddFieldRules("MovementConsumptionL", (string value) => MovementConsumptionL = value);
            AddFieldRules("EngineActiveWorkConsumptionL", (string value) => EngineActiveWorkConsumptionL = value);
            AddFieldRules("EngineIdleConsumptionL", (string value) => EngineIdleConsumptionL = value);
            AddFieldRules("TotalConsumptionVolumeL", (string value) => TotalConsumptionVolumeL = value);
            AddFieldRules("TotalConsumptionWeightKg", (string value) => TotalConsumptionWeightKg = value);
            AddFieldRules("Timestamp", (string value) => SpicAnalogSensorValuePointTimestamp.Add(value));
            AddFieldRules("Value", (string value) => SpicAnalogSensorValuePointValue.Add(value));
        }
        public new List<ITable> GetTablesList()
        {
            var result = new List<ITable>();
            for (int i = 0; i < SpicAnalogSensorValuePointValue.Count; i++)
            {
                result.Add(new FuelFlowStatisticTable(SensorNumber, SensorTitle,
                    MovementConsumptionL, EngineActiveWorkConsumptionL, EngineIdleConsumptionL,
                    TotalConsumptionVolumeL, TotalConsumptionWeightKg, SpicAnalogSensorValuePointTimestamp[i], SpicAnalogSensorValuePointValue[i]));
            }
            return result;
        }
    }
}
