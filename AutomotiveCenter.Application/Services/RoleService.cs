using AutomotiveCenter.Application.Entities;
using AutomotiveCenter.Application.Interfaces;
using AutomotiveCenter.Infrastructure.Context;
using AutomotiveCenter.Infrastructure.Interfaces;
using AutomotiveCenter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveCenter.Application.Services
{
    public class RoleService
    {
        //private ICRUDRepository<Role> _roleRepository;

        //public RoleService(ICRUDRepository<Role> roleRepository)
        //{
        //    _roleRepository = roleRepository;
        //}
        //public RoleService(AutomotiveCenterContext autoCenterContext) : base(autoCenterContext)
        //{
            
        //}

        //public async Task<List<Role>> GetAllRoles()
        //{
        //    return await _roleRepository.GetAll();
        //}

        //public async Task<Role> GetRole(long roleId)
        //{
        //    return await _roleRepository.Get(roleId);
        //}

        //public async Task<long> InsertRole(Role role)
        //{
        //    return await _roleRepository.Save(role);
        //}

        //public async Task<long> UpdateRole(Role role)
        //{
        //    return await _roleRepository.Update(role);
        //}

        //public async Task<bool> DeleteRole(Role role)
        //{
        //    return await _roleRepository.Delete(role);
        //}

        //protected override IQueryable<Role> NavigationProperties(DbSet<Role> dbSet)
        //{
        //    return dbSet;
        //}
    }
}
