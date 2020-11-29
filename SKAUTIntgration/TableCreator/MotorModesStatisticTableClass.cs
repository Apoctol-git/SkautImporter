namespace SKAUTIntgration.TableCreator
{
    internal class MotorModesStatisticTableClass : BaseFieldFinder, IDocument
    {
        public string EngineActiveWorkHours { get; set; }
        public string EngineIdleHours { get; set; }
        public string EngineOffHours { get; set; }
        public string EngineOnHours { get; set; }
        public string PeriodsIsActiveWork { get; set; }
        public string PeriodsIsIgnitionOn { get; set; }
        public string Timebegin { get; set; }
        public string TimeEnd { get; set; }
        public string TypeId { get; set; }

        public MotorModesStatisticTableClass()
        {
            AddFieldRules("EngineActiveWorkHours", (string value) => EngineActiveWorkHours = value,true);
            AddFieldRules("EngineIdleHours", (string value) => EngineIdleHours = value,true);
            AddFieldRules("EngineOffHours", (string value) => EngineOffHours = value, true);
            AddFieldRules("EngineOnHours", (string value) => EngineOnHours = value,true);
            AddFieldRules("IsActiveWork", (string value) => PeriodsIsActiveWork = value,false);
            AddFieldRules("IsIgnitionOn", (string value) => PeriodsIsIgnitionOn = value,false);
            AddFieldRules("Begin", (string value) => Timebegin = value,false);
            AddFieldRules("End", (string value) => TimeEnd = value,false);
            AddFieldRules("Value", (string value) => TypeId = value,false);
        }
    }
}