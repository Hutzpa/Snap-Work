using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SnapWork.ViewModels
{
    class Messager
    {

        /// <summary>
        /// Обычные метод для отправки уведомления о чём-то
        /// </summary>
        /// <param name="recipientEmail">почта получателя</param>
        /// <param name="name">имя получателя</param>
        public void SendMessage(string recipientEmail, string message)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("illia.bezuhlyi@nure.ua", "SnapWork");
                // кому отправляем
                MailAddress to = new MailAddress(recipientEmail);

                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "SnapWork";
                // текст письма
                m.Body = message;
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("illia.bezuhlyi@nure.ua", "TLnK5nd3");
                smtp.EnableSsl = true;
                smtp.Send(m);

            }
            catch (Exception ex)
            {
              
            }
        }
 
        public void SendMessage(string recipientEmail, string name, string password )
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("illia.bezuhlyi@nure.ua", "SnapWork");
                // кому отправляем
                MailAddress to = new MailAddress(recipientEmail);

                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "SnapWork";
                // текст письма
                m.Body = "Шановний користувачу, ваш новий пароль" + password;
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("illia.bezuhlyi@nure.ua", "TLnK5nd3");
                smtp.EnableSsl = true;
                smtp.Send(m);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
