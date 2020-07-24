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
    [Route("v1/scores")]
    // [Authorize]
    public class ScoreController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateScoreCommand command, [FromServices] ScoreHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        public IEnumerable<Score> GetAll([FromServices] DataContext context)
        {
            return context.Score.AsNoTracking();
        }

        [Route("{id:int}")]
        [HttpGet]
        public Score GetById([FromServices] DataContext context, int id)
        {
            return context.Score.AsNoTracking().Where(o => o.Id == id).FirstOrDefault();
        }

    }
}