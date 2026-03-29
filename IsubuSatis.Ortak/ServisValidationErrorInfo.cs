namespace IsubuSatis.Ortak
{
    public class ServisValidationErrorInfo
    {
        public string Message { get; set; }

        public List<string> Members { get; set; }

        public ServisValidationErrorInfo()
        {
            Members = new List<string>();
        }
    }
}

