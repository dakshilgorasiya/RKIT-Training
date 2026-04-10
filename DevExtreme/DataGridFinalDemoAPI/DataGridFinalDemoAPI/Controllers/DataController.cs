using DataGridFinalDemoAPI.DTO;
using DataGridFinalDemoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace DataGridFinalDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public static List<Sale_Record> Sale_Records = new DataRepository().Sale_Records;
        public DataController() { }

        [HttpGet("GetRecords")]
        public object GetRecords([ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))] DataSourceLoadOptions loadOptions)
        {
            var query = Sale_Records.AsQueryable();
            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            PaginationResponse paginationResponse = new PaginationResponse()
            {
                TotalCount = Sale_Records.Count,
                Data = Sale_Records,
            };

            return Ok(paginationResponse);
        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] int skip, [FromQuery] int take, [FromQuery] string? sortField, [FromQuery] string? sortOrder)
        {
            List<Sale_Record> data = Sale_Records;

            if (!string.IsNullOrEmpty(sortField))
            {
                if (sortOrder == "desc")
                {
                    data = data.OrderByDescending(x => x.GetType().GetProperty(sortField)).ToList();
                }
                else
                {
                    data = data.OrderBy(x => x.GetType().GetProperty(sortField)).ToList();
                }
            }

            PaginationResponse paginationResponse = new PaginationResponse()
            {
                TotalCount = Sale_Records.Count,
                Data = data.Skip(skip).Take(take).ToList(),
            };

            return Ok(paginationResponse);
        }

        [HttpPost("Add")]
        public IActionResult Add(Sale_Record data)
        {
            data.Id = Sale_Records[Sale_Records.Count - 1].Id + 1;
            Sale_Records.Add(data);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Sale_Records = Sale_Records.Where(x => x.Id != id).ToList();
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Put(Sale_Record data)
        {
            Sale_Record? existing = Sale_Records.FirstOrDefault(x => x.Id == data.Id);

            if (existing == null)
            {
                return NotFound();
            }

            if (data.Product_Name != null)
                existing.Product_Name = data.Product_Name;

            if (data.Product_Category != null)
                existing.Product_Category = data.Product_Category;

            if (data.Customer_Name != null)
                existing.Customer_Name = data.Customer_Name;

            if (data.Sale_Date.HasValue)
                existing.Sale_Date = data.Sale_Date.Value;

            if (data.Sale_Price.HasValue)
                existing.Sale_Price = data.Sale_Price.Value;

            if (data.Discount.HasValue)
                existing.Discount = data.Discount.Value;

            if (data.Quantity.HasValue)
                existing.Quantity = data.Quantity.Value;

            if (data.Shipping_Address != null)
            {
                if (data.Shipping_Address.Street != null)
                    existing.Shipping_Address.Street = data.Shipping_Address.Street;

                if (data.Shipping_Address.City != null)
                    existing.Shipping_Address.City = data.Shipping_Address.City;

                if (data.Shipping_Address.State != null)
                    existing.Shipping_Address.State = data.Shipping_Address.State;
            }

            if (data.Payment_Method != null)
                existing.Payment_Method = data.Payment_Method;

            if (data.Review.HasValue)
                existing.Review = data.Review;

            return Ok();
        }
    }
}
