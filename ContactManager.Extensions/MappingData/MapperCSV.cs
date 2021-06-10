using ContactManager.DTO.CVS;
using CsvHelper.Configuration;
using System.Globalization;

namespace ContactManager.Extensions.MappingData
{
    public class MapperCSV : ClassMap<CVSData>
    {
        public MapperCSV()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Name).Name("Name");
            Map(m => m.Phone).Name("Phone");
            Map(m => m.Salary).Name("Salary");
            Map(m => m.Married).Index(3).TypeConverter<MyBooleanConverter>();
            Map(m => m.DateofBirth).Name("DateofBirth");
        }
    }
}