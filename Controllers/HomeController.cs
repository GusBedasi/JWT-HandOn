using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DTO;
using Shop.Models;
using Shop.Repositories;
using Shop.Services.Contracts;

namespace Shop.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        
        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<UserAuthenticateResponseDTO> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return NotFound(new {messsage = "User not found"});
            }

            var token = _tokenService.GenerateToken(user);

            return new ActionResult<UserAuthenticateResponseDTO>(new UserAuthenticateResponseDTO(user, token));
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticated: - {0}", User.Identity.Name);

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonymous";
        
        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "boss, employee")]
        public string Employee() => "Employee";

        [HttpGet]
        [Route("boss")]
        [Authorize(Roles = "boss")]
        public string Manager() => "Boss";
    }
}