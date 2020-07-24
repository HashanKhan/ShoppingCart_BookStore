using ShoppingCartApp.EmailNotification;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
