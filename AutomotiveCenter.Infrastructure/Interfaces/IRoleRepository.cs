using AutomotiveCenter.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveCenter.Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRole(long id);
        Task<long> SaveRole(Role dto);
        Task<long> UpdateRole(Role dto);
        Task<bool> DeleteRole(Role dto);
    }
}
