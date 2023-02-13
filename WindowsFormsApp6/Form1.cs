using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Formbuyer formbuyer = new Formbuyer();
        public static Formmanag formmanag = new Formmanag();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (Model1Container container = new Model1Container())
                {
                    foreach (User user in container.UserSet)
                    {
                        if (textBoxLog.Text == user.Login && textBoxPass.Text == user.Password && user.Role == "Покупатель")
                        {
                            MessageBox.Show("Вход успешен!");
                            Formbuyer buyerForm = new Formbuyer();
                            this.Hide();
                            MessageBox.Show("Вы вошли под логином:" + user.Login);
                            formbuyer.label1.Text = "Приветствуем " + user.Login;
                            buyerForm.Show();
                            return;
                        }
                        else if (textBoxLog.Text == user.Login && textBoxPass.Text == user.Password && user.Role == "Менеджер")
                        {
                            MessageBox.Show("Вход успешен!");
                            Formmanag managForm = new Formmanag();
                            this.Hide();
                            MessageBox.Show("Вы вошли под логином:" + user.Login);
                            formmanag.label1.Text = user.Manager.Name;
                            managForm.Show();
                            return;
                        }
                        else if (textBoxLog.Text == "admin" && textBoxPass.Text == "123")
                        {
                            MessageBox.Show("Вход успешен!");
                            MessageBox.Show("Вы вошли в систему в качестве админа");
                            AdminAcc adminAcc = new AdminAcc();
                            adminAcc.Show();
                            this.Hide();
                            return;
                        }
                        
                    }
                    
                        MessageBox.Show("Логин или пароль указан не верно");
                }
            }
            catch
            {
                MessageBox.Show("Что-то произошло не так!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regist regist = new Regist();
            regist.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сделано Мухаметзяновым Маратом и Мухаметшиным Робертом");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecAcc recAcc = new RecAcc();
            recAcc.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
        

}
