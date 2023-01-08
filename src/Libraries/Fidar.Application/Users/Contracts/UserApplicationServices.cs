using Fidar.Application.Users.DTOs;
using Fidar.Domain.Users;

namespace Fidar.Application.Users.Contracts;

public interface UserApplicationServices 
{
    Task<User> GetById(int id);
    Task<List<User>> GetAll();
    Task<int> Add(UserDto user);
    Task Update(int id,UserDto user);
    Task Delete(int id);
}
