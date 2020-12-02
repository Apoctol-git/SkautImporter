using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    internal class FuelFlowStatisticTable:ITable
    {
        internal string UnitId { get; set; }
        internal string SensorNumber { get; set; }
        internal string SensorTitle { get; set; }
        internal string MovementConsumptionL { get; set; }
        internal string EngineActiveWorkConsumptionL { get; set; }
        internal string EngineIdleConsumptionL { get; set; }
        internal string TotalConsumptionVolumeL { get; set; }
        internal string TotalConsumptionWeightKg { get; set; }
        internal string SpicAnalogSensorValuePointTimestamp { get; set; }
        internal string SpicAnalogSensorValuePointValue { get; set; }
        public void SetUnitId(string value)
        {
            UnitId = value;
        }

        public FuelFlowStatisticTable(string sensorNumber, string sensorTitle, string movementConsumptionL, string engineActiveWorkConsumptionL, string engineIdleConsumptionL, string totalConsumptionVolumeL, string totalConsumptionWeightKg, string spicAnalogSensorValuePointTimestamp, string spicAnalogSensorValuePointValue)
        {
            SensorNumber = sensorNumber;
            SensorTitle = sensorTitle;
            MovementConsumptionL = movementConsumptionL;
            EngineActiveWorkConsumptionL = engineActiveWorkConsumptionL;
            EngineIdleConsumptionL = engineIdleConsumptionL;
            TotalConsumptionVolumeL = totalConsumptionVolumeL;
            TotalConsumptionWeightKg = totalConsumptionWeightKg;
            SpicAnalogSensorValuePointTimestamp = spicAnalogSensorValuePointTimestamp;
            SpicAnalogSensorValuePointValue = spicAnalogSensorValuePointValue;
        }
    }
}
