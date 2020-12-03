using SKAUTIntgration.TableCreator.Table;
using System.Collections.Generic;

namespace SKAUTIntgration.TableCreator
{
     class NavigationValidationStatisticTableClass :BaseFieldFinder, IPrototype
    {
        internal string ValidPointsCount { get; set; }
        internal string InvalidPointsCount { get; set; }
        internal List<string> PointsTimestamp { get; set; }
        internal List<string> NavigationPointsLocationLatitude { get; set; }
        internal List<string> NavigationPointsLocationLongitude { get; set; }
        internal List<string> NavigationPointsAltitudeMeters { get; set; }
        internal List<string> NavigationPointsAngle { get; set; }
        internal List<string> NavigationPointsSatellitesCount { get; set; }
        internal List<string> NavigationSpeed { get; set; }
        internal List<string> NavigationNavigationSystemType { get; set; }
        internal List<string> NavigationHardwareValidation { get; set; }
        internal List<string> PointsIsNavigationValid { get; set; }
        public NavigationValidationStatisticTableClass()
        {
            PointsTimestamp = new List<string>();
            NavigationPointsLocationLatitude = new List<string>();
            NavigationPointsLocationLongitude = new List<string>();
            NavigationPointsAltitudeMeters = new List<string>();
            NavigationPointsAngle = new List<string>();
            NavigationPointsSatellitesCount = new List<string>();
            NavigationSpeed = new List<string>();
            NavigationNavigationSystemType = new List<string>();
            NavigationHardwareValidation = new List<string>();
            PointsIsNavigationValid = new List<string>();
            AddFieldRules("ValidPointsCount", (string value) => ValidPointsCount = value);
            AddFieldRules("InvalidPointsCount", (string value) => InvalidPointsCount = value);
            AddFieldRules("Timestamp", (string value) => PointsTimestamp.Add(value));
            AddFieldRules("Latitude", (string value) => NavigationPointsLocationLatitude.Add(value));
            AddFieldRules("Longitude", (string value) => NavigationPointsLocationLongitude.Add(value));
            AddFieldRules("AltitudeMeters", (string value) => NavigationPointsAltitudeMeters.Add(value));
            AddFieldRules("Angle", (string value) => NavigationPointsAngle.Add(value));
            AddFieldRules("SatellitesCount", (string value) => NavigationPointsSatellitesCount.Add(value));
            AddFieldRules("Speed", (string value) => NavigationSpeed.Add(value));
            AddFieldRules("NavigationSystemType", (string value) => NavigationNavigationSystemType.Add(value));
            AddFieldRules("HardwareValidation", (string value) => NavigationHardwareValidation.Add(value));
            AddFieldRules("IsNavigationValid", (string value) => PointsIsNavigationValid.Add(value));
        }
        public new List<ITable> GetTablesList()
        {
            var result = new List<ITable>();
            for (int i = 0; i < NavigationPointsLocationLatitude.Count; i++)
            {
                result.Add(new NavigationValidationStatisticTable(
                    ValidPointsCount, InvalidPointsCount, PointsTimestamp[i],
                    NavigationPointsLocationLatitude[i], NavigationPointsLocationLongitude[i], NavigationPointsAltitudeMeters[i],
                    NavigationPointsAngle[i], NavigationPointsSatellitesCount[i], NavigationSpeed[i],
                    NavigationNavigationSystemType[i], NavigationHardwareValidation[i], PointsIsNavigationValid[i]));
            }
            return result;
        }
    }
}