namespace Domain.Contracts.MessageContracts
{
    public class GetMessageResponse
    {
        public int IdMessage { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string MessageText { get; set; }
        public DateTime SentDate { get; set; }
    }
}
