using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NewProductStringBuilder
{
   static public class EmailHelper
    {
        static public void sendEmail(string to, string body, string title)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("divyesh2198@gmail.com");
                mail.To.Add(to);
                mail.Subject = title;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("divyesh2198@gmail.com", "");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }
    }
}
