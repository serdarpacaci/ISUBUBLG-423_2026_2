namespace IsubuSatis.Ortak
{
    public class ServisHataDto
    {
        public string Mesaj { get; set; }

        public string Detaylar { get; set; }

        public List<ServisValidationErrorInfo> ValidationHatalari { get; set; }

        public ServisHataDto()
        {
            ValidationHatalari = new List<ServisValidationErrorInfo>();
        }
    }
}

