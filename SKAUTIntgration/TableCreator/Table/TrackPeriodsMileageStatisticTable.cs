using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    public class TrackPeriodsMileageStatisticTable:ITable
    {
        public string UnitId { get; set; }
        public string PeriodsMileageType { get; set; }
        public string PeriodsMileagePeriod { get; set; }
        public string PeriodsMileageMileageKm { get; set; }
        public string PeriodsMileageWorkTimeMileageKm { get; set; }
        public string PeriodsMileageAverageSpeedKmh { get; set; }
        public string PeriodsMileageMinSpeedKmh { get; set; }
        public string PeriodsMileageMaxSpeedKmh { get; set; }
        public string MovementDuration { get; set; }
        public string ParkingDuration { get; set; }
        public string BreakDuration { get; set; }
        public string TotalDuration { get; set; }
        public string MovementMileageKm { get; set; }
        public string BreakMileageKm { get; set; }
        public string TotalMileageKm { get; set; }
        public string WorkTimeMileageKm { get; set; }
        public string MinSpeedKmh { get; set; }
        public string MaxSpeedKmh { get; set; }

        public TrackPeriodsMileageStatisticTable(string periodsMileageType, string periodsMileagePeriod, string periodsMileageMileageKm, string periodsMileageWorkTimeMileageKm, string periodsMileageAverageSpeedKmh, string periodsMileageMinSpeedKmh, string periodsMileageMaxSpeedKmh, string movementDuration, string parkingDuration, string breakDuration, string totalDuration, string movementMileageKm, string breakMileageKm, string totalMileageKm, string workTimeMileageKm, string minSpeedKmh, string maxSpeedKmh)
        {
            PeriodsMileageType = periodsMileageType;
            PeriodsMileagePeriod = periodsMileagePeriod;
            PeriodsMileageMileageKm = periodsMileageMileageKm;
            PeriodsMileageWorkTimeMileageKm = periodsMileageWorkTimeMileageKm;
            PeriodsMileageAverageSpeedKmh = periodsMileageAverageSpeedKmh;
            PeriodsMileageMinSpeedKmh = periodsMileageMinSpeedKmh;
            PeriodsMileageMaxSpeedKmh = periodsMileageMaxSpeedKmh;
            MovementDuration = movementDuration;
            ParkingDuration = parkingDuration;
            BreakDuration = breakDuration;
            TotalDuration = totalDuration;
            MovementMileageKm = movementMileageKm;
            BreakMileageKm = breakMileageKm;
            TotalMileageKm = totalMileageKm;
            WorkTimeMileageKm = workTimeMileageKm;
            MinSpeedKmh = minSpeedKmh;
            MaxSpeedKmh = maxSpeedKmh;
        }
        public void SetUnitId(string value)
        {
            UnitId = value;
        }
    }
}
