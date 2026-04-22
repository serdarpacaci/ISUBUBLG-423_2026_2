using System.ComponentModel.DataAnnotations.Schema;

namespace IsubuSatis.Siparis.Domain
{
    [Table("SiparisUrunBilgi")]

    public class SiparisUrunBilgi :BaseEntity<int>
    {
        public string UrunAdi { get; set; }
        public string UrunId { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
    }
}