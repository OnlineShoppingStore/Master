using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.Domain.Abstract;
using System.Net;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart,ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                         emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1}(subtotal:{2:c})\n",
                            line.Quantity,
                            line.Product.Name,
                            subtotal);
                }
                body.AppendFormat("Total order value : {0:c}",
                     cart.ComputeTotalValue())
                     .AppendLine("---")
                     .AppendLine("Ship to:")
                     .AppendLine(shippingInfo.Name)
                     .AppendLine(shippingInfo.Line1)
                     .AppendLine(shippingInfo.Line2 ?? "")
                     .AppendLine(shippingInfo.Line1 ?? "")
                     .AppendLine(shippingInfo.City)
                     .AppendLine(shippingInfo.Province ?? "")
                     .AppendLine(shippingInfo.Country)
                     .AppendLine(shippingInfo.PostalCode)
                     .AppendLine(".......")
                     .AppendFormat("gift wrap :(0)",
                     shippingInfo.GiftWrap ? "YES" : "No");
                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "New order Submitted !",
                    body.ToString());

                smtpClient.Send(mailMessage);

            }
        }

    }
}
                 
