using AutomotiveCenter.Application.Entities;
using AutomotiveCenter.Infrastructure.Interfaces;
using AutomotiveCenter.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveCenter.Application.Services
{
    public class UserService : IUserService
    {
        private ICRUDRepository<User> _userRepository;

        public UserService(ICRUDRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUser(long userId)
        {
            return await _userRepository.Get(userId);
        }

        public async Task<long> InsertUser(User user)
        {
            return await _userRepository.Save(user);
        }

        public async Task<long> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<bool> DeleteUser(User user)
        {
            return await _userRepository.Delete(user);
        }
    }
}
