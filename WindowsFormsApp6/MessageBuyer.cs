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
using System.Net.Mail;
namespace WindowsFormsApp6
{
    public partial class MessageBuyer : Form
    {
        public MessageBuyer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formbuyer formbuyer = new Formbuyer();
            formbuyer.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress(textBox1.Text); //отправитель
                MailAddress to = new MailAddress(textBox2.Text);//получатель
                MailMessage m = new MailMessage(from, to);//сообщение
                m.Subject = "Письмо";
                m.Body = "<h1>" + richTextBox1.Text + "</h1>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential(textBox1.Text, textBox3.Text);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("Не удалость отправить email");
            }
        }
    }
}
