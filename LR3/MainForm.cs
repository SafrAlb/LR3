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
using LR3.UsersСlasses;

namespace LR3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tbMail.Text = "is25safronovaaa@artcollege.ru";
            tbName.Text = "Albina Safronova";
            cbService.SelectedIndex= 0;
        }
        private bool IsNullorWhiteSpaceTB()
        {
            if (string.IsNullOrWhiteSpace(tbMail.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbSubject.Text) ||
                    string.IsNullOrWhiteSpace(tbBody.Text))
            {
                MessageBox.Show("Заполните все поля!"); return true;
            }
            return false;
        }
        private void TextBoxIsCleaning()
        {
            DialogResult result = MessageBox.Show("Очистить поля ввода?", "Сообщение", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
                foreach (TextBox textBox in Controls.OfType<TextBox>())
                    textBox.Text = "";
        }
        private InfoEmail SetInfoEmail(EmailsTypes type)
        {
            StringPair toInfo = new StringPair(tbMail.Text, tbName.Text);
            string subject = tbSubject.Text;
            string body = $"{DateTime.Now} \n" +
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{tbBody.Text}";
            if (type == EmailsTypes.GMail)
            {
                return new InfoGMail(toInfo, subject, body);
            }
            else
            {
                return new InfoMailRu(toInfo, subject, body);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (IsNullorWhiteSpaceTB())
            {
                return;
            }
            try
            {
                SendingEmail sendingEmail = new SendingEmail(SetInfoEmail(cbService.SelectedIndex.ToString() == "GMail" ? EmailsTypes.GMail : EmailsTypes.MailRu));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Письмо отправлено!");
            TextBoxIsCleaning();
        }
    }
}
