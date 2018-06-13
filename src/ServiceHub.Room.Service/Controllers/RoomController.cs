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


        //make a room context and passs it
        //dependancy injection, takes in the concretion as argument
        private Context.Repository.RoomContext _repo;

        public RoomController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
          : base(loggerFactory, queueClientSingleton) {
            _repo = new Context.Repository.RoomContext(new Context.Repository.RoomRepositoryMemory());
        }

        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Room>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rooms = new List<Library.Models.Room>();
                foreach (var r in _repo.Get())
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
                Library.Models.Room room = Context.Utilities.ModelMapper.ContextToLibrary(_repo.GetById(id));
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
            var myTask = Task.Run(() => _repo.GetById(id)); //needs new get overload that takes id
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
                var myTask = Task.Run(() => _repo.Insert(Context.Utilities.ModelMapper.LibraryToContext(room) ));
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Library.Models.Room room)
        {
            return await Task.Run(() => Ok()); 
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete(System.Guid id)
        {
            try
            {
                var myTask = Task.Run(() => _repo.Delete(id));
                await myTask;
                return new StatusCodeResult(200);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
            
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
