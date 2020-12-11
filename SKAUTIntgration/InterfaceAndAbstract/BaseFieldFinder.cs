using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator
{
    abstract public class BaseFieldFinder
    {
        Dictionary<string, Action<string>> fieldRules = new Dictionary<string, Action<string>>();
        Dictionary<string, bool> isStaticFieldList = new Dictionary<string, bool>(); // Лист из статичных свойств статистики
        Dictionary<string, bool> isFilledField = new Dictionary<string, bool>(); // лист из заполненных полей элементов документа
        static Dictionary<string, string> staticValueList = new Dictionary<string, string>(); // лист со статичными значениями
        protected virtual void AddFieldRules(string condition, Action<string> setter)
        {
            fieldRules.Add(condition, setter);
        }

        protected virtual void AddFieldRules(string condition, Action<string> setter, bool isStatic)
        {
            fieldRules.Add(condition, setter);
            isStaticFieldList.Add(condition, isStatic);
            isFilledField.Add(condition, false);
            try
            {
                staticValueList[condition] = null;
            }
            catch (KeyNotFoundException)
            {
                if (isStatic)
                {
                    staticValueList.Add(condition, null);
                }
            }

        }
        public virtual void RunSetterField(string condition, string value)
        {
            try
            {
                fieldRules[condition](value);
            }
            catch (KeyNotFoundException ex)
            {
                //var log = new Logger();
                //log.WriteKeyNotFoundExeption(ex.Message, condition);
            }
        }
        public virtual void RunSetterField(string condition, string value, bool isStatistic)
        {
            try
            {
                if (isStaticFieldList[condition])
                {
                    staticValueList[condition] = value;
                    fieldRules[condition](value);
                    isFilledField[condition] = true;
                }
                else
                {
                    fieldRules[condition](value);
                    isFilledField[condition] = true;
                }
            }
            catch (KeyNotFoundException ex)
            {
                var log = new Logger();
                log.WriteKeyNotFoundExeption(ex.Message, condition);
            }
        }
        public bool IsAllFieldFilling()
        {
            bool isAll = true;
            foreach (var item in isFilledField)
            {
                if (!item.Value)
                {
                    isAll = false;
                    break;
                }
            }
            if (isFilledField.Count == 0)
            {
                isAll = false;
            }
            return isAll;
        }
        public List<ITable> GetTablesList()
        {
            return null;
        }
        protected void SetStaticValue(string condition, string value)
        {
            staticValueList[condition] = value;
        }
        protected void FillStaticValue()
        {
            foreach (var item in staticValueList)
            {
                fieldRules[item.Key](item.Value);
                isFilledField[item.Key] = true;
            }
        }
        protected virtual bool GetIsStaticValue(string condition)
        {
            try
            {
                return isStaticFieldList[condition];
            }
            catch (KeyNotFoundException ex)
            {
                var log = new Logger();
                log.WriteKeyNotFoundExeption(ex.Message, condition);
                return false;
            }
        }
        protected void ChangeStateField(string condition, bool state)
        {
            isFilledField[condition] = state;
        }

    }

}
