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
    public class CategoryController : ControllerBase
    {
    
        // GET: api/<CategoryController>
        public virtual IUnitOfWork _unitOfWork { get; set; }
       public virtual entity_context _entityContext { get; set; }
      
        public  CategoryController(IUnitOfWork unitOfWork , entity_context context)
        {
            _unitOfWork = unitOfWork;   
            _entityContext = context;   
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            var categories = await _unitOfWork.categoryRepository.GetAllAsync();


            return categories;
        }

        [Authorize]
        // POST api/<CategoryController>
        [HttpPost]
        public async  Task<IActionResult> Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.categoryRepository.AddAsync(category);
            var result =  _unitOfWork.Complete();
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
            var category = await _unitOfWork.categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [Authorize]

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category category)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var cate = await _unitOfWork.categoryRepository.GetByIdAsync(id);
                if (cate == null)
                {
                    return NotFound();
                }
                else
                {
                    cate.cateName = category.cateName;
                    cate.cateDescription = category.cateDescription;
                    _unitOfWork.categoryRepository.Update(cate);
                    var result = _unitOfWork.Complete();
                    if (result > 0)
                    {
                        return Ok(cate);
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
            var cate = await _unitOfWork.categoryRepository.GetByIdAsync(id);
            if(cate == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.categoryRepository.Delete(cate);
              var result =  _unitOfWork.Complete();
                if(result > 0)
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
