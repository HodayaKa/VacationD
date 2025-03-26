
using VacationD.Core.Entities;
using VacationD.Core.Repositories;
using VacationD.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IWorkHoursCalculator _workHoursCalculator;

    public UserService(IUserRepository userRepository, IWorkHoursCalculator workHoursCalculator)
    {
        _userRepository = userRepository;
        _workHoursCalculator = workHoursCalculator;
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

    public IUserRepository Get_userRepository()
    {
        return _userRepository;
    }
    public async Task<double> GetTotalWorkedHoursAsync(int userId, DateTime start, DateTime end)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
            throw new Exception("User not found!");
     
        return await _workHoursCalculator.CalculateHoursWorkedAsync(user, start, end);
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

