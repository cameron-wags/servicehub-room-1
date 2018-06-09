using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    public class RoomContext
    {
        private readonly IRoomsRepository _roomRepository;

        public RoomContext(IRoomsRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Insert(Models.Room room)
        {
            _roomRepository.Insert(room);
        }

        public List<Models.Room> Get()
        {
            return _roomRepository.Get();
        }

        public Models.Room GetById(Guid id)
        {
            return _roomRepository.GetById(id);
        }

        public void Update(Models.Room room)
        {
            _roomRepository.Update(room);
        }

        public void Delete(Guid id)
        {
            _roomRepository.Delete(id);
        }

    }
}
