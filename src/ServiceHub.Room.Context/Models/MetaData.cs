using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ServiceHub.Room.Context.Models
{
    public class MetaData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string ModelId { get; set; }
        public DateTime LastModified { get; set; }
    }
}
