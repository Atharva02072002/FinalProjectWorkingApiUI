using FinalProject.Contracts;
using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    
    public class DischargedPatientRepository : RepositoryBase<DischargedPatient>, IDischargedPatientRepository
    {
        public DischargedPatientRepository(RepositoryContext context) : base(context) { }

        public void CreateDischargedPatient(DischargedPatient patient) => Create(patient);

        public IEnumerable<DischargedPatient> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    }
}
