using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    internal class FuelFlowStatisticTable:ITable
    {
        public string UnitId { get; set; }
        public string SensorNumber { get; set; }
        public string SensorTitle { get; set; }
        public string MovementConsumptionL { get; set; }
        public string EngineActiveWorkConsumptionL { get; set; }
        public string EngineIdleConsumptionL { get; set; }
        public string TotalConsumptionVolumeL { get; set; }
        public string TotalConsumptionWeightKg { get; set; }
        public string SpicAnalogSensorValuePointTimestamp { get; set; }
        public string SpicAnalogSensorValuePointValue { get; set; }
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
