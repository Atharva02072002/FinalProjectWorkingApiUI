using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Models
{
    public class DischargedPatient
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int RoomNumber { get; set; }
        public DateTime AdmissionDateTime { get; set; }
        public DateTime DischargeDateTime { get; set; }

    }
}
