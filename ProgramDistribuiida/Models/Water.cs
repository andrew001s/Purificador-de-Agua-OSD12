using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProgramDistribuiida.Models
{
    public class Water
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string? Ciudad { get; set; }
        public decimal? ph { get; set; }
        public decimal? Hardness { get; set; }
        public decimal? Solids { get; set; }
        public decimal? Sulfate { get; set; }
        public decimal? Turbidity { get; set; }
        public int? Potability { get; set; }
        public string? date { get; set; }
    }
}
