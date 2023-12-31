using asp_pro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        public virtual IUnitOfWork _unitOfWork { get; set; }
        public virtual entity_context _entityContext { get; set; }
        public IWebHostEnvironment _hostenv { get; set; }
        public ProductsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostenvorment, entity_context context)
        {
            _unitOfWork = unitOfWork;
            _entityContext = context;
            _hostenv = hostenvorment;  
        }
        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            var products = await _unitOfWork.productRepository.GetAllAsync(new[] {"category"});


            return products;
        }


        // POST api/<CategoryController>
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Products product )
        {
            var folder = "images/";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //Console.WriteLine("1");
            //folder += Guid.NewGuid().ToString() + "_" + file.FileName;
            //string serverFolder = Path.Combine(_hostenv.WebRootPath, folder);
            //Console.WriteLine("2");
            //await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            //product.pathImage = folder;
            Console.WriteLine("3");
            await _unitOfWork.productRepository.AddAsync(product);
            Console.WriteLine("4");
            var result = _unitOfWork.Complete();
            Console.WriteLine(result);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _unitOfWork.productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        // PUT api/<CategoryController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Products product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var pro = await _unitOfWork.productRepository.GetByIdAsync(id);
                if (pro == null)
                {
                    return NotFound();
                }
                else
                {
                    pro.proName = product.proName;
                    pro.proDescription = product.proDescription;
                    pro.CateID = product.CateID;
                    _unitOfWork.productRepository.Update(pro);
                    var result = _unitOfWork.Complete();
                    if (result > 0)
                    {
                        return Ok(pro);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
            }
        }

        // DELETE api/<CategoryController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pro = await _unitOfWork.productRepository.GetByIdAsync(id);
            if (pro == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.productRepository.Delete(pro);
                var result = _unitOfWork.Complete();
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }


            }
        }
    }
}
