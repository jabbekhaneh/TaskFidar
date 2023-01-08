using Fidar.Application.Users.Contracts;
using Fidar.Application.Users.DTOs;
using Fidar.Domain.Users;
using Fidar.Infrastructure.Common;

namespace Fidar.Application.Users;

public class UserServices : UserApplicationServices
{
    private readonly BaseUnitOfWork _unitOfWork;

    public UserServices(BaseUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Add(UserDto user)
    {
        return await _unitOfWork.Users.AddAsync(new User(user.Name, user.Age, user.Credit));
    }

    public async Task Delete(int id)
    {
        await _unitOfWork.Users.DeleteAsync(id);
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return users.ToList();
    }

    public async Task<User> GetById(int id)
    {
        return await _unitOfWork.Users.GetByIdAsync(id);
    }

    public async Task Update(int id, UserDto user)
    {
        var editUser = new User(user.Name, user.Age, user.Credit);
        editUser.Id = id;
        await _unitOfWork.Users.UpdateAsync(editUser);
    }
}
