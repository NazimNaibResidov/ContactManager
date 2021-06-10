using ContactManager.DTO.CVS;
using TinyCsvParser.Mapping;

namespace ContactManager.Extensions.MappingData
{
    internal class CVSDataMapping : CsvMapping<CVSData>
    {
        public CVSDataMapping() : base()
        {
            MapProperty(0, x => x.Name);
            MapProperty(1, x => x.Phone);
            MapProperty(2, x => x.Salary);
            MapProperty(3, x => x.Married).TryMapValue(new CVSData(), "yes");
            MapProperty(4, x => x.DateofBirth);
        }
    }
}