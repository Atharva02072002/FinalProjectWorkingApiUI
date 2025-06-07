using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Exceptions
{
    public class PatientNotFoundException : NotFoundException
    {
        public PatientNotFoundException(Guid id)
            : base($"Patient with ID: {id} was not found in the database.")
        {
        }
    }
}
