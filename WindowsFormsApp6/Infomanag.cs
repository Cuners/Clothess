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
    public partial class Infomanag : Form
    {
        public Infomanag()
        {
            InitializeComponent();
            using (Model1Container model1 = new Model1Container())
            {
                foreach (User user in model1.UserSet)
                {
                    if (user.Manager != null)
                    {
                        listBox1.Items.Add(user.Manager.Name);
                    }
                }
            }

        }

        private void listBoxVesh_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Model1Container model1 = new Model1Container())
            {
                if (listBox1.SelectedItem != null)
                {
                    string SelectedName = Convert.ToString(listBox1.SelectedItem);
                    Manager manager = (from s in model1.ManagerSet where s.Name == SelectedName select s).FirstOrDefault();
                    richTextBox1.Text = manager.Name;
                    richTextBox2.Text = manager.Salary;
                }
                else
                {
                    MessageBox.Show("Ошибка выбора");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formbuyer formbuyer = new Formbuyer();
            formbuyer.Show();
            this.Hide();
        }
    }
}
