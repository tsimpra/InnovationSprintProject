using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public List<Patient> getPatientsByMorbidityGroups(List<MorbidityGroup> morbidityGroups)
        {
            var list = db.PatientMorbidityGroups.Where(p => morbidityGroups.Contains(p.MorbidityGroup)).ToList();
            var finalList = existsInListThatTimes(list, morbidityGroups.Count());
            var pIds = finalList.Select(x => x.PatientId).ToList();
            return db.Patients.Where(x => pIds.Contains(x.Id)).ToList();

          
        }

        private List<PatientMorbidityGroup> existsInListThatTimes(List<PatientMorbidityGroup> list,int times)
        {
            List<PatientMorbidityGroup> returningList = new List<PatientMorbidityGroup>();
            foreach (PatientMorbidityGroup group in list)
            {
                int count = 0;
                foreach(PatientMorbidityGroup gr in list)
                {
                    if(gr.PatientId == group.PatientId)
                    {
                        count++;
                    }
                }
                if(count == times)
                {
                    returningList.Add(group);
                }
            }
            return returningList;
        }
    }
}
