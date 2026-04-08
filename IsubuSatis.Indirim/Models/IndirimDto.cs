namespace IsubuSatis.Indirim.Models
{
    [Dapper.Contrib.Extensions.Table("indirim")]
    public class IndirimDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Oran { get; set; }
        public string Kod { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
