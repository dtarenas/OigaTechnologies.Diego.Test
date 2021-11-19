using Core.DTOs;
using Core.Entities.User.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net.Mime;

namespace User.Register.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserService _registerUserService;

        public UsersController(IRegisterUserService registerUserService)
        {
            this._registerUserService = registerUserService;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="registerUserDto"></param>
        /// <returns>New user created</returns>
        [HttpPost]
        [Route("Register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async ValueTask<ActionResult<UserDto>> RegisterUserAsync([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                return this.Ok(await this._registerUserService.RegisterUserAsync(registerUserDto));
            }
            catch (UserAlreadyExistsException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.Message);
            }
        }
    }
}
