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
    public partial class RecAcc : Form
    {
        public RecAcc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress("marat-559@mail.ru"); //отправитель
                MailAddress to = new MailAddress(textBox1.Text);//получатель
                MailMessage m = new MailMessage(from, to);//сообщение
                m.Subject = "Восстановление пароля";
                using (Model1Container db = new Model1Container())
                {
                    foreach (User user in db.UserSet)
                    {
                        if (textBox2.Text == user.Login)
                        {
                            m.Body = "<h1>Пароль: " + user.Password + "</h1>";
                        }
                    }
                }
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("marat-559@mail.ru", "DBwmB19eJWjpVgsxSYGV");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("Не удалость отправить email");
            }

        }

        private void RecAcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
