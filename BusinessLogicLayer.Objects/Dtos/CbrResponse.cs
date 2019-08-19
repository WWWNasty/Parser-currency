using System;
using Newtonsoft.Json;

namespace BusinessLogicLayer.Objects.Dtos
{
    public class CbrResponse
    {
        public DateTime Date { get; set; }

        public DateTime PreviousDate { get; set; }

        /// <summary>
        /// Валюты
        /// </summary>
        [JsonProperty("Valute")]
        public Valute Currencies { get; set; }
    }
}