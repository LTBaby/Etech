using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Etech.AlphaMightyFoxtrot
{
    class MongoDB
    {
        public string searchTerm { get;set; }
        public void popm(BsonDocument document)
        {
            var client = new MongoClient("mongodb+srv://Trevor:Tp6859TreDoUX@cluster0.hu9lr.azure.mongodb.net/test");

            var db = client.GetDatabase("search_products");

            var collect = db.GetCollection<BsonDocument>("products");

            collect.InsertOneAsync(document);
        }

        public void SearchWordStore(BsonDocument document)
        {
            var client = new MongoClient("mongodb+srv://Trevor:Tp6859TreDoUX@cluster0.hu9lr.azure.mongodb.net/test");

            var db = client.GetDatabase("search_products");

            var collect = db.GetCollection<BsonDocument>("search_key");

            collect.InsertOneAsync(document);
        }

        //public string getSearchWords()
        //{
        //    var client = new MongoClient("mongodb+srv://Trevor:Tp6859TreDoUX@cluster0.hu9lr.azure.mongodb.net/test");

        //    var db = client.GetDatabase("search_products");

        //    var collect = db.GetCollection<BsonDocument>("search_key");

        //    var documents = collect.Find(new BsonDocument()).ToList();
        //    var k = documents.ToJson();
        //    return k;
        //}
        
        public string getSearchWords()
        {
            var client = new MongoClient("mongodb+srv://Trevor:Tp6859TreDoUX@cluster0.hu9lr.azure.mongodb.net/test");

            var db = client.GetDatabase("search_products");

            var collect = db.GetCollection<BsonDocument>("search_key");

            var documents = collect.Find(new BsonDocument()).ToList();

            var k = documents.ToJson();
            return k;
        }

        //public void SearchWord(BsonDocument document)
        //{
        //    var client = new MongoClient("mongodb+srv://Trevor:Tp6859TreDoUX@cluster0.hu9lr.azure.mongodb.net/test");

        //    var db = client.GetDatabase("search_products");

        //    var collect = db.GetCollection<BsonDocument>("search_key");

        //    var documents = collect.Find(new BsonDocument()).ToList()
        //}
    }
}
