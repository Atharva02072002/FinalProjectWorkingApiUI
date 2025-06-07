using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Exceptions
{
    public class RoomNotFoundException : NotFoundException
    {
        public RoomNotFoundException(int id) : base($"Room with ID: {id} was not found in the database.")
        {
        }
    }
}
