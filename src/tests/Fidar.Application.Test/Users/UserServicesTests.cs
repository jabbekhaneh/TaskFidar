using Fidar.Application.Users;
using Fidar.Application.Users.Contracts;
using Fidar.Application.Users.DTOs;
using Fidar.Domain.Users;
using Fidar.Infrastructure.Common;
using Fidar.Infrastructure.Persistens;
using Fidar.Infrastructure.Users.Contracts;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fidar.Application.Test.Users;

public class UserServicesTests
{
    private readonly UserApplicationServices _sut;
    private BaseUnitOfWork _unitOfWork;
    private UserRepository _userRepository;
    public UserServicesTests()
    {
        _userRepository = new UserRepositoryFake();
        _unitOfWork = new UnitOfWork(_userRepository);
        _sut = new UserServices(_unitOfWork);
    }


    [Fact]
    public async Task AddUser_UserService_Should_Return_User()
    {
        //arrange
        var user = new UserDto { Age = 20, Credit = 20, Name = "Hassan" };

        //act
        var actual = await _sut.Add(user);

        //assert
        var expected = await _userRepository.GetByIdAsync(actual);
        expected.Name.Should().Be(user.Name);
        expected.Credit.Should().Be(user.Credit);
        expected.Age.Should().Be(user.Age);


    }



    [Fact]
    public async Task UpdateUser_UserService_Should_Return_User()
    {
        //arrange
        var user = new User("Hassan", 32, 200);
        var userId = await _userRepository.AddAsync(user);
        var userDto = new UserDto { Age = 20, Credit = 20, Name = "Abass" };

        //act
        await _sut.Update(userId, userDto);

        //assert
        var expected = await _userRepository.GetByIdAsync(userId);
        expected.Name.Should().Be(userDto.Name);
        expected.Credit.Should().Be(userDto.Credit);
        expected.Age.Should().Be(userDto.Age);
    }




    [Fact]
    public async Task DeleteUser_UserService_Should_Not_Exist_User()
    {
        //arrange
        var user = new User("Hassan", 32, 200);
        var userId = await _userRepository.AddAsync(user);


        //act
        await _sut.Delete(userId);

        //assert
        var expected = await _userRepository.GetByIdAsync(userId);
        expected.Should().BeNull();
    }



    [Fact]
    public async Task GetUser_UserService_Should_Return_User()
    {
        //arrange
        var user = new User("Hassan", 32, 200);
        var userId = await _userRepository.AddAsync(user);


        //act
        var actual= await _sut.GetById(userId);

        //assert
        actual.Should().Be(user);
        
    }




    [Fact]
    public async Task GetUsers_UserService_Should_Return_Users()
    {
        //arrange
        var user = new User("Hassan", 32, 200);
        var userId = await _userRepository.AddAsync(user);


        //act
        var actual = await _sut.GetAll();

        //assert
        actual.First().Should().Be(user);

    }
}
