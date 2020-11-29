using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator
{
    public interface IDocument
    {
        void RunSetterField(string condition, string value);
        void RunSetterField(string condition, string value, bool isStatic);
        bool IsAllFieldFilling();
    }
}
