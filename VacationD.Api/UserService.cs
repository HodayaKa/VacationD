﻿
using VacationD.Core.Entities;
using VacationD.Core.Repositories;
using VacationD.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService( IUserRepository userRepository)
    { 
        _userRepository = userRepository; 
    }

    internal static async Task<double> GetTotalWorkedHoursAsync(int userId, DateTime dateTime1, DateTime dateTime2)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public void Delete(int id)
    {
         _userRepository.Delete(id);
    }

   public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User? GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetList()
    {
        return _userRepository.GetList();
    }

    public User Update(User user)
    {
        return _userRepository.Update(user);
    }

    IEnumerable<object> IUserService.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<double> IUserService.GetTotalWorkedHoursAsync(int userId, DateTime dateTime1, DateTime dateTime2)
    {
        throw new NotImplementedException();
    }
}