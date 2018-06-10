using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;

using ServiceHub.Room.Library;

namespace ServiceHub.Room.Service.Controllers
{
   
  [Route("api/[controller]")]
  public class RoomController : BaseController
  {
      private IRoomsRepository _context;
    public RoomController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
      : base(loggerFactory, queueClientSingleton) {}

    public async Task<IActionResult> Get()
    {
            //return await Task.Run(() => Ok());
        var myTask = Task.Run(() => _context.Get());
        List<Context.Models.Room> result = await myTask;

        return Ok(result);
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
            //return await Task.Run(() => Ok());
        var myTask = Task.Run(() => _context.GetById(id));
        Context.Models.Room result = await myTask;

        return Ok(result);
        }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Library.Room value)
    {
            //return await Task.Run(() => Ok());
        if (!value.isValidState(value))
        {
            return BadRequest();
        }

        Context.Models.Room room = ModelMapper.LibraryToContext(value);
        var myTask = Task.Run(() => _context.Insert(room));
        await myTask;

        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]Library.Room value)
    {
        Context.Models.Room room = ModelMapper.LibraryToContext(value);
        var myTask = Task.Run(() => _context.Update(room));
        await myTask;

        //return CreatedAtRoute("api/Room", new { Id = room.RoomId }, value);
        return StatusCode(203);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var myTask = Task.Run(() => _context.Delete(id));
        await myTask;

   
        return StatusCode(203);

        }

    protected override void UseReceiver()
    {
      var messageHandlerOptions = new MessageHandlerOptions(ReceiverExceptionHandler)
      {
        AutoComplete = false
      };

      queueClient.RegisterMessageHandler(ReceiverMessageProcessAsync, messageHandlerOptions);
    }

    protected override void UseSender(Message message)
    {
      Task.Run(() =>
        SenderMessageProcessAsync(message)
      );
    }
  }
}
