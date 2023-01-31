namespace DTOs
{
    public class WebNewMessageDTO
    {
        public int SenderUserId { get; set; }
        public int RecipientUserId { get; set; }
        public string MessageBody { get; set; } = null!;
    }
}