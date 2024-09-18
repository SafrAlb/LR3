using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using LR3.UsersClasses;

namespace LR3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tbMail.Text = "is25safronovaaa@artcollege.ru";
            tbName.Text = "Albina Safronova";
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMail.Text) ||
                    string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbSubject.Text) ||
                    string.IsNullOrWhiteSpace(tbBody.Text))
            {
                MessageBox.Show("Заполните все поля!"); return;
            }

            string smtp = "smtp.mail.ru";

            StringPair fromInfo = new StringPair("mffic@mail.ru", "Сафронова Альбина");
            string password = "KEqyRwgjqfYd1hDpQfEW";

            StringPair toInfo = new StringPair(tbMail.Text, tbName.Text);
            string subject = tbSubject.Text;
            string body = $"{DateTime.Now} \n" +
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{tbBody.Text}";

            InfoEmailSending info = new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            SendingEmail sendingemail = new SendingEmail(info);
            sendingemail.Send();

            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }
    }
}
