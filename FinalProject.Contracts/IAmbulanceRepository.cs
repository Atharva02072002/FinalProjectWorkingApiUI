using System.Linq.Expressions;
using FinalProject.Entities.Models;
using FinalProject.Shared;

namespace FinalProject.Contracts
{
    public interface IAmbulanceRepository

    {
        IEnumerable<Ambulance> GetAllAmbulances(bool trackChanges);       // Method to retrieve all ambulances, optionally tracking changes
        Ambulance? GetAmbulanceById(Guid ambulanceId, bool trackChanges); // Method to retrieve an ambulance by its ID, optionally tracking changes

        void CreateAmbulance(Ambulance ambulance); // Method to add a new ambulance
        void UpdateAmbulance(Ambulance ambulance); // Method to update an existing ambulance
        void DeleteAmbulance(Ambulance ambulance); // Method to delete an ambulance
        bool Exists(Expression<Func<Ambulance, bool>> predicate);


    }

}
