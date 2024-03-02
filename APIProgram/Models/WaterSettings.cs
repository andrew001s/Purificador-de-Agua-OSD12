namespace APIMongo.Models
{
    public class WaterSettings: IWaterSettings
    {
        public string? MongoDbConnection { get; set; }
        public string? DatabaseName { get; set; }
        public string? CollectionName { get; set; }
    }
    public interface IWaterSettings
    {
         string? MongoDbConnection { get; set; }
         string? DatabaseName { get; set; }
         string? CollectionName { get; set; }
    }

}
