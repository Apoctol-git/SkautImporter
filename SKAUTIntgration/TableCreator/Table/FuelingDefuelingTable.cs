using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    internal class FuelingDefuelingTable:ITable
    {
        public string UnitId { get; set; }
        public string BeginFuelVolumeL { get; set; }
        public string EndFuelVolumeL { get; set; }
        public string MinFuelVolumeL { get; set; }
        public string MaxFuelVolumeL { get; set; }
        public string FuelingTotalVolumeL { get; set; }
        public string DefuelingTotalVolumeL { get; set; }
        public string TotalFuelConsumptionL { get; set; }
        public string FuelingCount { get; set; }
        public string DefuelingCount { get; set; }
        public string Period { get; set; }
        public string OriginalPeriod { get; set; }
        public string Timestamp { get; set; }
        public string EventType { get; set; }
        public string EventBeginFuelVolumeL { get; set; }
        public string EventEndFuelVolumeL { get; set; }
        public string OriginalBeginFuelVolumeL { get; set; }
        public string OriginalEndFuelVolumeL { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
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
