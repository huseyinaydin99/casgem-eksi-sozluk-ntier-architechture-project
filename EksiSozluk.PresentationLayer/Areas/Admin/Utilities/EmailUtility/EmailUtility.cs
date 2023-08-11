using EksiSozluk.PresentationLayer.Areas.Admin.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.CoreLayer.Utilities.EmailUtility
{
    public static class EmailUtility
    {
        public static void SendEmail(RegisterViewModel registerViewModel, int x)
        {
            #region
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "huseyinaydin99@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", registerViewModel.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Giriş için onay kodunuz: " + x.ToString();
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Doğrulama kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("huseyinaydin99@gmail.com", "tcizvcpzzcpfxxoy");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            #endregion
        }

    }
}
