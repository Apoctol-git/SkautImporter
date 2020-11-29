using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKAUTIntgration.TableCreator
{
    public class DiscreteSensorStatisticTableClass:BaseFieldFinder, IDocument
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public string CompanyId { get; set; }
        public string Description { get; set; }
        public string GarageNumber { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string OlsonId { get; set; }
        public string Owner { get; set; }
        public string Power { get; set; }
        public string Registration { get; set; }
        public string StateNumber { get; set; }
        public string UnitId { get; set; }
        public string UnitTypeId { get; set; }
        public string VinNumber { get; set; }
        public string Year { get; set; }

        public DiscreteSensorStatisticTableClass()
        {
            AddFieldRules("Brand", (string value) => Brand = value);
            AddFieldRules("Color", (string value) => Color = value);
            AddFieldRules("CompanyId", (string value) => CompanyId = value);
            AddFieldRules("Description", (string value) => Description = value);
            AddFieldRules("GarageNumber", (string value) => GarageNumber = value);
            AddFieldRules("Model", (string value) => Model = value);
            AddFieldRules("Name", (string value) => Name = value);
            AddFieldRules("Owner", (string value) => Owner = value);
            AddFieldRules("Power", (string value) => Power = value);
            AddFieldRules("OlsonId", (string value) => OlsonId = value);
            AddFieldRules("Registration", (string value) => Registration = value);
            AddFieldRules("StateNumber", (string value) => StateNumber = value);
            AddFieldRules("UnitId", (string value) => UnitId = value);
            AddFieldRules("UnitTypeId", (string value) => UnitTypeId = value);
            AddFieldRules("VinNumber", (string value) => VinNumber = value);
            AddFieldRules("Year", (string value) => Year = value);
        }
    }
}
