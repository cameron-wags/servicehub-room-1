using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;

namespace ServiceHub.Room.Service.Controllers {

    [Route("api/[controller]")]
    public class RoomController : BaseController
    {
        private readonly RoomContext _context;
        public RoomController(ILoggerFactory loggerFactory, IRoomsRepository repo) : base(loggerFactory)
        {
            _context = new RoomContext(repo);
        }
        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Room>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rooms = new List<Library.Models.Room>();
                foreach (var r in _context.Get())
                {
                    rooms.Add(Context.Utilities.ModelMapper.ContextToLibrary(r));
                }
                return await Task.Run(() => Ok(rooms));
            }
            catch
            {
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(Library.Models.Room))]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                Library.Models.Room room = Context.Utilities.ModelMapper.ContextToLibrary(_context.GetById(id));
                return await Task.Run(() => Ok(room));
            }
            catch
            {
                return new StatusCodeResult(500);
            }

        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var myTask = Task.Run(() => _context.GetById(id)); //needs new get overload that takes id
            ServiceHub.Room.Library.Models.Room result = Context.Utilities.ModelMapper.ContextToLibrary(await myTask);
            //this.HttpContext.Response.StatusCode = 200;
            return new ObjectResult(result);

        }
        */
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Library.Models.Room room)
        {
            try
            {
                if (!room.isValidState())
                {
                    return BadRequest();
                }
                Context.Models.Room val = Context.Utilities.ModelMapper.LibraryToContext(room);
                var myTask = Task.Run(() => _context.Insert(val));
                await myTask;
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]Library.Models.Room roomMod)
        {
            var ctxItem = _context.GetById(id);
            var item = Context.Utilities.ModelMapper.ContextToLibrary(ctxItem);

            if (roomMod.Location != null)
            {
                item.Location = roomMod.Location;
            }

            if (roomMod.Gender != null)
            {
                item.Gender = roomMod.Gender;
            }

            if (roomMod.Vacancy != null)
            {
                item.Vacancy = roomMod.Vacancy;
            }

            if (item.isValidState())
            {
                var newCtxItem = Context.Utilities.ModelMapper.LibraryToContext(item);
                if (newCtxItem != null)
                {
                    var myTask = Task.Run(() => _context.Update(newCtxItem));
                    await myTask;
                    return Ok(item);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest("Invalid change.");
            }
            //return await Task.Run(() => Ok()); 
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(System.Guid id)
        {
            try
            {
                var myTask = Task.Run(() => _context.Delete(id));
                await myTask;
                return new StatusCodeResult(200);
            }
            catch
            {
                return new StatusCodeResult(500);
            }

        }
    }
}
