using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Junior_Backend_Test
{
    internal class SendFile
    {
        private string mailFrom { get; set; }
        private string mailPassword { get; set; }
        private string nameMail { get; set; }
        private string mailTo { get; set; }
        private string mailSubject { get; set; }
        private string mailBody { get; set; }
        public SendFile()
        {
            string path = "../../../appsettings.json";
            string text = File.ReadAllText(path);
            var json = JObject.Parse(text);

            mailFrom = json["mailFrom"].ToString();
            mailPassword = json["mailPassword"].ToString();
            nameMail = json["nameMail"].ToString();
            mailTo = json["mailTo"].ToString();
            mailSubject = json["mailSubject"].ToString();
            mailBody = json["mailBody"].ToString();
        }

        public void SendToMail()
        {
            MailAddress from = new MailAddress(mailFrom, nameMail);

            MailAddress to = new MailAddress(mailTo);

            using (MailMessage mail = new MailMessage(from, to))
            {
                mail.Subject = mailSubject;
                mail.Body = mailBody;
                mail.IsBodyHtml = true;

                mail.Attachments.Add(new Attachment(@"Result.xml"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(mailFrom, mailPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            Console.WriteLine($"Сгенерированный файл был отправлен на почту: {mailTo}.");
        }
    }
}
