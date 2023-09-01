using Microsoft.AspNetCore.Mvc;
using WebAPI_Demo.Models;
using WebAPI_Demo.Services;
using AutoMapper;

namespace WebAPI_Demo.Controllers
{

        [Route("api/controller")]
        [ApiController]
        public class productcontroller : ControllerBase
        {
        private readonly IMapper _mapper;
       
            public static List<product> products = new List<product>();
            private readonly Iservice _iservice;

            public productcontroller(Iservice iservice, IMapper mapper)
            {
                _iservice = iservice;
                 _mapper = mapper;
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
            var product2 = _mapper.Map<ProductModel>(product1);
            if (product == null)
                    return NotFound();
                return Ok(product2);
            }

       

        }
    }