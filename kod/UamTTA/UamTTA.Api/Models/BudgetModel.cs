using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UamTTA.Model;

namespace UamTTA.Api.Models
{
    public class BudgetModel
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Duration Duration { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }
}