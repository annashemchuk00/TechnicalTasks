using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TechnicalTasks.Domain.Interfaces;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Application.Managers
{
    public class ServicesManager : IServicesManager
    {
        private readonly IServicesRepository _servicesRepository;
        private readonly IMapper _mapper;

        public ServicesManager(IServicesRepository repository, IMapper mapper)
        {
            _servicesRepository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<ServiceDTO>> GetAllServices()
        {
            var services = await _servicesRepository.GetAllServices();
            return _mapper.Map<ICollection<ServiceDTO>>(services);
        }
    }
}
