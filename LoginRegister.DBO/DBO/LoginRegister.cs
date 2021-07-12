﻿using LoginRegister.DBO.Models;
using LoginRegisterAPI.Helper;
using LoginRegisterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginRegister.DBO.DBO
{
    public class LoginRegister
    {
        private readonly HospitalManagementContext _context;

        public LoginRegister(HospitalManagementContext ctx)
        {
            _context = ctx;
        }

        //public LoginRegister()
        //{
        //}

        public Login VerifyLogin(string email, string password)
        {
            Login user = new Login();
            try
            {

                //user = _context.Login.Where(e => e.UserId == username && e.Password == password).Select(e => new Login
                //{
                //    UserId = e.UserId,
                //    DefaultRole = e.DefaultRole

                //}).FirstOrDefault();

                user = _context.Login.Where(e => e.Email == email && e.Password == password).Select(e => new Login
                {
                    Email = e.Email,
                    DefaultRole = e.DefaultRole

                }).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public bool CheckUserExist(string userId)
        {
            bool success = false;
            try
            {
                var user= _context.Login.Where(e => e.UserId == userId).SingleOrDefault();
                if (user != null)
                  return  success = true;
            }
            catch(Exception ex)
            {

            }
            return success;
        }

        public bool RegisterUser(PatientUser model)
        {
            bool success = false;

            try
            {
                success = RegisterPatient(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return success;
        }
        public bool RegisterUser(HospitalUser model)
        {
            bool success = false;

            switch (model.RoleId)
            {
               
                case "3":
                    success = RegisterPhysician(model);
                    break;
                case "4":
                    success = RegisterNurse(model);
                    break;

            }

            return success;
        }

        public bool RegisterNurse(HospitalUser model)
        {
            bool success = false;
            try
            {
                Login _loginDetails = new Login()
                {
                    UserId = "N"+model.ContactNumber,
                    Password = "N" + model.ContactNumber,
                    Email = model.Email,
                    //  EncryPassword = new Helper().EncryptPassword(),
                    CreationDate = DateTime.Now,
                    DefaultRole = "Nurse",
                    AdditionalRole = null,
                    IsEnabled = true,
                    OtpRequired="NO"
                };
                _context.Login.Add(_loginDetails);
                _context.SaveChanges();

                Nurse _nurse = new Nurse()
                {
                    NurseId = "N" + model.ContactNumber,
                    NurseName = model.FirstName + " " + model.LastName,
                    Ssn = model.ContactNumber,
                    Email=model.Email,
                    LastUpdatedOn=DateTime.Now
                 
                };
                _context.Add(_nurse);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return success;
        }

      

        private bool RegisterPhysician(HospitalUser model)
        {
            bool success = false;
            try
            {
                Login _loginDetails = new Login()
                {
                    UserId = "PH" + model.ContactNumber,
                    Password = "PH" + model.ContactNumber,
                    Email=model.Email,
                  //  EncryPassword = new Helper().EncryptPassword(),
                    CreationDate = DateTime.Now,
                    DefaultRole = "Physican",
                    AdditionalRole = null,
                    IsEnabled = true,
                    OtpRequired = "NO"
                };
                _context.Login.Add(_loginDetails);
                _context.SaveChanges();

                Physician _Physician = new Physician()
                {
                    PhysicianId = "PH" + model.ContactNumber,
                    PhysicianName = model.FirstName +" "+ model.LastName,
                    Ssn = model.ContactNumber,
                    Email = model.Email,
                    LastUpdatedOn = DateTime.Now

                };
                _context.Add(_Physician);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return success;
        }

        public bool RegisterPatient(PatientUser model)
        {
            bool success = false;
            try
            {
                Login _loginDetails = new Login()
                {
                    UserId = "PT" + model.ContactNumber,
                    // Password = "PT" + model.ContactNumber,
                    Password = model.Password,
                    Email =model.Email,
                    //EncryPassword = new Helper().EncryptPassword(),
                    CreationDate = DateTime.Now,
                    DefaultRole = "Patient",
                    AdditionalRole = null,
                    IsEnabled = true,
                    OtpRequired = "NO"
                };
                _context.Login.Add(_loginDetails);
                _context.SaveChanges();

                
                Patient _Patient = new Patient()
                {
                    PatientId = "PT" + model.ContactNumber,
                    Fname = model.FirstName,
                    Lname = model.LastName,
                    Age = model.Age,
                    Dob = model.Dob,
                    ContactNumber = model.ContactNumber,
                    EmergencyAddress = model.EmergencyAddress,
                    HomeAddress = model.HomeAddress,
                    EmergencyEmail = model.EmergencyEmail,
                    EmergencyFname = model.EmergencyFname,
                    EmergencyLname = model.EmergencyLname,
                    EmergencyMobileNo = model.EmergencyMobileNo,
                    Ethinicity = model.Ethinicity,
                    Gender = model.Gender,
                    IsAllergyFatal = model.IsAllergyFatal,
                    LanguagesKnown = model.LanguagesKnown,
                    Race = model.Race,
                    RegistrationDate = DateTime.Now,
                    Relationship = model.Relationship,
                    Title = model.Title,
                    AccessFlag = true,
                   Ssn= model.ContactNumber,
                    Email = model.Email
                };
                _context.Add(_Patient);
                _context.SaveChanges();

                //foreach(var allergies in model.AllergyDetails)
                //{
                //    PatientAllergyDetails _patientAllergyDetails = new PatientAllergyDetails()
                //    {
                //        PatientId = model.PatientId,
                //        AllergyType=allergies.Key.ToString(),
                //        AllergyId=allergies.Value
                //    };

                //}


            }
            catch (Exception ex)
            {

            }
            return success;
        }
    }
}
