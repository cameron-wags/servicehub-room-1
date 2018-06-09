using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceHub.Room.Context.Models
{
    public class Settings
    {
        // Salesforce URLs
        public readonly string BaseURL;
        public readonly string GetById;

        // Database name
        public readonly string Database;

        // Collection name
        public readonly string CollectionName;

        // ConnectionString name
        public readonly string ConnectionString;

        public readonly string MetaDataId;
        public readonly string MetaDataCollectionName;

        public Settings(List<string> strings)
        {
            ConnectionString = strings[0];
            Database = strings[1];
            CollectionName = strings[2];
            MetaDataCollectionName = strings[3];
            MetaDataId = strings[4];
            BaseURL = strings[5];
            GetById = strings[6];
        }
    }
}
