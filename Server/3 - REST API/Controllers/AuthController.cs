using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games4Kids
{
    [Route("api/auth")]
    [ApiController]
    [EnableCors("Application")]

    public class AuthController : ControllerBase
    {
        private readonly AuthLogic authLogic;
        private readonly JwtHelper jwtHelper;


        public AuthController(AuthLogic logic, JwtHelper jwt)
        {
            authLogic = logic;
            jwtHelper = jwt;
        }


        [HttpPost]
        [Route("register")]
        public IActionResult UserRegister([FromBody] UserViewModel newUserData)
        {
            try
            {
                if (authLogic.IsUsernameExists(newUserData.Username))
                {
                    return BadRequest("Username already exists");
                }

                UserViewModel addedUser = authLogic.Register(newUserData);

                addedUser.JwtToken = jwtHelper.GetJwtToken(addedUser.Username, addedUser.UserRole.ToString());
                addedUser.Password = "********";

                return Ok(addedUser);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("login")]

        public IActionResult UserLogin(CredentialViewModel credentials)
        {
            try
            {
                UserViewModel user = authLogic.GetUserByCredentials(credentials);

                if (user == null)
                    return Unauthorized("Incorrect username or password");


                user.JwtToken = jwtHelper.GetJwtToken(user.Username, user.UserRole.ToString());
                user.Password = null;

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }



    }
}
