﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoginRegister.DBO.Models
{
    public partial class PatientVisitProcedureDetails
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public DateTime? PhysicianCheckupDate { get; set; }
        public string ProcedureCode { get; set; }
        public string AppointmentId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
