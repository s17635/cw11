using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public class HospitalDbService : IHospitalDbService
    {
        private readonly CodeFirstContext context;

        public HospitalDbService(CodeFirstContext context)
        {
            this.context = context;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            context.Add(doctor);
            context.SaveChanges();
            return doctor;
        }

        public Doctor DeleteDoctor(int id)
        {
            var doctor = context.Doctor.FirstOrDefault(d => d.IdDoctor == id);
            context.Doctor.Remove(doctor);
            context.SaveChanges();
            return doctor;
        }

        public Doctor GetDoctor(int id)
        {
            var doctor = context.Doctor.FirstOrDefault(d => d.IdDoctor == id);
            return doctor;
        }

        public Doctor ModifyDoctor(int id)
        {
            var doctor = context.Doctor.FirstOrDefault(d => d.IdDoctor == id);
            doctor.LastName = "noweNazwisko";
            context.SaveChanges();
            return doctor;
        }

        public void SeedDbWithData()
        {
            if (context.Doctor.FirstOrDefault() == null)
            {
                var patient1 = new Patient()
                {
                    FirstName = "Tomasz",
                    LastName = "Kaliniak",
                    BirthDate = DateTime.Now
                };

                var patient2 = new Patient()
                {
                    FirstName = "Jerzy",
                    LastName = "Stajszczak",
                    BirthDate = DateTime.Now
                };

                var doctor1 = new Doctor()
                {
                    FirstName = "Mariusz",
                    LastName = "Pudzianowski",
                    Email = "mariusz@test2.pl"
                };

                var doctor2 = new Doctor()
                {
                    FirstName = "Adam",
                    LastName = "Małysz",
                    Email = "test@test.pl"
                };

                var prescription1 = new Prescription()
                {
                    Date = DateTime.Now,
                    DueDate = DateTime.Now,
                    Patient = patient1,
                    Doctor = doctor1
                };

                var medicament1 = new Medicament()
                {
                    Name = "Rutinoscorbin",
                    Description = "boli cie glowa",
                    Type = "benzo"
                };

                var prescriptionMedicament1 = new PrescriptionMedicament()
                {
                    Medicament = medicament1,
                    Prescription = prescription1,
                    Details = "brac codziennie po 40 tabletek"
                };

                context.Patient.Add(patient1);
                context.Patient.Add(patient2);
                context.Doctor.Add(doctor1);
                context.Doctor.Add(doctor2);
                context.Prescription.Add(prescription1);
                context.Medicament.Add(medicament1);
                context.PrescriptionMedicament.Add(prescriptionMedicament1);


                context.SaveChanges();
            }
        }
    }
}
