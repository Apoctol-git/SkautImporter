using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    internal class NavigationValidationStatisticTable:ITable
    {
        public string UnitId { get; set; }
        public string ValidPointsCount { get; set; }
        public string InvalidPointsCount { get; set; }
        public string PointsTimestamp { get; set; }
        public string NavigationPointsLocationLatitude { get; set; }
        public string NavigationPointsLocationLongitude { get; set; }
        public string NavigationPointsAltitudeMeters { get; set; }
        public string NavigationPointsAngle { get; set; }
        public string NavigationPointsSatellitesCount { get; set; }
        public string NavigationSpeed { get; set; }
        public string NavigationNavigationSystemType { get; set; }
        public string NavigationHardwareValidation { get; set; }
        public string PointsIsNavigationValid { get; set; }

        public NavigationValidationStatisticTable(string validPointsCount, string invalidPointsCount, string pointsTimestamp, string navigationPointsLocationLatitude, string navigationPointsLocationLongitude, string navigationPointsAltitudeMeters, string navigationPointsAngle, string navigationPointsSatellitesCount, string navigationSpeed, string navigationNavigationSystemType, string navigationHardwareValidation, string pointsIsNavigationValid)
        {
            ValidPointsCount = validPointsCount;
            InvalidPointsCount = invalidPointsCount;
            PointsTimestamp = pointsTimestamp;
            NavigationPointsLocationLatitude = navigationPointsLocationLatitude;
            NavigationPointsLocationLongitude = navigationPointsLocationLongitude;
            NavigationPointsAltitudeMeters = navigationPointsAltitudeMeters;
            NavigationPointsAngle = navigationPointsAngle;
            NavigationPointsSatellitesCount = navigationPointsSatellitesCount;
            NavigationSpeed = navigationSpeed;
            NavigationNavigationSystemType = navigationNavigationSystemType;
            NavigationHardwareValidation = navigationHardwareValidation;
            PointsIsNavigationValid = pointsIsNavigationValid;
        }
        public void SetUnitId(string value)
        {
            UnitId = value;
        }
    }
}
