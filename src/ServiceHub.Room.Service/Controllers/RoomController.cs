using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Room.Service.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : BaseController
    {

        private ServiceHub.Room.Context.Repository.IRoomsRepository _repo;

        public RoomController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
          : base(loggerFactory, queueClientSingleton)
        {

            _repo = new ServiceHub.Room.Context.Repository.RoomsRepository();
        }

        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceHub.Room.Library.Models.Room>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rooms = _repo.Get();
                return await Task.Run(() => Ok(rooms));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var myTask = Task.Run(() => _repo.GetById(id)); //needs new get overload that takes id
            ServiceHub.Room.Library.Models.Room result = await myTask;
            this.HttpContext.Response.StatusCode = 200;
            return result;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ServiceHub.Room.Library.Models.Room room)
        {
            try
            {
                var myTask = Task.Run(() => _repo.Insert(room));//needs mapping
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ServiceHub.Room.Library.Models.Room room)
        {
            return await Task.Run(() => Ok());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(System.Guid id)
        {
            var myTask = Task.Run(() => _repo.Delete(id)); //needs mapping
            ServiceHub.Room.Library.Models.Room result = await myTask;
            return StatusCode(200);
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
