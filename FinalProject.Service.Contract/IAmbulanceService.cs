using FinalProject.Shared;

namespace FinalProject.Service.Contract
{
    public interface IAmbulanceService
    {
        // Retrieves all ambulances, optionally tracking changes
        IEnumerable<AmbulanceDto> GetAllAmbulances(bool trackChanges);

        // Retrieves an ambulance by its ID, optionally tracking changes
        AmbulanceDto? GetAmbulanceById(Guid id, bool trackChanges);

        // Creates a new ambulance
        AmbulanceDto CreateAmbulance(AmbulanceDto ambulanceDto);

        // Updates an existing ambulance
        void UpdateAmbulance(Guid id, AmbulanceDto ambulanceDto, bool trackChanges);

        // Deletes an ambulance by its ID
        void DeleteAmbulance(Guid id, bool trackChanges);
    }
}