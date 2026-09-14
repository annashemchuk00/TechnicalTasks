using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Domain.Entities;

namespace TechnicalTasks.Domain.Interfaces
{
    public interface IServicesRepository
    {
        Task<ICollection<Service>> GetAllServices();

        Task<List<Service>> GetServicesByIds(IEnumerable<Guid> ids);
    }
}
