namespace DTOs
{
    public class WebMessageDTO
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int SenderUserId { get; set; }
        public int RecipientUserId { get; set; }
        public string? MessageBody { get; set; }
    }
}
