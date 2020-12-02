using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    class TrackPeriodsMileageStatisticTable:ITable
    {
        internal string UnitId { get; set; }
        internal string PeriodsMileageType { get; set; }
        internal string PeriodsMileagePeriod { get; set; }
        internal string PeriodsMileageMileageKm { get; set; }
        internal string PeriodsMileageWorkTimeMileageKm { get; set; }
        internal string PeriodsMileageAverageSpeedKmh { get; set; }
        internal string PeriodsMileageMinSpeedKmh { get; set; }
        internal string PeriodsMileageMaxSpeedKmh { get; set; }
        internal string MovementDuration { get; set; }
        internal string ParkingDuration { get; set; }
        internal string BreakDuration { get; set; }
        internal string TotalDuration { get; set; }
        internal string MovementMileageKm { get; set; }
        internal string BreakMileageKm { get; set; }
        internal string TotalMileageKm { get; set; }
        internal string WorkTimeMileageKm { get; set; }
        internal string MinSpeedKmh { get; set; }
        internal string MaxSpeedKmh { get; set; }

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
