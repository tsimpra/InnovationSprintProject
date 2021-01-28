using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class PatientMorbidityGroup
    {
        public long PatientId { get; set; }
        public Patient Patient { get; set; }


        public long MorbidityGroupId { get; set; }
        public MorbidityGroup MorbidityGroup { get; set; }

    }
}
