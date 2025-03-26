using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VacationD.Api.Models;
using VacationD.Core;
using VacationD.Core.DTOs;
using VacationD.Core.Entities;
using VacationD.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VacationD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        //private readonly Mapping _mapping;
        private readonly IMapper mapper;
               public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _userService.GetAll();
            var listDto = _mapper.Map<IEnumerable<UserDto>>(list);
            return Ok(listDto);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            //var userDto = _mapping.MapToUserDto(user);
              var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] UserPostModel user)
        {var userToAdd=new User { name = user.name, email = user.email, password = user.password, role = user.role, VacationId = user.VacationId,};
            var newUser =await _userService.AddAsync(userToAdd);
            return Ok(newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            var updatedUser = _userService.Update(user);
            return Ok(updatedUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
 