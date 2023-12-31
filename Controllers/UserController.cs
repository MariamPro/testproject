using asp_pro.Data;
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
    public class UserController : ControllerBase
    {
        public virtual IUnitOfWork _unitOfWork { get; set; }
        public virtual entity_context _entityContext { get; set; }
        public UserController(IUnitOfWork unitOfWork, entity_context context)
        {
            _unitOfWork = unitOfWork;
            _entityContext = context;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var users = await _unitOfWork.userRepository.GetAllAsync();


            return users;
        }

        [Authorize]
        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userCheck = await _unitOfWork.userRepository.FindAsync(x => x.username == user.username);
            if(userCheck != null)
            {
                return BadRequest("لقد تم التسجيل بهذا المستخدممن قبل ");
            }
            if(user.password != null) { 
            user.password = PasswordHash.HashPassword(user.password);
           
            await _unitOfWork.userRepository.AddAsync(user);
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
            else
                {
                    return BadRequest("يجب ادخال كلمة المرورو والمستخدم");
                }
            
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        // PUT api/<CategoryController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var user1 = await _unitOfWork.userRepository.GetByIdAsync(id);
                if (user1 == null)
                {
                    return NotFound();
                }
                else
                {
                    user1.username = user.username;
                    user1.password = user.password;
                    user1.email = user.email;
                    user1.Role = user.Role;
                    var result = _unitOfWork.Complete();
                    if (result > 0)
                    {
                        return Ok(user);
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
            var user = await _unitOfWork.userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.userRepository.Delete(user);
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
