using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIPlanta.Models
{
    public class Water
    {

        public string? Ciudad { get; set; }
        public decimal? ph { get; set; }
        public decimal? Hardness { get; set; }
        public decimal? Solids { get; set; }
        public decimal? Sulfate { get; set; }
        public decimal? Turbidity { get; set; }
        public string? Date { get; set; }

    }
}
