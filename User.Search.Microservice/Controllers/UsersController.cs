using Core.DTOs;
using Core.Entities.User.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Net.Mime;

namespace User.Search.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsersController : ControllerBase
    {
        private readonly ISearchUserService _searchUserService;

        public UsersController(ISearchUserService searchUserService)
        {
            this._searchUserService = searchUserService;
        }

        /// <summary>
        /// Gets the users by query
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async ValueTask<ActionResult<IList<UserDto>>> GetUserAsync([FromQuery] string q)
        {
            try
            {
                var maybeUsers = this._searchUserService.SearchUser(q);
                return this.Ok(await maybeUsers);
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

