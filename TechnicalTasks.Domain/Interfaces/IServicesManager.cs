using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTasks.Shared.DTO;

namespace TechnicalTasks.Domain.Interfaces
{
    public interface IServicesManager
    {
        Task<ICollection<ServiceDTO>> GetAllServices();
    }
}
