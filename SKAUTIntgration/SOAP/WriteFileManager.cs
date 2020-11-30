using SKAUTIntgration.Auth;
using SKAUTIntgration.FuelFlow;
using SKAUTIntgration.FuelingDefueling;
using SKAUTIntgration.MonitoringObject;
using SKAUTIntgration.MotorModes;
using SKAUTIntgration.StatisticController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.SOAP
{
    public class WriteFileManager
    {
        SpicAuthorizationResponse token;
        SpicSoapStatisticsControllerServiceClient StatisticsControllerServiceClient;
        SpicSoapFuelFlowStatisticsServiceClient FuelFlowStatisticsServiceClient;
        SpicSoapFuelingDefuelingStatisticsServiceClient FuelingDefuelingStatisticsServiceClient;
        SpicSoapUnitsServiceClient UnitsServiceClient;
        SpicSoapMotorModesStatisticsServiceClient MotorModesStatisticsServiceClient;

        public WriteFileManager(SpicAuthorizationResponse token)
        {
            this.token = token;
            FuelFlowStatisticsServiceClient = new SpicSoapFuelFlowStatisticsServiceClient();
            FuelingDefuelingStatisticsServiceClient = new SpicSoapFuelingDefuelingStatisticsServiceClient();
            UnitsServiceClient = new SpicSoapUnitsServiceClient();
            MotorModesStatisticsServiceClient = new SpicSoapMotorModesStatisticsServiceClient();
            StatisticsControllerServiceClient = new SpicSoapStatisticsControllerServiceClient();
        }
        public void RunWriter(INIManager INI, DateTime period)
        {
            var printList = new List<object>();
            var units = GetAllUnits();
            printList.Add(units);
            var rootCatalog = INI.GetPrivateString("RootCatalog", "BasePath");
            Print(rootCatalog, null, period, printList);
        }
        private void RunGetStatistics(SpicUnit[] units, INIManager INI, DateTime period)
        {
            foreach (var item in units)
            {
                var statisticRequest = GetSessionRequestForUnit(item, period);
                var statisticSession = StatisticsControllerServiceClient.StartStatisticsSession(statisticRequest);
            }
        }
        private void Print(string basePath, string documentPath, DateTime period, List<object> printList)
        {
            var printer = new CSVPrinter();
            printer.Print(basePath,documentPath, period, printList);
        }
        private SpicUnit[] GetAllUnits()
        {
            var response = UnitsServiceClient.GetAllUnits();
            return response.Units;
        }
        private SpicStatisticsSessionRequest GetSessionRequestForUnit(SpicUnit unit, DateTime period)
        {
            var request = new SpicStatisticsSessionRequest();
            request.Period.Begin = period;
            request.Period.End = period.AddDays(1);
            var objectIdentit = new SpicObjectIdentity();
            objectIdentit.ObjectId = unit.UnitId;
            objectIdentit.ObjectTypeId = new Guid("0F1E3A4A-88F5-4166-9BE8-76033DD85D08");
            request.TargetObject = objectIdentit;
            return request;
        }
    }
}
