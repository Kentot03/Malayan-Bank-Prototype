using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using Entities;

namespace DataAccess
{
    public class DBContext : IDisposable
    {
        protected virtual void Dispose(bool disposing)
        {
            database = null;
            client = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IMongoDatabase database;
        public MongoClient client;

        public DBContext()
        {
            //check if Parent is NetCore
            var isCore = ReadJson.IsNetCore("appsettings.json");
            if (isCore)
            {
                var results = ReadJson.ParseJson("appsettings.json");
                MongoClient client = new MongoClient(results.appSettings.MongoConnectionString);
                database = client.GetDatabase(results.appSettings.MongoDatabaseName);
            }
            else
            {
                string con = ConfigurationManager.AppSettings["MongoConnectionString"];
                string db = ConfigurationManager.AppSettings["MongoDatabaseName"];

                MongoClient client = new MongoClient(con);
                database = client.GetDatabase(db);
            }

            #region ==== GetCollections ====
            clientlogs = database.GetCollection<clientlogs>("clientlogs");
            Response = database.GetCollection<colResponse>("response");
            #endregion
        }

        #region ==== IMongoCollection ====
        public IMongoCollection<clientlogs> clientlogs;
        public IMongoCollection<colResponse> Response;
        #endregion
    }

}

