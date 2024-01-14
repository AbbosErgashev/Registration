using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Registration.Business.Models;
using Registration.Infrastructure.Entities;
using Registration.Infrastructure.IRepositories;

namespace Registration.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserRepository _user;
    private readonly IMapper _mapper;

    public UserController(IUserRepository user, IMapper mapper)
    {
        _user = user;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDTO userModel)
    {
        var userCreateModel = _mapper.Map<User>(userModel);

        await _user.CreateUser(userCreateModel);

        await _user.SaveChangesAsync();

        return Created("", userCreateModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUser = await _user.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<ReadUserDTO>>(getAllUser));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserById = await _user.GetUserById(id);

        if (getUserById is null) return NotFound();

        await _user.SaveChangesAsync();

        return Ok(_mapper.Map<ReadUserDTO>(getUserById));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var getUserForDelete = await _user.GetUserById(id);

        if (getUserForDelete is null) return NoContent();

        _user.DeleteUser(getUserForDelete);

        await _user.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO updateUserDTO)
    {
        var getUserForUpdate = await _user.GetUserById(id);

        if (getUserForUpdate is null) return NotFound();

        _mapper.Map(updateUserDTO, getUserForUpdate);

        await _user.UpdateUser(getUserForUpdate);

        await _user.SaveChangesAsync();

        return NoContent();
    }
}
