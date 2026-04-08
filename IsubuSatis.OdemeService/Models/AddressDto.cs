namespace IsubuSatis.OdemeService.Models
{
    public class AddressDto
    {
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Cadde { get; set; }
        public string BinaNo { get; set; }
        public string DaireNo { get; set; }
    }

    public class OdemeDto
    {
        public string CardName { get; set; }
        public string CardNumarasi { get; set; }
        public string Ay { get; set; }
        public string Yil { get; set; }
        public string Cv2 { get; set; }
        public decimal ToplamTutar { get; set; }

        public SiparisDto Siparis { get; set; }
    }

    public class SiparisDto
    {
        public SiparisDto()
        {
            SiparisUrunleri = new List<SiparisItemDto>();
        }

        public string UserId { get; set; }

        public List<SiparisItemDto> SiparisUrunleri { get; set; }

        public AddressDto Address { get; set; }
    }

    public class SiparisItemDto
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunImageUrl { get; set; }
        public decimal Fiyat { get; set; }
    }
}
