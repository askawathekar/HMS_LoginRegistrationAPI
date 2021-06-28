using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterAPI.Models
{
    public class RegisterUser
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string PatientId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? Dob { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethinicity { get; set; }
        public string LanguagesKnown { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string ContactNumber { get; set; }
        public string EmergencyFname { get; set; }
        public string EmergencyLname { get; set; }
        public string Relationship { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmergencyAddress { get; set; }
        public string EmergencyMobileNo { get; set; }
        public string AccessFlag { get; set; }
        public string TypeofAllergies { get; set; }
        public bool? IsAllergyFatal { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Ssn { get; set; }
        public string Title { get; set; }
        public string NurseId { get; set; }
        public string NurseName { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianId { get; set; }


    }
}
