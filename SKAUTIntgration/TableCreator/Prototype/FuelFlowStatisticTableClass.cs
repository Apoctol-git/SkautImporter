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
        internal string SpicAnalogSensorValuePointTimestamp { get; set; }
        internal string SpicAnalogSensorValuePointValue { get; set; }

        public FuelFlowStatisticTableClass()
        {
            AddFieldRules("SensorNumber", (string value) => SensorNumber = value, true);
            AddFieldRules("SensorTitle", (string value) => SensorTitle = value, true);
            AddFieldRules("MovementConsumptionL", (string value) => MovementConsumptionL = value, true);
            AddFieldRules("EngineActiveWorkConsumptionL", (string value) => EngineActiveWorkConsumptionL = value, true);
            AddFieldRules("EngineIdleConsumptionL", (string value) => EngineIdleConsumptionL = value, true);
            AddFieldRules("TotalConsumptionVolumeL", (string value) => TotalConsumptionVolumeL = value, true);
            AddFieldRules("TotalConsumptionWeightKg", (string value) => TotalConsumptionWeightKg = value, true);
            AddFieldRules("Timestamp", (string value) => SpicAnalogSensorValuePointTimestamp = value, false);
            AddFieldRules("Value", (string value) => SpicAnalogSensorValuePointValue = value, false);
        }
    }
}
