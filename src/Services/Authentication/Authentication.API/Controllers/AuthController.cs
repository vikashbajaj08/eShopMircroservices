using Authentication.Application.AthenticationUser.Commands.RegisterUser;
using Authentication.Application.AthenticationUser.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]

        public async Task<IActionResult> LoginAsync([FromBody] UserLoginQuery userLogin)
        {
            var result = await mediator.Send(userLogin);

            if (result == null)
            {
                return BadRequest($"Invalid Creddentials");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterUserCommand registerUser)
        {
            try
            {
                var response = await mediator.Send(registerUser);

                if (response.success)
                {
                    return Ok("User Successfully Registered");
                }
                return BadRequest("There is some issue with details");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Some error occured {ex.Message}");
            }
            
            
        }
    }
}
