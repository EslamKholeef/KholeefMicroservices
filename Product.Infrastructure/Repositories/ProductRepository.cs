using MongoDB.Bson;
using MongoDB.Driver;
using Product.Domain.Entities;
using Product.Domain.Interfaces;
using System.Diagnostics.Metrics;


namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductModel> _products;
        private readonly IMongoCollection<BsonDocument> _counters;
        public ProductRepository(IMongoClient client)
        {
            var database = client.GetDatabase("ProductDb");
            _products = database.GetCollection<ProductModel>("Products");
            _counters = database.GetCollection<BsonDocument>("Counters");
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ProductModel product)
        {
            var counterUpdate = await _counters.FindOneAndUpdateAsync(
                Builders<BsonDocument>.Filter.Eq("_id", "productId"),
                Builders<BsonDocument>.Update.Inc("sequenceValue", 1),
                new FindOneAndUpdateOptions<BsonDocument>
                {
                    ReturnDocument = ReturnDocument.After,
                    IsUpsert = true // Create the counter if it doesn't exist
                });

            int newId = counterUpdate["sequenceValue"].AsInt32;
            product.Id = newId; // Assign the new ID to the new product
            await _products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateAsync(ProductModel product)
        {
            var result = await _products.ReplaceOneAsync(
                p => p.Id == product.Id,
                product, 
                new ReplaceOptions { IsUpsert = false }  // Setting IsUpsert = false ensures it doesn't create a new document if the ID doesn't exist.
                ); 
            return result.ModifiedCount > 0;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            return await _products.Find(_ => true).ToListAsync();
            /*
             Why Use _ => true?
                It's a simple, readable way to indicate "no filter" or "get everything" in C# when using the MongoDB driver.
                Alternatively, you could use Builders<ProductModel>.Filter.Empty for the same result, but _ => true is more intuitive for developers familiar with lambda expressions.
             */
        }

        public async Task DeleteAsync(int id)
        {
            await _products.DeleteOneAsync(p => p.Id == id);
        }

        public async Task DeleteAllAsync()
        {
            await _products.DeleteManyAsync(_ => true);
        }
    }
}
