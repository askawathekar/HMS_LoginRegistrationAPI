using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegister.DBO.Models
{
    public class User<T>
    {
        public string RoleId { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Ssn { get; set; }

        public DateTime? RegistrationDate { get; set; }

        
       
    }

    public  class PatientUser : User<PatientUser>
    {

       // public string PatientId { get; set; }
       
        public DateTime? Dob { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        
        public string Password { get; set; }

        public string Race { get; set; }
        public string Ethinicity { get; set; }
        public string LanguagesKnown { get; set; }
       
        public string HomeAddress { get; set; }
        
        public string EmergencyFname { get; set; }
        public string EmergencyLname { get; set; }
        public string Relationship { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmergencyAddress { get; set; }
        public string EmergencyMobileNo { get; set; }
        public bool? AccessFlag { get; set; }
        public string TypeofAllergies { get; set; }
        public bool? IsAllergyFatal { get; set; }
      


    }



    public class HospitalUser : User<HospitalUser>
    { 
    
    
    }

    //public  class NurseUser : User
    //{

    //   // public string NurseId { get; set; }

    //}

    //public class PhysicianUser : User
    //{

    //   // public string PhysicianId { get; set; }
        
      
    //}


}
