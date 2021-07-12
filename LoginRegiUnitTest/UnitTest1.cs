using LoginRegister.DBO.Models;
using LoginRegister.Service.Contracts;
using LoginRegisterAPI.Controllers;
using LoginRegisterAPI.Models;
using LoginRegiUnitTest.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace LoginRegiUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private AuthController controller;
        //private  IRegister<RegisterUser> _RegisterServ;
        //private IRegister<LoginModel> _LoginServ;
        //IService<Login> _LoginServ
        private Mock<IRegister> _RegisterServ;
        private Mock<IService<Login>> _LoginServ;
       
        // private readonly IService<Login> _LoginServ;
        // private readonly IRegister<RegisterUser> _RegisterServ;

        [SetUp]
        public void Setup()
        {
            _RegisterServ = new Mock<IRegister>();
            _LoginServ = new Mock<IService<Login>>();
            controller = new AuthController(_RegisterServ.Object, _LoginServ.Object);
            RegisterUser user = new RegisterUser();
           
        }



        [TestMethod]
        public void CheckRegisterUserExist()
        {
           // var mock = new Mock<IRegister<RegisterUser>>();
           // mock.Setup(foo => foo.Register(RegisterUser)).Returns(true);

            //var employeeDTO = new RegisterUser()
            //{
            //    RoleId = "3",
            //    PatientId = "PT12345509876",
            //   Email= "ganesha@ganesh.com",
            //};

            //var res = _RegisterServ.Setup(p => p.ChcekUserExist("PT12345509876").Returns(employeeDTO);
            //AuthController at = new AuthController(_RegisterServ.Object,_LoginServ.Object);
            //var res= _RegisterServ.

            //var res = _RegisterServ.Setup(p => p.ChcekUserExist("PT12345509876")).Returns(true);
            var res = _RegisterServ.Setup(p => p.ChcekUserExist(It.IsAny<string>())).Returns(true);

            // _LoginServ.Setup(p => p.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns();
            NUnit.Framework.Assert.AreEqual("User Exist", res);

        }

        [TestMethod]
        public void CheckUserLogin()
        {
            InputValidator val = new InputValidator();
            Login reg = new Login();
            //string name = "Amol";
            //string testname = "Amol";
            string uname = "Amol";
            string password = "admin@123";
            var result = val.CheckLoginDetails(uname, password);
            NUnit.Framework.Assert.That(result, Is.EqualTo(true));

        }



    }
}
