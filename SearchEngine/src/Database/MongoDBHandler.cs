using System;
using MongoDB.Driver;
using Utilities;

namespace Database
{
    public static class MongoDBHandler
    {
        public static void Connect(string DBUrl)
        {
            try
            {
                MongoClient dbClient = new MongoClient(DBUrl);

                var dbList = dbClient.ListDatabases().ToList();

                Console.WriteLine("The list of databases on this server is: ");
                foreach (var db in dbList)
                {
                    Console.WriteLine(db);
                }
            } catch(SystemException ex)
            {
                Logger.Error(ex.Message);
            }


        }
    }
}
