using Microsoft.AspNetCore.Mvc;
using WebAPI_Demo.Models;
using WebAPI_Demo.Services;
using AutoMapper;
using Autofac;

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
            public IActionResult Addproduct(ProductModel product)
            {

            var t = _mapper.Map<product>(product);
            Random r = new Random();
            t.id = r.Next();
     
                if (ModelState.IsValid)
                {
                    //products.Add(t);
                    _iservice.InsertRecords(t);
                    return CreatedAtAction("GetProduct", new { t.id }, t);
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