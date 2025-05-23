using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.Domain.Entities
{
    public class ProductModel
    {
        [BsonId] //Eslam: Marks this property as the MongoDB _id field
        // [BsonRepresentation(BsonType.ObjectId)] //Eslam: Ensures ObjectId is stored correctly
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }


        // [BsonRepresentation(BsonType.ObjectId)] //Eslam: Ensures ObjectId is stored correctly
        // public ObjectId Id { get; set; } // Or string

        /*
         Benefits of Using ObjectId (or string Representation)

         1- Uniqueness Across Collections and Databases:

            ObjectId is a 12-byte unique identifier that includes a timestamp, machine identifier, process ID, and a counter. This ensures uniqueness not just within a collection but across different collections and even databases, reducing the chance of ID collisions in distributed systems.
            Using an int requires you to implement your own mechanism for generating unique IDs (e.g., auto-increment), which can be challenging in a distributed microservices environment.
         2- Built-in Timestamp Information:

            ObjectId embeds a timestamp in its value, allowing you to extract the creation time of a document without needing an additional field. This is useful for auditing or sorting by creation time.
            With int, you'd need a separate field to track creation time if that's a requirement.
        3- Native Support in MongoDB:

           MongoDB is optimized for ObjectId as the default _id type. Queries, indexing, and sharding are designed around it. While you can use other types (like int), ObjectId integrates seamlessly with MongoDB's ecosystem.
           Using int might require additional configuration or custom handling in some edge cases.
        4- Scalability in Distributed Systems:

           In a microservices architecture, multiple services might insert records simultaneously. ObjectId handles this naturally without requiring a centralized ID generator. With int, you might need a centralized service or database sequence to ensure uniqueness, which can become a bottleneck.
        5- String Representation for APIs:

        When using ObjectId as a string, it aligns well with API contracts (e.g., JSON payloads) since most HTTP-based systems use strings for IDs. Using int is fine for APIs but doesn't offer the same uniqueness guarantees unless managed carefully.
                 */
    }
}
