namespace Domain.Contracts.MessageContracts
{
    public class SendMessageRequest
    {
        public int IdSender { get; set; }
        public int IdRecipient { get; set; }
        public string MessageText { get; set; }
    }
}
