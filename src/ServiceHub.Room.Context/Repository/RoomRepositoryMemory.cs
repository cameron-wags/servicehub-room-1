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
            roomList.Add(room);
        }

        public List<Models.Room> Get()
        {
            return roomList;
        }

        public Models.Room GetById(Guid id)
        {
            Models.Room room = roomList.Find(x => x.RoomId == id);
            return room;
        }

        public void Update(Models.Room room)
        {
            int index = roomList.IndexOf(room);
            if (index >= 0)
            roomList[index] = room;
        }

        public void Delete(Guid id)
        {
            roomList.Remove(roomList.Find(x => x.RoomId == id));
        }
    }
}
