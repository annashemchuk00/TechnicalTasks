using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TechnicalTask.Infrastructure.DbContexts;
using TechnicalTasks.Domain.Entities;
using TechnicalTasks.Domain.Interfaces;

namespace TechnicalTasks.Infrastructure.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly DataContext _context;

        public ServicesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<List<Service>> GetServicesByIds(IEnumerable<Guid> ids)
        {
            return await _context.Services.Where(s => ids.Contains(s.Id))
                .ToListAsync();
        }
    }
}
