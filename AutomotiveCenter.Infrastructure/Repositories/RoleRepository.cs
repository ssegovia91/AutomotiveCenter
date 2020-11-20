using AutomotiveCenter.Application.Entities;
using AutomotiveCenter.Infrastructure.Context;
using AutomotiveCenter.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveCenter.Infrastructure.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        protected AutomotiveCenterContext _context;
        DbSet<Role>_dbSet;

        public RoleRepository(AutomotiveCenterContext autoCenterContext)
        {
            _context = autoCenterContext;
            _dbSet = autoCenterContext.Set<Role>();            
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await Task.Run(() =>
            {
                return _dbSet.ToListAsync();
            });
        }

        public async Task<Role> GetRole(long roleId)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(x => x.roleId == roleId).FirstOrDefaultAsync();
            });
        }
        public async Task<long> SaveRole(Role role)
        {            
            await _context.AddAsync(role);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<long> UpdateRole(Role role)
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteRole(Role role)
        {
            _context.Remove(role);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }       

        public bool IncludeRelatedEntities { get; set; }

        protected IQueryable<Role> NavigationProperties(DbSet<Role> dbSet)
        {
            return dbSet;
        }

        public IQueryable<Role> Entities
        {
            get
            {
                if (IncludeRelatedEntities)
                {
                    return NavigationProperties(_dbSet);
                }

                return _dbSet.AsQueryable();
            }
        }


    }
}
