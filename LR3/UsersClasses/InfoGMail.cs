using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LR3.UsersClasses
{
    public class InfoGMail : InfoEmail
    {
        public InfoGMail(StringPair emailAdressTo, string subject, string body) : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.gmail.com";
            EmailAdressFrom = new StringPair("is25safronovaaa@artcollege.ru", "Сафронова Альбина Александровна");
            EmailPassword = "cwpp tqbj ohil cqtx";
            Port = 587;
        }
    }
}
