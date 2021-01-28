using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Patient
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Dob { get; set; }
        public List<PatientMorbidityGroup> MorbidityGroups { get; set; } //= new List<MorbidityGroup>();
        public List<SymptomInstance> SymptomInstances { get; set; } //= new List<SymptomInstance>();
    }
}
