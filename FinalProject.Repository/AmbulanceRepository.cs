using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Contracts;
using FinalProject.Entities.Models;
using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProject.Repository
{
    public class AmbulanceRepository : IAmbulanceRepository
    {
        private readonly RepositoryContext _context; // Context for accessing the database

        /// <summary>
        /// Initializes a new instance of the <see cref="AmbulanceRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AmbulanceRepository(RepositoryContext context)
        {
            _context = context; // Initializing the context through dependency injection
        }

        /// <summary>
        /// Retrieves all ambulances, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A list of all ambulances.</returns>
        public IEnumerable<Ambulance> GetAllAmbulances(bool trackChanges) =>
            !trackChanges ? _context.Ambulances.AsNoTracking().ToList() : _context.Ambulances.ToList();

        /// <summary>
        /// Retrieves an ambulance by its ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the ambulance.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>The ambulance with the specified ID, or null if not found.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the ambulance with the specified ID is not found.</exception>
        public Ambulance GetAmbulanceById(Guid id, bool trackChanges)
        {
            var ambulance = !trackChanges
                ? _context.Ambulances.AsNoTracking().FirstOrDefault(a => a.AmbulanceId == id)
                : _context.Ambulances.FirstOrDefault(a => a.AmbulanceId == id);

            if (ambulance == null)
                throw new KeyNotFoundException($"Ambulance with id {id} not found.");

            return ambulance;
        }

        /// <summary>
        /// Adds a new ambulance to the database.
        /// </summary>
        /// <param name="ambulance">The ambulance to add.</param>
        public void CreateAmbulance(Ambulance ambulance) =>
            _context.Ambulances.Add(ambulance);

        /// <summary>
        /// Updates an existing ambulance in the database.
        /// </summary>
        /// <param name="ambulance">The ambulance to update.</param>
        public void UpdateAmbulance(Ambulance ambulance)
        {
            // EF Core tracks entity, so no code needed here
            // Updates an existing ambulance in the database, handled automatically by EF Core
        }

        /// <summary>
        /// Removes an ambulance from the database.
        /// </summary>
        /// <param name="ambulance">The ambulance to remove.</param>
        public void DeleteAmbulance(Ambulance ambulance) =>
            _context.Ambulances.Remove(ambulance);

        public bool Exists(Expression<Func<Ambulance, bool>> predicate)
        {
            return _context.Ambulances.Any(predicate);
        }
    }
}


