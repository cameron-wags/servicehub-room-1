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
        public async Task<IActionResult> Put(Guid id, [FromBody]Library.Models.Room roomMod)
        {
            var ctxItem = _repo.GetById(id);

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
                    _repo.Update(newCtxItem);
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
