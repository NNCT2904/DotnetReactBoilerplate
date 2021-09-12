using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cityfmcodetest.Models.Dto
{
    public class GetProductDto
    {
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "unitPrice")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "maximumQuantity")]
        public int? MaximumQuantity { get; set; }

        [JsonConstructor]
        public GetProductDto(string productId, string name, string description, decimal price, int? maximumQuantity)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            MaximumQuantity = maximumQuantity;
        }
    }
}
