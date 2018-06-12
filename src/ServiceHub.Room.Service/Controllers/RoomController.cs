using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;
using System.Runtime.Serialization.Json;


namespace ServiceHub.Room.Service.Controllers
{

    [Route("api/Room")]
  public class RoomController : BaseController
  {
      private IRoomsRepository _context;

      public RoomController(ILoggerFactory loggerFactory,
          IRoomsRepository context /*, IQueueClient queueClientSingleton*/)
          : base(loggerFactory /*, queueClientSingleton*/)
      {
          _context = context;
      }

    public async Task<IActionResult> Get()
    {
            //return await Task.Run(() => Ok());
        var myTask = Task.Run(() => _context.Get());
        List<Context.Models.Room> result = await myTask;

        return Ok();
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
            //return await Task.Run(() => Ok());
        //var myTask = Task.Run(() => _context.GetById(id));
        //Context.Models.Room result = await myTask;

        return Ok();
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

    [HttpPut]
    public async Task<IActionResult> Put([FromBody]Library.Room value)
    {
        if (!value.isValidState(value))
        {
            return BadRequest();
        }
            Context.Models.Room room = ModelMapper.LibraryToContext(value);
            var myTask = Task.Run(() => _context.Update(room));
            await myTask;

            //return CreatedAtRoute("api/Room", new { Id = room.RoomId }, value);
            return StatusCode(202);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var myTask = Task.Run(() => _context.Delete(id));
        await  myTask;
        
        return StatusCode(200);

    }

    protected override void UseReceiver()
    {
      var messageHandlerOptions = new MessageHandlerOptions(ReceiverExceptionHandler)
      {
        AutoComplete = false
      };

      //queueClient.RegisterMessageHandler(ReceiverMessageProcessAsync, messageHandlerOptions);
    }

    protected override void UseSender(Message message)
    {
      Task.Run(() =>
        SenderMessageProcessAsync(message)
      );
    }
  }
}
