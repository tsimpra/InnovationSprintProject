﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;

namespace InnovationSprintProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyAppContext _db;
        private readonly CreateServices cs = new CreateServices();
        private readonly FetchServices fs = new FetchServices();

        public IndexModel(ILogger<IndexModel> logger, MyAppContext db)
        {
            _logger = logger;
            _db = db;
            cs.db = db;
            fs.db = db;
        }

        public void OnGet()
        {
            if (_db.MorbidityGroups.Count() == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    cs.createMorbidityGroup("MorbidityGroup " + i);
                }
                for (int i = 0; i < 10; i++)
                {
                    cs.createPatient("Patient " + i, generateDateOfBirth(), generateMorbidityGroups());
                }
                for (int i = 0; i < 10; i++)
                {
                    Patient patient = _db.Patients.Where(x => x.Name == ("Patient "+i)).Single();
                    cs.createSymptom("Symptom "+i, generateDateOfOccurance(), patient.Id);
                    cs.createSymptom("Another Symptom " + i, generateDateOfOccurance(), patient.Id);
                }                
            }

            //printing the patients older than 65 years old to the console 
            fs.getPatientsOlderThan(65).ForEach(x => Console.Out.WriteLine("Patient "+x.Name+" is older than 65 years old"));

            //printing the symprtom instances of the "Patient 5" patient
            Patient pat = _db.Patients.Where(x => x.Name == ("Patient " + 5)).Single();
            //cs.createSymptom("Another Symptom", generateDateOfOccurance(), pat.Id); //adding another symptom instance to "Patient 5" patient
            fs.getSymptomInstancesByPatientID(pat.Id).ForEach(x=> Console.Out.WriteLine("Patient's 5 Symptom: "+x.Name));

            List<MorbidityGroup> groups = _db.MorbidityGroups.Where(m => m.Name.Equals("MorbidityGroup 0") || m.Name.Equals("MorbidityGroup 1")).ToList();
            fs.getPatientsByMorbidityGroups(groups).ForEach(x => Console.Out.WriteLine("patient found by morbidity groups: " + x.Name));

        }

        //choosing 2 morbidity groups randomly from the database
        private List<MorbidityGroup> generateMorbidityGroups()
        {
            var groups = _db.MorbidityGroups.ToList();
            Random gen = new Random();
            int range = _db.MorbidityGroups.Count();
            int num = gen.Next(range);
            List<MorbidityGroup> temp = new List<MorbidityGroup>();
            temp.Add(_db.MorbidityGroups.Where(x => x.Name == ("MorbidityGroup " + num)).Single());
            num = gen.Next(range);
            temp.Add(_db.MorbidityGroups.Where(x => x.Name == ("MorbidityGroup " + num)).Single());
            while (temp.ElementAt(0) == temp.ElementAt(1))
            {
                temp.RemoveAt(1);
                num = gen.Next(range);
                temp.Add(_db.MorbidityGroups.Where(x => x.Name == ("MorbidityGroup " + num)).Single());
            }
            return temp;
        }

        private DateTime generateDateOfBirth()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1950, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        private DateTime generateDateOfOccurance()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2020, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}


