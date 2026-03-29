using MongoDB.Bson.Serialization.Attributes;

namespace KatalogService.Models
{
    public class Urun
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Ad { get; set; }

        public decimal Fiyat { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        public string KategoriId { get; set; }

        [BsonIgnore]
        public Kategori KategoriFk { get; set; }
    }
}
