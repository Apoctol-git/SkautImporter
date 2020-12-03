using SKAUTIntgration.TableCreator.Table;
using System.Collections.Generic;

namespace SKAUTIntgration.TableCreator
{
    internal class TrackPeriodsMileageStatisticTableClass :BaseFieldFinder, IPrototype
    {
        internal List<string> PeriodsMileageType { get; set; }
        internal List<string> PeriodsMileagePeriod { get; set; }
        internal List<string> PeriodsMileageMileageKm { get; set; }
        internal List<string> PeriodsMileageWorkTimeMileageKm { get; set; }
        internal List<string> PeriodsMileageAverageSpeedKmh { get; set; }
        internal List<string> PeriodsMileageMinSpeedKmh { get; set; }
        internal List<string> PeriodsMileageMaxSpeedKmh { get; set; }
        internal string MovementDuration { get; set; }
        internal string ParkingDuration { get; set; }
        internal string BreakDuration { get; set; }
        internal string TotalDuration { get; set; }
        internal string MovementMileageKm { get; set; }
        internal string BreakMileageKm { get; set; }
        internal string TotalMileageKm { get; set; }
        //internal string WorkTimeMileageKm { get; set; }
        //internal string MinSpeedKmh { get; set; }
        //internal string MaxSpeedKmh { get; set; }

        public TrackPeriodsMileageStatisticTableClass()
        {
            PeriodsMileageType = new List<string>();
            PeriodsMileagePeriod = new List<string>();
            PeriodsMileageMileageKm = new List<string>();
            PeriodsMileageWorkTimeMileageKm = new List<string>();
            PeriodsMileageAverageSpeedKmh = new List<string>();
            PeriodsMileageMinSpeedKmh = new List<string>();
            PeriodsMileageMaxSpeedKmh = new List<string>();
            AddFieldRules("Type", (string value) => PeriodsMileageType.Add(value));
            AddFieldRules("Period", (string value) => PeriodsMileagePeriod.Add(value));
            AddFieldRules("MileageKm", (string value) => PeriodsMileageMileageKm.Add(value));
            AddFieldRules("WorkTimeMileageKm", (string value) => PeriodsMileageWorkTimeMileageKm.Add(value));
            AddFieldRules("AverageSpeedKmh", (string value) => PeriodsMileageAverageSpeedKmh.Add(value));
            AddFieldRules("MinSpeedKmh", (string value) => PeriodsMileageMinSpeedKmh.Add(value));
            AddFieldRules("MaxSpeedKmh", (string value) => PeriodsMileageMaxSpeedKmh.Add(value));
            AddFieldRules("MovementDuration", (string value) => MovementDuration = value);
            AddFieldRules("ParkingDuration", (string value) => ParkingDuration = value);
            AddFieldRules("BreakDuration", (string value) => BreakDuration = value);
            AddFieldRules("TotalDuration", (string value) => TotalDuration = value);
            AddFieldRules("MovementMileageKm", (string value) => MovementMileageKm = value);
            AddFieldRules("BreakMileageKm", (string value) => BreakMileageKm = value);
            AddFieldRules("TotalMileageKm", (string value) => TotalMileageKm = value);
            //AddFieldRules("WorkTimeMileageKm", (string value) => WorkTimeMileageKm = value);
            //AddFieldRules("MinSpeedKmh", (string value) => MinSpeedKmh = value);
            //AddFieldRules("MaxSpeedKmh", (string value) => MaxSpeedKmh = value);
        }
        public new List<ITable> GetTablesList()
        {
            var result = new List<ITable>();
            for (int i = 0; i < PeriodsMileageType.Count; i++)
            {
                result.Add(new TrackPeriodsMileageStatisticTable(
                    PeriodsMileageType[i], PeriodsMileagePeriod[i], PeriodsMileageMileageKm[i],
                    PeriodsMileageWorkTimeMileageKm[i + 1], PeriodsMileageAverageSpeedKmh[i], PeriodsMileageMinSpeedKmh[i+1],
                    PeriodsMileageMaxSpeedKmh[i+1], MovementDuration, ParkingDuration, BreakDuration, TotalDuration,
                    MovementMileageKm, BreakMileageKm, TotalMileageKm, PeriodsMileageWorkTimeMileageKm[0], PeriodsMileageMinSpeedKmh[0],
                    PeriodsMileageMaxSpeedKmh[0]
                    ));
            }
            return result;
        }
    }
}