using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    public class RoomRepositoryMemory:IRoomsRepository
    {
        public List<Models.Room> roomList = new List<Models.Room>();

        public void Insert(Models.Room room)
        {
            throw new NotImplementedException();
        }

        public List<Models.Room> Get()
        {
            throw new NotImplementedException();
        }

        public Models.Room GetById(Guid id)
        {
            Models.Room room = roomList.Find(x => x.RoomId == id);
            return room;
        }

        public void Update(Models.Room room)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
