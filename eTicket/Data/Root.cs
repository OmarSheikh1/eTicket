namespace eTicket.Data
{
    public class Root
    {
        public int session { get; set; }
        public string msisdn { get; set; }
        public int time { get; set; }
        public Channel channel { get; set; }
        public ExistingStudent ExistingStudent { get; set; }
        public Menu menu { get; set; }
        public string enteredCode { get; set; }
        public Responses responses { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Channel
    {
        public string code { get; set; }
        public string id { get; set; }
    }

    public class ExistingStudent
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Menu
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Metadata
    {
        public string voucher { get; set; }
    }
    public class Responses
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string favouriteColour { get; set; }
    }
}
