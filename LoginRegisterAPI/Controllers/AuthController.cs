using LoginRegister.DBO.Models;
using LoginRegister.Service.Contracts;
using LoginRegisterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IService<Login> _LoginServ;
        private readonly IRegister<RegisterUser> _RegisterServ;
        public AuthController(IRegister<RegisterUser> _Register, IService<Login> _Login)
        {
            _RegisterServ = _Register;
            _LoginServ = _Login;
        }
       
        // private readonly IService<LoginModel, int> LoginServ;
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            string _token = null;
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid client request");
            }
            var result = _LoginServ.Authenticate(user.Email, user.Password);
            if(result!=null)
            {
                _token = _LoginServ.GetJWTToken(user.Email);
            }
           
            return Ok( new { 
                email=result.Email,
                DefaultRole=result.DefaultRole,
                JWTToken=_token
            });
        }
        [HttpPost, Route("Registration")]
        public IActionResult Register([FromBody] RegisterUser user)
        {
            bool success = false;
            bool _registartionFlag = false;
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid client request");
            }
            switch(user.RoleId)
            {
                case "2":
                    success = _RegisterServ.ChcekUserExist(user.PatientId);

                    break;
                case "3":
                    success = _RegisterServ.ChcekUserExist(user.PhysicianId);
                    break;
                case "4":
                    success = _RegisterServ.ChcekUserExist(user.NurseId);
                    break;
            }
            if (!success)
                _registartionFlag = _RegisterServ.Register(user);
            else
                return BadRequest("User Allready Exist!");

            return Ok();
        }

    }
}
