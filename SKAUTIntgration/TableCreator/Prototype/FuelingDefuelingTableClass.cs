using SKAUTIntgration.TableCreator.Table;
using System.Collections.Generic;

namespace SKAUTIntgration.TableCreator
{
    internal class FuelingDefuelingTableClass :BaseFieldFinder, IPrototype
    {
        internal List<string> BeginFuelVolumeL { get; set; }
        internal List<string> EndFuelVolumeL { get; set; }
        internal string MinFuelVolumeL { get; set; }
        internal string MaxFuelVolumeL { get; set; }
        internal string FuelingTotalVolumeL { get; set; }
        internal string DefuelingTotalVolumeL { get; set; }
        internal string TotalFuelConsumptionL { get; set; }
        internal string FuelingCount { get; set; }
        internal string DefuelingCount { get; set; }

        internal List<string> Period { get; set; }

        internal List<string> OriginalPeriod { get; set; }

        internal List<string> Timestamp { get; set; }

        internal List<string> EventType { get; set; }

        //internal string BeginFuelVolumeL

        //internal string EndFuelVolumeL

        internal List<string> OriginalBeginFuelVolumeL { get; set; }

        internal List<string> OriginalEndFuelVolumeL { get; set; }

        internal List<string> LocationLatitude { get; set; }
        internal List<string> LocationLongitude { get; set; }
        public FuelingDefuelingTableClass()
        {
            BeginFuelVolumeL = new List<string>();
            EndFuelVolumeL = new List<string>();
            Period = new List<string>();
            OriginalPeriod = new List<string>();
            Timestamp = new List<string>();
            EventType = new List<string>();
            OriginalBeginFuelVolumeL = new List<string>();
            OriginalEndFuelVolumeL = new List<string>();
            LocationLatitude = new List<string>();
            LocationLongitude = new List<string>();
            //________________________________________________________________
            AddFieldRules("BeginFuelVolumeL", (string value) => BeginFuelVolumeL.Add(value));
            AddFieldRules("EndFuelVolumeL", (string value) => EndFuelVolumeL.Add(value));
            AddFieldRules("MinFuelVolumeL", (string value) => MinFuelVolumeL = value);
            AddFieldRules("MaxFuelVolumeL", (string value) => MaxFuelVolumeL = value);
            AddFieldRules("FuelingTotalVolumeL", (string value) => FuelingTotalVolumeL = value);
            AddFieldRules("DefuelingTotalVolumeL", (string value) => DefuelingTotalVolumeL = value);
            AddFieldRules("TotalFuelConsumptionL", (string value) => TotalFuelConsumptionL = value);
            AddFieldRules("FuelingCount", (string value) => FuelingCount = value);
            AddFieldRules("DefuelingCount", (string value) => DefuelingCount = value);
            AddFieldRules("Period", (string value) => Period.Add(value));
            AddFieldRules("OriginalPeriod", (string value) => OriginalPeriod.Add(value));
            AddFieldRules("Timestamp", (string value) => Timestamp.Add(value));
            AddFieldRules("EventType", (string value) => EventType.Add(value));
            AddFieldRules("OriginalBeginFuelVolumeL", (string value) => OriginalBeginFuelVolumeL.Add(value));
            AddFieldRules("OriginalEndFuelVolumeL", (string value) => OriginalEndFuelVolumeL.Add(value));
            AddFieldRules("Latitude", (string value) => LocationLatitude.Add(value));
            AddFieldRules("Longitude", (string value) => LocationLongitude.Add(value));
        }
        public new List<ITable> GetTablesList()
        {
            var result = new List<ITable>();
            for (int i = 0; i < Period.Count; i++)
            {
                result.Add(new FuelingDefuelingTable(BeginFuelVolumeL[0],EndFuelVolumeL[0],MinFuelVolumeL,MaxFuelVolumeL,FuelingTotalVolumeL, 
                    DefuelingTotalVolumeL,TotalFuelConsumptionL, FuelingCount, DefuelingCount, Period[i], OriginalPeriod[i], Timestamp[i],
                    EventType[i],BeginFuelVolumeL[i+1], EndFuelVolumeL[i+1],
                    OriginalBeginFuelVolumeL[i], OriginalEndFuelVolumeL[i],LocationLatitude[i],LocationLongitude[i]));
            }
            return result;
        }
    }
}