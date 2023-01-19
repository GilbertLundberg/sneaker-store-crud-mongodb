using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_MongoDB
{
    internal class ProductODM
    {
        public ProductODM(string name, int size, int amount, string description)
        {
            this.Name = name;
            this.Size = size;
            this.Amount = amount;
            this.Description = description;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("size")]
        public int? Size { get; set; }

        [BsonElement("amount")]
        public int? Amount { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        
    }
}
