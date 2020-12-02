using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    internal class FuelingDefuelingTable:ITable
    {
        internal string UnitId { get; set; }
        internal string BeginFuelVolumeL { get; set; }
        internal string EndFuelVolumeL { get; set; }
        internal string MinFuelVolumeL { get; set; }
        internal string MaxFuelVolumeL { get; set; }
        internal string FuelingTotalVolumeL { get; set; }
        internal string DefuelingTotalVolumeL { get; set; }
        internal string TotalFuelConsumptionL { get; set; }
        internal string FuelingCount { get; set; }
        internal string DefuelingCount { get; set; }
        internal string Period { get; set; }
        internal string OriginalPeriod { get; set; }
        internal string Timestamp { get; set; }
        internal string EventType { get; set; }
        internal string EventBeginFuelVolumeL { get; set; }
        internal string EventEndFuelVolumeL { get; set; }
        internal string OriginalBeginFuelVolumeL { get; set; }
        internal string OriginalEndFuelVolumeL { get; set; }
        internal string LocationLatitude { get; set; }
        internal string LocationLongitude { get; set; }
        public void SetUnitId(string value)
        {
            UnitId = value;
        }

        public FuelingDefuelingTable(string beginFuelVolumeL, string endFuelVolumeL, string minFuelVolumeL, string maxFuelVolumeL, string fuelingTotalVolumeL, string defuelingTotalVolumeL, string totalFuelConsumptionL, string fuelingCount, string defuelingCount, string period, string originalPeriod, string timestamp, string eventType, string eventBeginFuelVolumeL, string eventEndFuelVolumeL, string originalBeginFuelVolumeL, string originalEndFuelVolumeL, string locationLatitude, string locationLongitude)
        {
            BeginFuelVolumeL = beginFuelVolumeL;
            EndFuelVolumeL = endFuelVolumeL;
            MinFuelVolumeL = minFuelVolumeL;
            MaxFuelVolumeL = maxFuelVolumeL;
            FuelingTotalVolumeL = fuelingTotalVolumeL;
            DefuelingTotalVolumeL = defuelingTotalVolumeL;
            TotalFuelConsumptionL = totalFuelConsumptionL;
            FuelingCount = fuelingCount;
            DefuelingCount = defuelingCount;
            Period = period;
            OriginalPeriod = originalPeriod;
            Timestamp = timestamp;
            EventType = eventType;
            EventBeginFuelVolumeL = eventBeginFuelVolumeL;
            EventEndFuelVolumeL = eventEndFuelVolumeL;
            OriginalBeginFuelVolumeL = originalBeginFuelVolumeL;
            OriginalEndFuelVolumeL = originalEndFuelVolumeL;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
        }
    }
}
