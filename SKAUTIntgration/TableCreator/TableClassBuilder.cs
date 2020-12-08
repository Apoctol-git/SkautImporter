using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator
{
    public class TableClassBuilder
    {
        Dictionary<string, IPrototype> ClassList = new Dictionary<string, IPrototype>();
        public virtual void SetClassList()
        {
            ClassList.Add("MonitoringObject", new UnitTableClass());
            ClassList.Add("FuelFlowStatistic", new FuelFlowStatisticTableClass());
            ClassList.Add("FuelingDefuelingStatistic", new FuelingDefuelingTableClass());
            ClassList.Add("MotorModesStatistic", new MotorModesStatisticTableClass());
            ClassList.Add("NavigationValidationStatistic", new NavigationValidationStatisticTableClass());
            //ClassList.Add("TrackPeriodStatistic", new TrackPeriodStatisticTableClass());
            ClassList.Add("TrackPeriodsMileageStatistic", new TrackPeriodsMileageStatisticTableClass());
            ClassList.Add("NavigationFiltrationStatistic", new NavigationFiltrationStatisticTableClass());
            ClassList.Add("DiscreteSensorStatistic", new DiscreteSensorStatisticTableClass());
        }
        IPrototype GetTableClass(string condition)
        {
            return ClassList[condition];
        }
        IPrototype FuelField(string className, List<XMLelement> workArray)
        {
            var workClass = GetTableClass(className);
            foreach (var item in workArray)
            {
                workClass.RunSetterField(item.Key, item.Value);
            }
            return workClass;
        }
        //List<IDocument> FuelFieldArray(string className, List<XMLelement> workArray)
        //{
        //    List<IDocument> documents = new List<IDocument>();
        //    foreach (var item in workArray)
        //    {
        //        var workClass = GetTableClass(className);
        //        workClass.RunSetterField(item.Key, item.Value, true);
        //        if (workClass.IsAllFieldFilling())
        //        {
        //            documents.Add(workClass);
        //            RefreshClassList();
        //        }
        //    }
        //    return documents;
        //}
        void RefreshClassList()
        {
            ClassList.Clear();
            SetClassList();
        }
        public IPrototype GetTable(string className, List<XMLelement> workArray)
        {
            RefreshClassList();
            return FuelField(className, workArray);
        }
        //public List<IDocument> GetTables(string className, List<XMLelement> workArray)
        //{
        //    RefreshClassList();
        //    return FuelFieldArray(className, workArray);
        //}
    }
}
