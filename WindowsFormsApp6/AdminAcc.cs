using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class AdminAcc : Form
    {
        public AdminAcc()
        {
            InitializeComponent();
            groupBox3.Hide();
            groupBox4.Hide();
            UpdateListBox();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void UpdateListBox()
        {
            using (Model1Container model1 = new Model1Container())
            {
                foreach (User user in model1.UserSet)
                {
                    if (user.Buyer != null || user.Manager != null)
                    {
                        listBox1.Items.Add(user.Login);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox4.Show();
            buttonVzaim.Text = "Удалить";
            using (Model1Container model1 = new Model1Container())
            {
                foreach (User user in model1.UserSet)
                {
                    listBox1.Text=user.Login;
                }
            }

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox4.Show();
            buttonVzaim.Text = "Добавить";
            using (Model1Container model1 = new Model1Container())
            {
                foreach (User user in model1.UserSet)
                {
                    listBox1.Text = user.Login;
                }
            }
        }

        private void buttonVzaim_Click(object sender, EventArgs e)
        {
            if (buttonVzaim.Text == "Удалить")
            {
                using (Model1Container model1 = new Model1Container())
                {
                    string str = Convert.ToString(listBox1.SelectedItem);
                    User user = (from t in model1.UserSet where t.Login == str select t).FirstOrDefault();
                    model1.UserSet.Remove(user);
                    model1.SaveChanges();
                }
            }
            else if (buttonVzaim.Text == "Добавить")
            {
                if (comboBoxRole.SelectedItem == null || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Не введено");
                }
                else if (comboBoxRole.SelectedItem.ToString() == "Покупатель")
                {
                    using (Model1Container model = new Model1Container())
                    {
                        Buyer buyer = new Buyer() { Name = textBox5.Text, Pasport = textBox6.Text };
                        model.BuyerSet.Add(buyer);
                        model.SaveChanges();
                        User user = new User() { Buyer = buyer, Login = textBox7.Text, Password = textBox8.Text, Role = (string)comboBoxRole.SelectedItem };
                        model.UserSet.Add(user);
                        model.SaveChanges();
                    }
                }
                else if (comboBoxRole.SelectedItem.ToString() == "Менеджер")
                {
                    using (Model1Container model = new Model1Container())
                    {
                        Manager manager = new Manager() { Name = textBox5.Text, Salary = textBox6.Text };
                        model.ManagerSet.Add(manager);
                        model.SaveChanges();
                        User user = new User() { Manager = manager, Login = textBox7.Text, Password = textBox8.Text, Role = (string)comboBoxRole.SelectedItem };
                        model.UserSet.Add(user);
                        model.SaveChanges();
                    }
                }
                UpdateListBox();
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Model1Container model1 = new Model1Container())
            {
                if (listBox1.SelectedItem != null)
                {
                    
                    string SelectedLogin = Convert.ToString(listBox1.SelectedItem);
                    User user = (from s in model1.UserSet where s.Login == SelectedLogin select s).FirstOrDefault();
                    textBox1.Text = user.Login;
                    textBox2.Text = user.Password;
                    textBox3.Text=user.Role;
                    if (user.Role == "Менеджер")
                    {
                        Manager manager=(from s in model1.ManagerSet select s).FirstOrDefault();
                        textBox4.Text = manager.Name;
                    }
                    else if (user.Role == "Покупатель")
                    {
                        Buyer buyer=(from s in model1.BuyerSet select s).FirstOrDefault();
                        textBox4.Text= buyer.Name;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка выбора");
                }
            }
        }

        private void AdminAcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
