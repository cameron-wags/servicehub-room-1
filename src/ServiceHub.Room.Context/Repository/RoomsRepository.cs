using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceHub.Room.Context.Models;

namespace ServiceHub.Room.Context.Repository
{
    public class RoomsRepository: IRoomsRepository
    {
        private readonly IMongoCollection<Models.Room> _collection;
     
        public RoomsRepository(IMongoCollection<Models.Room> collection)
        {
            _collection = collection;
        }
        public void Insert(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }
            _collection.InsertOne(room);
        }

        public List<Models.Room> Get()
        {
            if (_collection == null)
            {
                throw new ArgumentNullException(nameof(_collection));
            }

            return _collection.AsQueryable().ToList();

        }

        public Models.Room GetById(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Models.Room room = _collection.Find(x => x.RoomId == id).Single();
            return room;

        }

        public void Update(Models.Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            _collection.FindOneAndReplace(x => x.RoomId == room.RoomId, room);
        }

        public void Delete(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            _collection.DeleteOne(x => x.RoomId == id);
        }
    }
}
