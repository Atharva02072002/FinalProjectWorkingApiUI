using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Contracts
{
    public interface IDischargedPatientRepository
    {
        void CreateDischargedPatient(DischargedPatient patient);

        IEnumerable<DischargedPatient> GetAll(bool trackChanges);
    }
}
