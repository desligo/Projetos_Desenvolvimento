using Microsoft.AspNetCore.Mvc;
using Shop.WebApi.Models;
using Shop.WebApi.Models.ViewModel;
using Shop.WebApi.Repository;
using Shop.WebApi.Services;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    public class LoginController : Controller
    {

        [HttpPost]
        [Route("login")]
        public ActionResult Authenticate([FromBody] UserViewModel userModel)
        {
            var user = UserRepository.GetUser(userModel.Username, userModel.Password);
            if (user == null)
                return NotFound(new {message = "Usuario invalido"});

            var token = JwtTokenService.GenerateToken(user.Username);

            user.Password = "";
            
            return Ok(token);

        }
    }
}
