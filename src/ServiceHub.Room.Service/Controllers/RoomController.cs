using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
using MongoDB.Bson;
using MongoDB.Bson.IO;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;
using System.Runtime.Serialization.Json;

=======
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;
>>>>>>> room-lib

namespace ServiceHub.Room.Service.Controllers
{

    [Route("api/Room")]
  public class RoomController : BaseController
  {
<<<<<<< HEAD
      private IRoomsRepository _context;

      public RoomController(ILoggerFactory loggerFactory,
          IRoomsRepository context /*, IQueueClient queueClientSingleton*/)
          : base(loggerFactory /*, queueClientSingleton*/)
      {
          _context = context;
      }
=======
      private static readonly RoomContext _context = new RoomContext(new RoomRepositoryMemory());
    public RoomController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
      : base(loggerFactory, queueClientSingleton) {}
>>>>>>> room-lib

    public async Task<IActionResult> Get()
    {
            //return await Task.Run(() => Ok());
        var myTask = Task.Run(() => _context.Get());
        List<Context.Models.Room> results = await myTask;

        return Ok(ModelMapper.ContextToLibrary(results));
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
            //return await Task.Run(() => Ok());
        var myTask = Task.Run(() => _context.GetById(id));
        Context.Models.Room result = await myTask;

        return Ok(ModelMapper.ContextToLibrary(result));
        }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Library.Models.Room value)
    {
        
        //return await Task.Run(() => Ok());
        if (!value.isValidState())
        {
                return BadRequest();
        }

        Context.Models.Room room = ModelMapper.LibraryToContext(value);
        var myTask = Task.Run(() => _context.Insert(room));
        await myTask;

        return StatusCode(201);
    }

<<<<<<< HEAD
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]Library.Models.Room value)
    {
        if (!value.isValidState())
        {
            return BadRequest();
        }
            Context.Models.Room room = ModelMapper.LibraryToContext(value);
            var myTask = Task.Run(() => _context.Update(room));
            await myTask;

            //return CreatedAtRoute("api/Room", new { Id = room.RoomId }, value);
            return StatusCode(202);
=======
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
>>>>>>> room-lib
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
