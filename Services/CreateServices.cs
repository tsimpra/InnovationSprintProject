using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CreateServices
    {

        public MyAppContext db { get; set; }


        public void createMorbidityGroup(string name)
        {
            var morbidityGroup = new MorbidityGroup();
            morbidityGroup.Name = name;
            db.MorbidityGroups.Add(morbidityGroup);
            db.SaveChanges();
        }

        //create a new patient with given name,date of birth and morbidity groups list. 
        //Creates a new patient and append name,dob values.Then creates a list of PatientMorbidityGroup for each MorbidityGroup using the new patient object.
        //Appends the new list on the new patient object. Appends the new patient to the DB and save changes.
        public void createPatient(string name, DateTime dob, List<MorbidityGroup> morbidityGroups)
        {
            var newPatient = new Patient()
            {
                Name = name,
                Dob = dob,
            };
            List<PatientMorbidityGroup> pmgList = new List<PatientMorbidityGroup>();            
            morbidityGroups.ForEach(x => pmgList.Add(new PatientMorbidityGroup()
            {
                MorbidityGroup = x,
                Patient = newPatient
            }));
            newPatient.MorbidityGroups = pmgList;
            db.Patients.Add(newPatient);
            db.SaveChanges();
        }
        public void createSymptom(string name, DateTime doo, long patientID)
        {
            var patient = db.Patients.Find(patientID);
            var newSymptom = new SymptomInstance()
            {
                Name = name,
                Doo = doo,
                Patient = patient
            };
            db.SymptomInstances.Add(newSymptom);
            db.SaveChanges();
        }
    }


}
