using CustomStoreAPI.Repositories;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]DataSourceLoadOptions loadOptions)
        {
            Console.WriteLine("############################");
            Console.WriteLine(Request.QueryString);
            var data = ProductRepository.Products.AsQueryable();
            Console.WriteLine(Request.Query["sort"]);
            Console.WriteLine(JsonSerializer.Serialize(loadOptions));

            SortingInfo[] sortingInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<SortingInfo[]>(Request.Query["sort"]);

            var result = DataSourceLoader.Load(data, loadOptions);

            return Ok(result);
        }
    }
}
