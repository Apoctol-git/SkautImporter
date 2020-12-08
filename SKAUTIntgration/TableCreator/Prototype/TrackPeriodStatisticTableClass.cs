using System.Collections.Generic;

namespace SKAUTIntgration.TableCreator
{
    internal class TrackPeriodStatisticTableClass :BaseFieldFinder, IPrototype
    {
        //internal List<string> SpicTrackPeriodType { get; set; }
        //internal List<string> SpicTrackPeriodTime { get; set; }
        //internal List<string> SpicTrackRecoilTime { get; set; }

        //public TrackPeriodStatisticTableClass()
        //{
        //    SpicTrackPeriodType = new List<string>();
        //    SpicTrackPeriodTime = new List<string>();
        //    SpicTrackRecoilTime = new List<string>();
        //    AddFieldRules("Type", (string value) => SpicTrackPeriodType.Add(value));
        //    AddFieldRules("Period", (string value) => SpicTrackPeriodTime.Add(value));
        //    AddFieldRules("MileageKm", (string value) => SpicTrackRecoilTime.Add(value));

        //}
        //public new List<ITable> GetTablesList()
        //{
        //    var result = new List<ITable>();
        //    for (int i = 0; i < PeriodsMileageType.Count; i++)
        //    {
        //        result.Add(new TrackPeriodsMileageStatisticTable(
        //            PeriodsMileageType[i], PeriodsMileagePeriod[i], PeriodsMileageMileageKm[i],
        //            PeriodsMileageWorkTimeMileageKm[i + 1], PeriodsMileageAverageSpeedKmh[i], PeriodsMileageMinSpeedKmh[i + 1],
        //            PeriodsMileageMaxSpeedKmh[i + 1], MovementDuration, ParkingDuration, BreakDuration, TotalDuration,
        //            MovementMileageKm, BreakMileageKm, TotalMileageKm, PeriodsMileageWorkTimeMileageKm[0], PeriodsMileageMinSpeedKmh[0],
        //            PeriodsMileageMaxSpeedKmh[0]
        //            ));
        //    }
        //    return result;
        //}
    }
}