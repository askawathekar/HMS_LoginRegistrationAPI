using LoginRegister.DBO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegiUnitTest.Validator
{
    public class InputValidator
    {

        public bool CheckLoginDetails(string email,string password)
        {


            if (email.Contains("") && password == null)
            {
                return false;
            }

           
            return true;
        }


        public bool CheckUserExist(string id)
        {


            //if (id)
            //{
            //    return false;
            //}


            return true;
        }


    }
}
