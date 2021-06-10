using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ContactManager.Extensions.MappingData
{
    public class MyBooleanConverter : DefaultTypeConverter
    {
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var boolValue = (bool)value;
            return boolValue ? "yes" : "no";
        }
    }
}