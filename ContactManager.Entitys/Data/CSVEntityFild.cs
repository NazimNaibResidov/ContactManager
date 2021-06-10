using System;

namespace ContactManager.Entitys.Data
{
    public class CSVEntityFild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool Married { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}