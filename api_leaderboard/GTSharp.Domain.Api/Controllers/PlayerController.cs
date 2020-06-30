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

        [Route("{id:int}")]
        [HttpGet]
        public Player GetById([FromServices] IPlayerRepository repository, int id)
        {
            return repository.GetById(id);
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<Player> GetAll([FromServices] IPlayerRepository repository)
        {
            return repository.GetAll();
        }
    }
}