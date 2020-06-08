using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public interface IHospitalDbService
    {
        public void SeedDbWithData();
        public Doctor GetDoctor(int id);
        public Doctor AddDoctor(Doctor doctor);
        public Doctor ModifyDoctor(int id);
        public Doctor DeleteDoctor(int id);
    }
}
