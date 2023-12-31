using asp_pro.Data;
using asp_pro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using project.Data;
using project.Models.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public virtual IUnitOfWork _unitOfWork { get; set; }
        public virtual entity_context _entityContext { get; set; }
        public AuthController(IUnitOfWork unitOfWork, entity_context context)
        {
            _unitOfWork = unitOfWork;
            _entityContext = context;
        }

        // POST api/<AuthController>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var userLog = await _unitOfWork.userRepository.GetByIdAsync(user.userId);
                if (userLog != null)
                {
                    return BadRequest("this user is already exists");
                }
                else
                {
                    await _unitOfWork.userRepository.AddAsync(user);
                    var result = _unitOfWork.Complete();
                    if (result > 0)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(loginViewModel user)
        {
            if (user.username != null && user.password != null)
            {


                var userAuth = await _unitOfWork.userRepository.FindAsync((x => x.username == user.username));
                if (userAuth != null)
                {
                    if (PasswordHash.VerifyPassword(user.password, userAuth.password))
                    {
                        userAuth.Token = CreateJwt(userAuth);
                        return Ok(new
                        {
                            token = userAuth.Token,
                            Message = "Login success"
                        });
                    }
                    else
                    {
                        return BadRequest("this password is not correct");
                    }
                }
                else
                {
                    return BadRequest("this username is not found");
                }
            }
            else
            {
                return BadRequest("ادخل اسم المستخدم وكلمة المرور");
            }


        }
        private string CreateJwt(User user)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("asp...angular,,,adp");
            var identify = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Role , user.Role),
                new Claim(ClaimTypes.Name , user.username)
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identify,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials

            };
            var token = jwtToken.CreateToken(tokenDescriptor);
            return jwtToken.WriteToken(token);
        }

    }
}