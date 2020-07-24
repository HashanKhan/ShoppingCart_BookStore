namespace ShoppingCartApp.EmailNotification
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public CustomerBill Bill { get; set; }
    }
}
