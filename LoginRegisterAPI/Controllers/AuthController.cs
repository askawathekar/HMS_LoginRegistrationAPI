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
        private readonly IService<Login> loginServ;
        private readonly IRegister registerServ;
        public AuthController(IRegister register, IService<Login> login)
        {
            registerServ = register;
            loginServ = login;
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
            var result = loginServ.Authenticate(user.Email, user.Password);
            if(result!=null)
            {
                _token = loginServ.GetJWTToken(user.Email);
            }
           
            return Ok( new { 
                email=result.Email,
                DefaultRole=result.DefaultRole,
                JWTToken=_token
            });
        }



        [HttpPost, Route("Patient/Registration")]

        public IActionResult PatientRegister([FromBody] PatientUser model)
        {
            //User user = new PatientUser();
            
            bool success = false;
            bool _registartionFlag = false;
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid client request");
            }
            success = registerServ.ChcekUserExist(model.UserId);
            
            if (!success)
                _registartionFlag = registerServ.PatientRegister(model);
            else
                return BadRequest("User Allready Exist!");

            return Ok();
        }

        [HttpPost, Route("Hospital/Registration")]

        public IActionResult HospitalUserRegister([FromBody] HospitalUser model)
        {
            //User user = new PatientUser();

            bool success = false;
            bool _registartionFlag = false;
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid client request");
            }
            success = registerServ.ChcekUserExist(model.UserId);

            if (!success)
                _registartionFlag = registerServ.HospitalRegister(model);
            else
                return BadRequest("User Allready Exist!");

            return Ok();
        }




        //[HttpPost, Route("Registration")]
        //public IActionResult Register([FromBody] RegisterUser user)
        //{
        //    bool success = false;
        //    bool _registartionFlag = false;
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid client request");
        //    }
        //    switch(user.RoleId)
        //    {
        //        case "2":
        //            success = _RegisterServ.ChcekUserExist(user.PatientId);

        //            break;
        //        case "3":
        //            success = _RegisterServ.ChcekUserExist(user.PhysicianId);
        //            break;
        //        case "4":
        //            success = _RegisterServ.ChcekUserExist(user.NurseId);
        //            break;
        //    }
        //    if (!success)
        //        _registartionFlag = _RegisterServ.Register(user);
        //    else
        //        return BadRequest("User Allready Exist!");

        //    return Ok();
        //}

    }
}
