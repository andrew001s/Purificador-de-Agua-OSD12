using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APIMongo.Models
{
    public class Water
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Ciudad { get; set; }
        public decimal? ph { get; set; }
        public decimal? Hardness { get; set; }
        public decimal? Solids { get; set; }
        public decimal? Sulfate { get; set; }
        public decimal? Turbidity { get; set; }
        public int? Potability { get; set; }
        public string? Date { get; set; }
    }
}
