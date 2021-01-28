using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services
{
    public class FetchServices
    {
        public MyAppContext db { get; set; }

        public List<Patient> getPatientsOlderThan(int age)
        {
            //int date = DateTime.Now.Year - age;
            DateTime date = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);
            return db.Patients.Where(x => x.Dob < date).ToList();
        }

        public List<SymptomInstance> getSymptomInstancesByPatientID(long patientID)
        {
            var patient = db.Patients.Where(x => x.Id == patientID).Single();
            return db.SymptomInstances.Where(x => x.Patient == patient).ToList();
        }


    }
}
