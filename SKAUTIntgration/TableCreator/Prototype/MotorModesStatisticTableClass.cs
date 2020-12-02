using SKAUTIntgration.TableCreator.Table;
using System.Collections.Generic;

namespace SKAUTIntgration.TableCreator
{
    public class MotorModesStatisticTableClass : BaseFieldFinder, IPrototype
    {
       public string EngineActiveWorkHours { get; set; }
        public string EngineIdleHours { get; set; }
        public string EngineOffHours { get; set; }
        public string EngineOnHours { get; set; }
        public List<string> PeriodsIsActiveWork { get; set; }
        public List<string> PeriodsIsIgnitionOn { get; set; }
        public List<string> Timebegin { get; set; }
        public List<string> TimeEnd { get; set; }
        public List<string> TypeId { get; set; }

        public MotorModesStatisticTableClass()
        {
            PeriodsIsActiveWork = new List<string>();
            PeriodsIsIgnitionOn = new List<string>();
            Timebegin = new List<string>();
            TimeEnd = new List<string>();
            TypeId = new List<string>();
            AddFieldRules("EngineActiveWorkHours", (string value) => EngineActiveWorkHours = value, true);
            AddFieldRules("EngineIdleHours", (string value) => EngineIdleHours = value, true);
            AddFieldRules("EngineOffHours", (string value) => EngineOffHours = value, true);
            AddFieldRules("EngineOnHours", (string value) => EngineOnHours = value, true);
            AddFieldRules("IsActiveWork", (string value) => PeriodsIsActiveWork.Add(value));
            AddFieldRules("IsIgnitionOn", (string value) => PeriodsIsIgnitionOn.Add(value));
            AddFieldRules("Begin", (string value) => Timebegin.Add(value));
            AddFieldRules("End", (string value) => TimeEnd.Add(value));
            AddFieldRules("Value", (string value) => TypeId.Add(value));
        }

        public new List<ITable> GetTablesList()
        {
            var result = new List<ITable>();
            for (int i = 0; i < TypeId.Count; i++)
            {
                result.Add(new MotorModesStatisticTable(EngineActiveWorkHours, EngineIdleHours, 
                    EngineOffHours, EngineOnHours, PeriodsIsActiveWork[i], 
                    PeriodsIsIgnitionOn[i], Timebegin[i], TimeEnd[i], TypeId[i]));
            }
            return result;
        }
    }
}