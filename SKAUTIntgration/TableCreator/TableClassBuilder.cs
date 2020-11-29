using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator
{
    public class TableClassBuilder
    {
        Dictionary<string, IDocument> ClassList = new Dictionary<string, IDocument>();
        public virtual void SetClassList()
        {
            ClassList.Add("MonitoringObject", new DiscreteSensorStatisticTableClass());
            ClassList.Add("FuelFlowStatistic", new FuelFlowStatisticTableClass());
            ClassList.Add("FuelingDefuelingStatistic", new FuelingDefuelingTableClass());
            ClassList.Add("MotorModesStatistic", new MotorModesStatisticTableClass());
            ClassList.Add("NavigationValidationStatistic", new NavigationValidationStatisticTableClass());
            ClassList.Add("TrackPeriodStatistic", new TrackPeriodStatisticTableClass());
            ClassList.Add("TrackPeriodsMileageStatistic", new TrackPeriodsMileageStatisticTableClass());
            ClassList.Add("NavigationFiltrationStatistic", new NavigationFiltrationStatisticTableClass());
            ClassList.Add("DiscreteSensorStatistic", new DiscreteSensorStatisticTableClass());
        }
        IDocument GetTableClass(string condition)
        {
            return ClassList[condition];
        }
        IDocument FuelField(string className, List<XMLelement> workArray)
        {
            var workClass = GetTableClass(className);
            foreach (var item in workArray)
            {
                workClass.RunSetterField(item.Key, item.Value);
            }
            return workClass;
        }
        List<IDocument> FuelFieldArray(string className, List<XMLelement> workArray)
        {
            List<IDocument> documents = new List<IDocument>();
            foreach (var item in workArray)
            {
                var workClass = GetTableClass(className);
                workClass.RunSetterField(item.Key, item.Value,true);
                if (workClass.IsAllFieldFilling())
                {
                    documents.Add(workClass);
                    RefreshClassList();
                }
            }
            return documents;
        }
        void RefreshClassList()
        {
            ClassList.Clear();
            SetClassList();
        }
        public IDocument GetTable(string className, List<XMLelement> workArray)
        {
            return FuelField(className, workArray);
        }
        public List<IDocument> GetTables(string className, List<XMLelement> workArray)
        {
            return FuelFieldArray(className, workArray);
        }
    }
}
