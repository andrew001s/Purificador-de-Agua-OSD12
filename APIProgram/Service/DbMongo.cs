using MongoDB.Driver;
using APIMongo.Models;
using MongoDB.Bson;

namespace APIProgram.Service
{
    public class DbMongo
    {
        private IMongoCollection<Water> _db;
        public DbMongo(IWaterSettings settings)
        {
            var client = new MongoClient(settings.MongoDbConnection);
            var database = client.GetDatabase(settings.DatabaseName);
            _db = database.GetCollection<Water>(settings.CollectionName);
        }
        public List<Water> GetAll() => _db.Find(water => true).ToList();
        public Water Create(Water water)
        {
            _db.InsertOne(water);
            return water;
        }
        public List<Water> GetByCiudad(string ciudad)
        {
            return _db.Find(water => water.Ciudad == ciudad).ToList();
        }
        public List<Water> GetById(string id)
        {
            return _db.Find(water => water.Id == id).ToList();
        }
        public void Update(string id,Water water)
        {
            _db.ReplaceOne(water => water.Id == id, water);
        }
        public void Remove(string id)
        {
            var obid = new ObjectId(id);
            _db.DeleteOne(water => water.Id == id);
        }
    }
}
