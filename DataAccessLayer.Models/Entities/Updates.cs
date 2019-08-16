using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataAccessLayer.Models.Entities
{
    [Serializable]
    public class Updates
    {
        /// <summary>
        /// Тип события
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Объект, инициировавший событие
        /// Структура объекта зависит от типа уведомления
        /// </summary>
        public JObject Object { get; set; }

        /// <summary>
        /// ID сообщества, в котором произошло событие
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }
    }
}