using ContactManager.Entitys.Data;
using System.Reflection;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ContactManager.DTO.CVS;
using CsvHelper.TypeConversion;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using ContactManager.Extensions.MappingData;

namespace ContactManager.Extensions
{
    
   
  
    public static class CSVExtensions
    {
        public static List<CVSData> DataCSVReader(this IFormFile file)
        {

            try
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                var csvParser = new CsvParser<CVSData>(csvParserOptions, new CVSDataMapping());
                var records = csvParser.ReadFromStream(file.OpenReadStream(), Encoding.UTF8)
                    .AsEnumerable()
                    .Select(x => new CVSData
                    {
                        Name = x.Result.Name,
                        DateofBirth = x.Result.DateofBirth,
                        Married = x.Result.Married,
                        Phone = x.Result.Phone,
                        Salary = x.Result.Salary
                    })
                    .ToList();
                return records;
            }
            catch
            {


            }
            return null;

        }



        public  static List<CVSData> ReadCSV(this IFormFile file)
        {
           // Map(x => x.IsValid).Index(3).TypeConverter<MyBooleanConverter>();
            List<CVSData> records = new List<CVSData>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
               // csv.Configuration.TypeConverterCache.AddConverter<bool>(new MyBooleanConverter());
                csv.Context.RegisterClassMap<MapperCSV>();
                records = csv.GetRecords<CVSData>().ToList();
            }
            return records;
         
        }
        public static bool WriteToCSV(this object obj)
        {
            var s = new StringBuilder();
           
            s.AppendLine("Name,Phone,Salary,Married,DateofBirth");
            s.AppendLine("Naib,111,11,0,1990");
            s.AppendLine("Nazim,111,11,0,1990");
            s.AppendLine("Nadir,111,11,0,1990");
            string path = "C:/Users/resid/Desktop/";
            File.WriteAllText(path+"main.csv", s.ToString());
            return default;
        }
    }
}
