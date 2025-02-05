using Azure;
using DoConnectEntity;
using DoConnectEntity.DTOs;
using DoConnectService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoConnectWebUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _productService;
        public UserController(IUserService userService)
        {
            _productService = userService;
        }

        [HttpPost("Register")]

        public IActionResult Register([FromBody] User user)
        {
            _productService.Register(user);
            Response response = new Response();
            response.statuscode = "200";
            response.result = "User Registered Successfully";
            response.message = "Success";
            //object result = "User Registered successfully..";
            return Ok(response);
        }

        //[HttpPost("Login")]
        //public IActionResult Login(string Email, string Password)
        //{
        //   var result= _productService.Login(Email, Password);
        //    Response response = new Response();
        //    response.statuscode = "200";
        //    response.result = result;
        //    response.message = "Success";
        //   // object result = "Logged in successfully..";
        //    return Ok(response);
        //}


        [HttpPost("Login")]
        public IActionResult Login(string Email, string Password)
        {

             _productService.Login(Email, Password);
            Response response = new Response();
            response.statuscode = "200";
            response.result = "User Loggedin Successfully";
            response.message = "Success";
            return Ok(response);
        }



        [HttpDelete("Logout")]
        public IActionResult Logout(User user)
        {
            _productService.Logout(user);
            object result = "Logged out successfully..";
            return Ok(result);
        }

        [HttpGet("Getusers")]

        public IActionResult GetAll()
        {
            var result = _productService.GetUser();
            return Ok(result);
        }

        //[HttpPut("Logout")]
        //public IActionResult Logout()
        //{
        //    _productService.Logout();
        //    object result = "Logged out successfully..";
        //    return Ok(result);
        //}
     
    }
    public class Response
    {
        public object result { get; set; }
        public string statuscode { get; set; }
        public string message { get; set; }
    }
}




//IUserService _userService;

//public UserController(IUserService userService)
//{
//    _userService = userService;
//}

//[HttpPost("register")]
//public async Task<IActionResult> Register([FromBody] User user)
//{
//    if (!ModelState.IsValid)
//        return BadRequest(ModelState);

//    var success = await _userService.RegisterUserAsync(user.Username, user.Email, user.Password);

//    if (!success)
//        return Conflict("User already exists.");

//    return Ok("Registration successful.");
//}

//[HttpPost("login")]
//public async Task<IActionResult> Login([FromBody] Loginrequest request)
//{
//    if (!ModelState.IsValid)
//        return BadRequest(ModelState);

//    var user = await _userService.LoginUserAsync(request.Username, request.Password);

//    if (user == null)
//        return Unauthorized("Invalid credentials.");

//    // Issue token or set cookie/session as required
//    return Ok("Login successful.");
//}

//[HttpPost("logout")]
//public async Task<IActionResult> Logout()
//{
//    await _userService.LogoutUserAsync();
//    return Ok("Logout successful.");
//}

//[HttpGet("Getusers")]

//public IActionResult GetAll()
//{
//    var result = _userService.GetUser();
//    return Ok(result);
//}
