using cityfmcodetest.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityfmcodetest.Models;
using System.Net.Http;
using cityfmcodetest.Models.Dto;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using dotenv.net;

namespace cityfmcodetest.Controllers
{
    class PDTO
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        [JsonPropertyName("name")]
        public int Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonPropertyName("maximumQuantity")]
        public int? MaximumQuantity { get; set; }
    }
    public class ProductController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        IDictionary<string, string> envVars = DotEnv.Read();


        public ProductController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetAllProductAsync()
        {
            return await _context.Products
                .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("fetch")]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> FetchProductAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                
                client.BaseAddress = new Uri(envVars["SOURCE"]);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );
                client.DefaultRequestHeaders.TryAddWithoutValidation("api-key", envVars["APIKEY"]);


                HttpResponseMessage response = client.GetAsync("").Result;

                string responseBody = await response.Content.ReadAsStringAsync();

                var productObjects = JsonConvert.DeserializeObject<IEnumerable<FetchProductDto>>(responseBody);

                foreach (FetchProductDto productDto in productObjects)
                {
                    var availableProd = await _context.Products
                        .Where(p => p.ProductId == productDto.ProductId)
                        .SingleOrDefaultAsync();

                    if (availableProd != null)
                    {
                        availableProd.Name = productDto.Name;
                        availableProd.Description = productDto.Description;
                        availableProd.UnitPrice = productDto.UnitPrice;
                        availableProd.MaximumQuantity = productDto.MaximumQuantity;
                        availableProd.Price = productDto.UnitPrice + productDto.UnitPrice * (decimal)0.2;

                        _context.Products.Update(availableProd);
                    }
                    else
                    {
                        Product p = new Product
                        {
                            ProductId = productDto.ProductId,
                            Name = productDto.Name,
                            Description = productDto.Description,
                            UnitPrice = productDto.UnitPrice,
                            MaximumQuantity = productDto.MaximumQuantity,
                            Price = productDto.UnitPrice + productDto.UnitPrice * (decimal)0.2,
                        };

                        _context.Products.Add(p);
                    }
                }

                if (await _context.SaveChangesAsync() > 0)
                {
                    return await _context.Products
                        .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
                }
                else
                {
                    throw new Exception("Cannot fetch");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("clear")]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> ClearDataAsync()
        {
            var data = await _context.Products.ToListAsync();

            if (data.Count > 0)
            {
                _context.Products.RemoveRange(_context.Products);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return await _context.Products
                        .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
                }
                else
                {
                    throw new Exception("Cannot Clear");
                }
            }
            return Ok("Data already deleted");
        }
    }
}
