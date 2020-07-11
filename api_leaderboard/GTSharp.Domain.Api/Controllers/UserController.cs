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
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

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
            command.Email = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? command.Email;
            command.Name = User.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? command.Email.Substring(0, 5);
            command.Picture = User.Claims.FirstOrDefault(x => x.Type == "picture")?.Value ?? "guest.png";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        public List<User> GetAll([FromServices] DataContext context)
        {
            return context.User.AsNoTracking()
                    .Include(o => o.Players).ToList();
        }

        [Route("{id:int}")]
        [HttpGet]
        public User GetById([FromServices] DataContext context, int id)
        {
            return context.User.AsNoTracking().Where(o => o.Id == id).ToList().FirstOrDefault();
        }

    }
}