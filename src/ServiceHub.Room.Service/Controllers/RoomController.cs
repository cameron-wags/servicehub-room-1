using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Azure.ServiceBus;
=======
>>>>>>> 157252833-room-controller
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;

namespace ServiceHub.Room.Service.Controllers
{
  [Route("api/[controller]")]
  public class RoomController : BaseController
  {
<<<<<<< HEAD
      private static readonly RoomContext _context = new RoomContext(new RoomRepositoryMemory());
    public RoomController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
      : base(loggerFactory, queueClientSingleton) {}
=======
    public RoomController(ILoggerFactory loggerFactory) : base(loggerFactory) {}
>>>>>>> 157252833-room-controller

    public async Task<IActionResult> Get()
    {
      return await Task.Run(() => Ok());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return await Task.Run(() => Ok());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]object value)
    {
      return await Task.Run(() => Ok());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody]Library.Models.Room roomMod) {
        var ctxItem = _context.GetById(id);
        
        var item = ModelMapper.ContextToLibrary(ctxItem);

        if (roomMod.Location != null) {
            item.Location = roomMod.Location;
        }

        if (roomMod.Gender != null) {
            item.Gender = roomMod.Gender;
        }

        if (roomMod.Vacancy != null) {
            item.Vacancy = roomMod.Vacancy;
        }

        if (item.isValidState()) {
            var newCtxItem = ModelMapper.LibraryToContext(item);
            if (newCtxItem != null) {
                    _context.Update(newCtxItem);
                return Ok(item);
            }
            else {
                return StatusCode(500);
            }
        }
        else {
            return BadRequest("Invalid change.");
        }

        //return await Task.Run(() => Ok());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      return await Task.Run(() => Ok());
    }
  }
}
