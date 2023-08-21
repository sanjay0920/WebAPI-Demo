using Microsoft.AspNetCore.Mvc;
using WebAPI_Demo.Models;
using WebAPI_Demo.Services;

namespace WebAPI_Demo.Controllers
{

        [Route("api/controller")]
        [ApiController]
        public class productcontroller : ControllerBase
        {
            public static List<product> products = new List<product>();
            private readonly Iservice _iservice;

            public productcontroller(Iservice iservice)
            {
                _iservice = iservice;
            }

            [HttpPost]
            public IActionResult Addproduct(product product)
            {
                if (ModelState.IsValid)
                {
                    products.Add(product);
                    _iservice.InsertRecords(product);
                    return CreatedAtAction("GetProduct", new { product.id }, product);
                }
                return BadRequest();
            }

            [HttpGet]
            public IActionResult GetProduct(int id)
            {
                var product = _iservice.GetAllRecords();

                var product1 = products.FirstOrDefault(x => x.id == id);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }

        

        }
    }