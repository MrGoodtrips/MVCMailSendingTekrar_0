using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MVCMailSendingTekrar_0.CustomTools
{
    //Gmail hesabı ile Mail gönderme işlemleri yapacak iseniz öncelikle Gmail'ın ayarlarından diğer uygulamalardan Mail göndermeye izin ver seçeneğini işaretlemeniz gerekir...

    //yms3152test@gmail.com

    //password: 3152yms3152

    //Git'e bu projeyi gönderecekseniz (proje private olacaksa bile) kesinlikle şifre ve mail kısmını boş gönderin... Aynı zamanda kesinlikle Front End'de şifre ile ilgili bir şey yazılmasın...

    //Git ile çalışıyorsanız Git'e gönderdiğiniz dosyalarda şifre ile ilgili bir şeyler olmamasına çok dikkat etmelisiniz...

    public static class MailService
    {
        public static void Send(string receiver,string password = "3152yms3152", string body = "Test mesajıdır", string subject = "Email testi", string sender = "yms3152test@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Email işlemleri SMTP'ye göre yapılır...
            //Kullandığımız gmail hesabının başka uygulamalar tarafından mesaj gönderme özelliğinin açık olduğuna emin olmalıyız...

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using(MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}