using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Room.Service.Controllers
{
  [Route("api/[controller]")]
  public class RoomController : BaseController
  {
        public ServiceHub.Room.Context.Repository.IRoomsRepository repo = new ServiceHub.Room.Context.Repository.RoomsRepository();
    public RoomController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
      : base(loggerFactory, queueClientSingleton) {}

    public async Task<IActionResult> Get()
    {
      return await Task.Run(() => Ok());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
            var myTask = Task.Run(() => repo.GetById(id)); //needs new get overload that takes id
            ServiceHub.Room.Library.Room result = await myTask;
            return result;
            
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]ServiceHub.Room.Library.Room room)
    {
            var myTask = Task.Run(() => repo.Insert(room));//needs mapping
            return await Task.Run(() => Ok());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]object value)
    {
      return await Task.Run(() => Ok());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
            var myTask = Task.Run(() => repo.Delete(id)); //needs mapping
            ServiceHub.Room.Library.Room result = await myTask;
            return //ok;
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
