using LoginRegister.DBO.Models;
using LoginRegisterAPI.Helper;
using LoginRegisterAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LoginRegister.DBO.DBO;

namespace LoginRegister.Service.Contracts
{
    public class ServiceLayer : IService<Login>,IRegister<RegisterUser>
    {
        private HospitalManagementContext _context;

        public ServiceLayer(HospitalManagementContext ctx)
        {
            _context = ctx;
        }
        public Login Authenticate(string username, string password)
        {
            Login userModel = new Login();
            userModel = new LoginRegister.DBO.DBO.LoginRegister(_context).VerifyLogin(username, password);


            return userModel;
        }

        public bool ChcekUserExist(string userId)
        {
            bool success = false;
            success = new LoginRegister.DBO.DBO.LoginRegister(_context).CheckUserExist(userId);
            return success;
        }

        public string GetJWTToken(string username)
        {
            var token = new Helper().GetJWTToken(username);
            return token;
        }
        public bool Register(RegisterUser model)
        {
            bool sucess = false;
            sucess = new LoginRegister.DBO.DBO.LoginRegister(_context).RegisterUser(model);
            return sucess;
        }

    }
}
