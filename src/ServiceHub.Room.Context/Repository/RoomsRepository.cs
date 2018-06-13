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

        public const string MongoDbIdName = "_id";
        protected readonly IMongoClient _client;
        protected readonly IMongoDatabase _db;
        private readonly IMongoCollection<Models.Room> _collection;
        private readonly HttpClient _salesforceapi;
        private readonly string _baseUrl;
        private readonly MetaData _metadata;
        private readonly string _MetaDataCollection;
        private readonly string _metadataId;
        private long _CurrentCount;

        public RoomsRepository(Settings settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(mongoSettings);
            _salesforceapi = new HttpClient();
            _baseUrl = settings.BaseURL;
            _MetaDataCollection = settings.MetaDataCollectionName;
            _metadataId = settings.MetaDataId;
            _db = _client.GetDatabase(settings.Database);
            _collection = _db.GetCollection<Models.Room>(settings.CollectionName);
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
            
            return _collection.AsQueryable().AsEnumerable().ToList();
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
