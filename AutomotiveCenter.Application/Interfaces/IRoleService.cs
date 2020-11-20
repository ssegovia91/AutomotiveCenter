using AutomotiveCenter.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveCenter.Application.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRole(long roleId);
        Task<long> InsertRole(Role role);
        Task<long> UpdateRole(Role role);
        Task<bool> DeleteRole(Role role);
    }
}
