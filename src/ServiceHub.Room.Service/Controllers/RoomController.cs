using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceHub.Room.Context.Repository;
using ServiceHub.Room.Context.Utilities;

namespace ServiceHub.Room.Service.Controllers
{

    [Route("api/Rooms")]
    public class RoomController : BaseController
    {
        private readonly IRoomsRepository _context;

        public RoomController(ILoggerFactory loggerFactory, IRoomsRepository repo) : base(loggerFactory)
        {
            _context = repo;
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <returns>All records, error code if failure occurs.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Context.Models.Room> ctxRooms;
            try
            {
                ctxRooms = await _context.GetAsync();
            }
            catch
            {
                return StatusCode(500);
            }

            var rooms = ModelMapper.ContextToLibrary(ctxRooms);

            if (rooms == null)
            {
                return StatusCode(500);
            }

            return Ok(rooms);
        }

        /// <summary>
        /// Gets one record by Guid.
        /// </summary>
        /// <param name="id">RoomId to search for.</param>
        /// <returns>A matching item if found, error otherwise.</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Cannot get with empty Guid.");
            }

            Context.Models.Room result;
            try
            {
                result = await _context.GetByIdAsync(id);
            }
            catch
            {
                return NotFound($"Resource does not exist under RoomId: {id}");
            }

            var room = ModelMapper.ContextToLibrary(result);

            if (room == null)
            {
                return StatusCode(500);
            }

            return Ok(room);
        }

        /// <summary>
        /// Creates a new record.
        /// </summary>
        /// <param name="value">A valid Room model.</param>
        /// <returns>Success status code if success or a failing status code if the record failed to create.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Library.Models.Room value)
        {
            if (value == null)
            {
                return BadRequest("Incorrect model.");
            }

            if (value.RoomId == Guid.Empty)
            {
                value.RoomId = Guid.NewGuid();
            }
        
            if (!value.isValidState())
            {
                return BadRequest("Complete model required for insertions.");
            }

            var room = ModelMapper.LibraryToContext(value);

            if (room == null)
            {
                return StatusCode(500);
            }

            try
            {
                await _context.InsertAsync(room);
            }
            catch
            {
                return BadRequest("Cannot insert duplicate record.");
            }

            return CreatedAtRoute("Rooms", new {id = value.RoomId}, value);
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="roomMod">A Room model with its RoomId and properties to be modified set.</param>
        /// <returns>The updated item if the update is successful, or an appropriate error code if the update fails.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Library.Models.Room roomMod)
        {
            if (roomMod == null)
            {
                return BadRequest("Incorrect model.");
            }

            if (roomMod.RoomId == Guid.Empty)
            {
                return BadRequest("Identifier required for record editing.");
            }
            
            Context.Models.Room ctxItem;
            try
            {
                ctxItem = await _context.GetByIdAsync(roomMod.RoomId);
            }
            catch
            {
                return NotFound($"Resource does not exist under RoomId: {roomMod.RoomId}");
            }
            
            var item = ModelMapper.ContextToLibrary(ctxItem);

            if (item == null)
            {
                return StatusCode(500);
            }

            var changeFlag = false;

            if (roomMod.Location != null)
            {
                item.Location = roomMod.Location;
                changeFlag = true;
            }

            if (roomMod.Gender != null)
            {
                item.Gender = roomMod.Gender;
                changeFlag = true;
            }

            if (roomMod.Vacancy != null)
            {
                item.Vacancy = roomMod.Vacancy;
                changeFlag = true;
            }

            if (!changeFlag)
            {
                return BadRequest("Trying to modify a read-only value.");
            }

            if (item.isValidState())
            {
                var newCtxItem = ModelMapper.LibraryToContext(item);
                if (newCtxItem != null)
                {
                    try
                    {
                        await _context.UpdateAsync(newCtxItem);
                    }
                    catch
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest("Edit would make the record invalid.");
            }

            return NoContent();
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="id">Route parameter. The Guid of the item to be looked up and modified.</param>
        /// <param name="roomMod">A Room model with the properties to be modified set.</param>
        /// <returns>The updated record if successful, an appropriate error code if the update fails.</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Library.Models.Room roomMod)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Identifier required for record editing.");
            }

            if (roomMod == null)
            {
                return BadRequest("Incorrect model.");
            }

            roomMod.RoomId = id;
            
            return await Put(roomMod);
        }

        /// <summary>
        /// Deletes a record by Guid.
        /// </summary>
        /// <param name="id">Guid of the record to be deleted.</param>
        /// <returns>Success code if the item was deleted, a failure status code if the delete failed.</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Item must have an Identifier");
            }

            try
            {
                var item = await _context.GetByIdAsync(id);

                if(item == null)
                {
                    return NotFound("Item not in Database");
                }
            }
            catch
            {
                return NotFound("Item not in Database");
            }

            try
            {
                await _context.DeleteAsync(id);
            }
            catch
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}