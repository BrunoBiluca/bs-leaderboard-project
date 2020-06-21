using System;
using System.Collections.Generic;
using GTSharp.Domain.Commands.Input;
using GTSharp.Domain.Commands.Output;
using GTSharp.Domain.Entities;
using GTSharp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GTSharp.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/players")]
    public class PlayerController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreatePlayerCommand command, [FromServices] PlayerHandler handler)
        {
            // command.NickName = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("{id:guid}")]
        [HttpGet]
        public Player GetById([FromServices] IPlayerRepository repository, Guid id)
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