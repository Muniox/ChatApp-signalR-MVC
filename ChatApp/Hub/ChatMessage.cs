namespace ChatApp.Hub
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            CreatedOn = DateTime.Now;
        }

        public string UserName { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public string FormattedCreatedOn => CreatedOn.ToString("yyyy-MM-dd, HH:mm:ss");
    }
}
