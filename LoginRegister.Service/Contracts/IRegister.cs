using LoginRegister.DBO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegister.Service.Contracts
{
    public interface IRegister 
    {
        bool ChcekUserExist(string userId);
        bool PatientRegister(PatientUser model);

        bool HospitalRegister(HospitalUser model);
    }
}
