using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class DischargedPatientService : IDischargedPatientService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DischargedPatientService"/> class.
        /// </summary>
        /// <param name="repoManager">The repository manager.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public DischargedPatientService(IRepositoryManager repoManager, ILoggerManager logger, IMapper mapper)
        {
            _repo = repoManager;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<DischargedPatient> GetAllPatients(bool trackChanges) =>
            _mapper.Map<IEnumerable<DischargedPatient>>(_repo.DischargedPatient.GetAll(trackChanges: false));
    }
}
