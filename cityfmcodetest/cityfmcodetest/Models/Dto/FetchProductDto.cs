using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cityfmcodetest.Models.Dto
{
    public class FetchProductDto
    {
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "unitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonProperty(PropertyName = "maximumQuantity")]
        public int? MaximumQuantity { get; set; }

        [JsonConstructor]
        public FetchProductDto(string productId, string name, string description, decimal unitPrice, int? maximumQuantity) {
            ProductId = productId;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            MaximumQuantity = maximumQuantity;
        }
    }

    // public class ProductJsonConverter : JsonConverter
    // {
    //     public override object ReadJson()
    //     {
    //         return 
    //     }
    // }
}
