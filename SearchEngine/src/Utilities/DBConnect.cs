using System;
using System.Linq;
using MongoDB.Driver;

namespace Utilities
{
    public class DBConnect
    {
        public static MongoClient Connect()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://pacesetter:pacesetter@cluster0.whodz.mongodb.net/test");
            return dbClient;
        }
    }
}
