using AutoMapper;
using Hotel_Listing_Api.DataModel;
using Hotel_Listing_Api.DTO_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace Hotel_Listing_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        // private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        // SignInManager<ApiUser> signInManager,
        public UserController(UserManager<ApiUser> userManager, ILogger<UserController> logger, IMapper mapper)
        {
            _userManager = userManager;
            // _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Trying to access {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(userDTO);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password); // userDTO.Password to store PasswordHash in table
                if (!result.Succeeded)
                {
                    foreach(var err in result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Internal server error in {nameof(Register)}");
                return Problem($"Internal server error in {nameof(Register)}", statusCode: 500);
            }
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        //{
        //    _logger.LogInformation($"Login method trying to accesss by {loginDTO.Email}");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(loginDTO);
        //    }

        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);
        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(loginDTO);
        //        }
        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Internal server error in {nameof(Login)}");
        //        return Problem($"Internal server error caught in catch block in {nameof(Login)}", statusCode: 500);
        //    }
        //}
    }
}
