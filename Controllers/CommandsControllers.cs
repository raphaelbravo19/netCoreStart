
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using apirest.Models;
using Microsoft.EntityFrameworkCore;
namespace apirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;

            /* [HttpGet]
            public ActionResult<IEnumerable<string>> GetString()
            {
                return new string[] { "this", "is", "hard", "coded" };
            } */
        }
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommand(int id)
        {
            var command = _context.CommandItems.Find(id);
            if (command != null)
            {
                return command;
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<Command> CreateCommand(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("CreateCommand", new Command { Id = command.Id }, command);

        }
        [HttpPut("{id}")]
        public ActionResult<Command> UpdateCommand(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return command;

        }

        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommand(int id)
        {
            var command = _context.CommandItems.Find(id);
            if (command == null)
            {
                return BadRequest();
            }
            _context.Remove(command);
            _context.SaveChanges();

            return command;

        }
    }
}
