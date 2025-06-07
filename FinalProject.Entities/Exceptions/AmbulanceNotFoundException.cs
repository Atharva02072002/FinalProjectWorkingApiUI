namespace FinalProject.Entities.Exceptions
{
    public class AmbulanceNotFoundException : NotFoundException
    {
        public AmbulanceNotFoundException(Guid id)
            : base($"Ambulance with ID: {id} was not found in the database.")
        {
        }
    }
}

