using System;
using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models.Entities
{
    public class CurrencyDataResponse
    {
        public SourceType DataSource { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }
    }
}