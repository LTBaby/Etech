using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Etech.AlphaMightyFoxtrot
{
    class MongoDB
    {
        public void popm(BsonDocument document)
        {
            var client = new MongoClient("mongodb+srv://Trevor:Tp6859TreDoUX@cluster0.hu9lr.azure.mongodb.net/test");

            var db = client.GetDatabase("search_products");

            var collect = db.GetCollection<BsonDocument>("products");

            collect.InsertOneAsync(document);
        }

    }
}
