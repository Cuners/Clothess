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
    public partial class Regist : Form
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedItem==null || textBox1.Text=="" || textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
            {
                MessageBox.Show("Не введено");
            }
            else if (comboBoxRole.SelectedItem.ToString() == "Покупатель")
            {
                using (Model1Container model=new Model1Container())
                {
                    Buyer buyer=new Buyer() { Name=textBox1.Text, Pasport=textBox2.Text};
                    model.BuyerSet.Add(buyer);
                    model.SaveChanges();
                    User user=new User() { Buyer=buyer,Login=textBox3.Text,Password=textBox4.Text,Role=(string)comboBoxRole.SelectedItem};
                    model.UserSet.Add(user);
                    model.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрировались");
                }
            }
            else if (comboBoxRole.SelectedItem.ToString() == "Менеджер")
            {
                using (Model1Container model = new Model1Container())
                {
                    Manager manager = new Manager() { Name = textBox1.Text, Salary = textBox2.Text };
                    model.ManagerSet.Add(manager);
                    model.SaveChanges();
                    User user = new User() { Manager = manager, Login = textBox3.Text, Password = textBox4.Text, Role = (string)comboBoxRole.SelectedItem };
                    model.UserSet.Add(user);
                    model.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрировались");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form=new Form1();
            form.Show();
            this.Hide();
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxRole.SelectedItem.ToString() == "Покупатель")
            {
                groupBox3.Text = "Паспортные данные";
            }
            else if(comboBoxRole.SelectedItem.ToString() == "Менеджер")
            {
                groupBox3.Text = "Зарплата";
            }
        }

        private void Regist_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
