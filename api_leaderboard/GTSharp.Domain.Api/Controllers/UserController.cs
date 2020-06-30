using System;
using System.Linq;
using System.Collections.Generic;
using GTSharp.Domain.Commands.Input;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GTSharp.Domain.Commands.Input.CreateCommand;

namespace GTSharp.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    // [Authorize]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateUserCommand command, [FromServices] UserHandler handler)
        {
            command.Email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            command.Name = User.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
            command.Avatar = User.Claims.FirstOrDefault(x => x.Type == "picture")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("{id:int}")]
        [HttpGet]
        public User GetById([FromServices] IUserRepository repository, int id)
        {
            return repository.GetById(id);
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<User> GetAll([FromServices] IUserRepository repository)
        {
            return repository.GetAll();
        }
    }
}