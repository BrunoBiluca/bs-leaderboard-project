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
    [Route("v1/players")]
    // [Authorize]
    public class PlayerController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreatePlayerCommand command, [FromServices] PlayerHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        public IEnumerable<Player> GetAll([FromServices] DataContext context)
        {
            return context.Player.AsNoTracking().Include(o => o.Scores).ToList();
        }

        [Route("{id:int}")]
        [HttpGet]
        public Player GetById([FromServices] DataContext context, int id)
        {
            return context.Player.AsNoTracking()
                    .Where(o => o.Id == id).Include(o => o.Scores).FirstOrDefault();
        }

    }
}