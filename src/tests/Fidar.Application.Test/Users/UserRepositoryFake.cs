using Fidar.Domain.Users;
using Fidar.Infrastructure.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fidar.Application.Test.Users
{
    public class UserRepositoryFake : UserRepository
    {
        List<User> _users = new();
        Random _rnd = new Random();
        public async Task<int> AddAsync(User entity)
        {
            entity.Id = _rnd.Next(0, 100);
            _users.Add(entity);
            return entity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var user = _users.SingleOrDefault(_ => _.Id == id);
            _users.Remove(user);
            return user.Id;
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return _users.ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return _users.SingleOrDefault(_ => _.Id == id);
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var user = _users.SingleOrDefault(_ => _.Id == entity.Id);
            _users.Remove(user);
            _users.Add(entity);
            return entity.Id;
        }
    }
}