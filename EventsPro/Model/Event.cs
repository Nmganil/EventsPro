namespace EventsPro.Model
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Organizer { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string PhotoFileName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
    }
}
