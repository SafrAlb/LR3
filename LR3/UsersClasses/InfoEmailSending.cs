using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LR3.UsersClasses
{
    public class InfoEmailSending
    {
        private string smtpClientAdress;
        private StringPair emailAdressFrom;
        private StringPair emailAdressTo;
        private string emailPassword;
        private string subject;
        private string body;   

        public InfoEmailSending(string smtpClientAdress,
            StringPair emailAdressFrom,
            string emailPassword,
            StringPair emailAdressTo,
            string subject,
            string body)
        {
            this.smtpClientAdress = String.IsNullOrWhiteSpace(smtpClientAdress) ?
            throw new Exception("Нельзя вставлять пробелы или пустое значение!") : smtpClientAdress;

            this.emailAdressFrom = emailAdressFrom ?? throw new ArgumentNullException(nameof(emailAdressFrom));

            this.emailPassword = String.IsNullOrWhiteSpace(emailPassword) ?
            throw new Exception("Нельзя вставлять пробелы или пустое значение!") : emailPassword;

            this.emailAdressTo = emailAdressTo ?? throw new ArgumentNullException(nameof(emailPassword));
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
            this.body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public string SmtpClientAdress
        {
            get { return smtpClientAdress; }
            set { smtpClientAdress = value; }
        }
        public StringPair EmailAdressFrom
        {
            get { return emailAdressFrom; }
            set { emailAdressFrom = value; }
        }
        public string EmailPassword
        {
            get { return emailPassword; }
            set { emailPassword = value; }
        }
        public StringPair EmailAdressTo
        {
            get { return emailAdressTo; }
            set
            {
                emailAdressTo = value;
            }
        }
        public string Subject
        {
            get { return subject; }
            set
            {
                subject = value;
            }
        }
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
            }
        }
    }
    public class StringPair
    {
        private string emailAdress;
        private string name;
        public StringPair(string emailAdress, string name)
        {
            this.emailAdress = String.IsNullOrWhiteSpace(emailAdress) ?
            throw new Exception("Нельзя вставлять пробелы или пустое значение!") :
            emailAdress;

            this.name = String.IsNullOrWhiteSpace(name) ?
            throw new Exception("Нельзя вставлять пробелы или пустое значение!") :
            name;
        }

        public string EmailAdress
        {
            get => emailAdress; set => emailAdress = value;
        }
        public string Name
        {
            get => name; set => name = value;
        }
    }     
}

   
