using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using inz.Service;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var fromAddress = new MailAddress("michalpaInz@gmail.com");
        var toAddress = new MailAddress(email);
        string fromPassword = "redacted";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            Timeout = 10000
        };

        using (var mail = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = message
        })
        {
            mail.IsBodyHtml = true;
            smtp.Send(mail);
        }



        return Task.CompletedTask;
    }
}

