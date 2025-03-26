using Microsoft.AspNetCore.Mvc;
using VacationD.Core.Entities;
using VacationD.Core.Services;
using VacationD.Core.Repositories;
using VacationD.Service;
using VacationD.Data.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacationD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWorkingHoursRepository _workingHoursRepository;

        public WorkingHoursController(IUserService userService, IWorkingHoursRepository workingHoursRepository)
        {
            _userService = userService;
            _workingHoursRepository = workingHoursRepository;

        }

        // GET: api/<WorkingHoursController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WorkingHoursController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/WorkingHours
        [HttpPost]
        public async Task<IActionResult> AddWorkingHours([FromBody] WorkingHours workingHours)
        {
            if (workingHours == null || workingHours.EndTime <= workingHours.StartTime)
            {
                return BadRequest("Invalid working hours data");
            }
            double totalHours = await _userService.GetTotalWorkedHoursAsync(
    workingHours.UserId,
    workingHours.date.Date + workingHours.StartTime,
    workingHours.date.Date + workingHours.EndTime);
            return Ok(new
            {
                Message = "Working hours added successfully!",
                TotalHoursWorked = totalHours
            });
        }

    }
    // PUT api/<WorkingHoursController>/
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] WorkingHours workingHours)
    {
        var updatedWorkingHours = _workingHoursRepository.Update(workingHours);
        return Ok(updatedWorkingHours);
    }

    private ActionResult Ok(object updatedWorkingHours)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _workingHoursRepository.Delete(id);
        return Ok();
    }
}


