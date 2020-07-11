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
    [Route("v1/game")]
    // [Authorize]
    public class GameController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateGameCommand command, [FromServices] GameHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        public IEnumerable<Game> GetAll([FromServices] DataContext context)
        {
            return context.Game.AsNoTracking()
            .Include(o => o.Players)
                .ThenInclude(p => p.Scores);
        }

        [Route("{id:int}")]
        [HttpGet]
        public Game GetById([FromServices] DataContext context, int id)
        {
            return context.Game.AsNoTracking()
            .Where(o => o.Id == id).Include(o => o.Players).FirstOrDefault();
        }

    }
}