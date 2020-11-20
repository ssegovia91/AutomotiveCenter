using AutomotiveCenter.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveCenter.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(long userId);
        Task<long> InsertUser(User user);
        Task<long> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
