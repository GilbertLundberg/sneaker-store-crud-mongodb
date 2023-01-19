using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUD_MongoDB
{
    internal class MongoDAO : IDAO
    {
        IMongoCollection<ProductODM> collection;   
        public MongoDAO(string connectionString, string db) 
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(db);
            this.collection = database.GetCollection<ProductODM>("products");
        }

        public void CreateProduct(ProductODM product)
        {
            this.collection.InsertOne(product);
        }

        public void DeleteProduct(ObjectId id)
        {
            var deleteFilter = Builders<ProductODM>.Filter.Eq("Id",id);
            this.collection.DeleteOne(deleteFilter);
        }

        public List<ProductODM> GetAllProducts()
        {
            return this.collection.Find(new BsonDocument()).ToList();
            
        }

        public void UpdateProduct(ObjectId id, int amount)
        {
            var filter = Builders<ProductODM>.Filter.Eq("Id",id);
            var update = Builders<ProductODM>.Update.Set("Amount", amount);
            this.collection.UpdateOne(filter, update);
        }
    }
}
