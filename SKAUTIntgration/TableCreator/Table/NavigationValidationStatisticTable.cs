using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    internal class NavigationValidationStatisticTable:ITable
    {
        internal string UnitId { get; set; }
        internal string ValidPointsCount { get; set; }
        internal string InvalidPointsCount { get; set; }
        internal string PointsTimestamp { get; set; }
        internal string NavigationPointsLocationLatitude { get; set; }
        internal string NavigationPointsLocationLongitude { get; set; }
        internal string NavigationPointsAltitudeMeters { get; set; }
        internal string NavigationPointsAngle { get; set; }
        internal string NavigationPointsSatellitesCount { get; set; }
        internal string NavigationSpeed { get; set; }
        internal string NavigationNavigationSystemType { get; set; }
        internal string NavigationHardwareValidation { get; set; }
        internal string PointsIsNavigationValid { get; set; }

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
