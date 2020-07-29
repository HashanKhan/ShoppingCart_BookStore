using Microsoft.Extensions.Options;
using ShoppingCartApp.Domain.DTOs;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.EmailNotification;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShoppingCartApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        //Send Email Bill in Async to client.
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;
            message.IsBodyHtml = true;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            message.Body += "<h1>";
            message.Body += "Your Bill Information";
            message.Body += "</h1>";

            message.Body += "<table>";

            message.Body += "<tr>";
            message.Body += "<td>";
            message.Body += "<b>";
            message.Body += "Customer Name";
            message.Body += "</b>";
            message.Body += "</td>";
            message.Body += "<td style='text-align:center;'>";
            message.Body += mailRequest.Bill.Payment.CustomerName;
            message.Body += "</td>";
            message.Body += "</tr>";

            message.Body += "<tr>";
            message.Body += "<td>";
            message.Body += "<b>";
            message.Body += "Payment Amount";
            message.Body += "</b>";
            message.Body += "</td>";
            message.Body += "<td style='text-align:center;'>";
            message.Body += mailRequest.Bill.Payment.PaymentAmount;
            message.Body += "</td>";
            message.Body += "</tr>";

            message.Body += "<tr>";
            message.Body += "<td>";
            message.Body += "<b>";
            message.Body += "Payment Method";
            message.Body += "</b>";
            message.Body += "</td>";
            message.Body += "<td style='text-align:center;'>";
            message.Body += mailRequest.Bill.Payment.PaymentMethod;
            message.Body += "</td>";
            message.Body += "</tr>";

            message.Body += "<tr>";
            message.Body += "<td>";
            message.Body += "<b>";
            message.Body += "PayMent Date";
            message.Body += "</b>";
            message.Body += "</td>";
            message.Body += "<td style='text-align:center;'>";
            message.Body += mailRequest.Bill.Payment.PaymentDate;
            message.Body += "</td>";
            message.Body += "</tr>";

            message.Body += "<tr>";

            message.Body += "<td>";
            message.Body += "<b>";
            message.Body += "Items Bought :-";
            message.Body += "</b>";
            message.Body += "</td>";

            message.Body += "<td>";

            message.Body += "<tr>";

            message.Body += "<th>";
            message.Body += "Item Name";
            message.Body += "</th>";

            message.Body += "<th>";
            message.Body += "Quantity";
            message.Body += "</th>";

            message.Body += "<th>";
            message.Body += "Unit Price";
            message.Body += "</th>";

            message.Body += "</tr>";

            foreach (var i in mailRequest.Bill.ItemDetailList)
            {
                message.Body += "<tr>";

                message.Body += "<td style='text-align:center;'>";
                message.Body += i.Name;
                message.Body += "</td>";

                message.Body += "<td style='text-align:center;'>";
                message.Body += i.Quantity;
                message.Body += "</td>";

                message.Body += "<td style='text-align:center;'>";
                message.Body += i.UnitCost;
                message.Body += "</td>";

                message.Body += "</tr>";
            }

            message.Body += "</td>";

            message.Body += "</tr>";

            message.Body += "</table>";

            await smtp.SendMailAsync(message);
        }
    }
}
