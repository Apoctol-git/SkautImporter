using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator.Table
{
    public class MotorModesStatisticTable:ITable
    {
        public string Unitid { get; set; }
        public string EngineActiveWorkHours { get; set; }
        public string EngineIdleHours { get; set; }
        public string EngineOffHours { get; set; }
        public string EngineOnHours { get; set; }
        public string PeriodsIsActiveWork { get; set; }
        public string PeriodsIsIgnitionOn { get; set; }
        public string Timebegin { get; set; }
        public string TimeEnd { get; set; }
        public string TypeId { get; set; }

        public MotorModesStatisticTable(string engineActiveWorkHours, string engineIdleHours, string engineOffHours, string engineOnHours, string periodsIsActiveWork, string periodsIsIgnitionOn, string timebegin, string timeEnd, string typeId)
        {
            EngineActiveWorkHours = engineActiveWorkHours;
            EngineIdleHours = engineIdleHours;
            EngineOffHours = engineOffHours;
            EngineOnHours = engineOnHours;
            PeriodsIsActiveWork = periodsIsActiveWork;
            PeriodsIsIgnitionOn = periodsIsIgnitionOn;
            Timebegin = timebegin;
            TimeEnd = timeEnd;
            TypeId = typeId;
        }
        public void SetUnitId(string value)
        {
            Unitid = value;
        }

    }
}
