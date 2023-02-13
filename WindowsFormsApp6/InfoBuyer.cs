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
    public partial class InfoBuyer : Form
    {
        public InfoBuyer()
        {
            InitializeComponent();
            using (Model1Container model1 = new Model1Container())
            {
                foreach (User user in model1.UserSet)
                {
                    if (user.Buyer != null)
                    {
                        listBox1.Items.Add(user.Buyer.Name);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(Model1Container model1 = new Model1Container())
            {
                if(listBox1.SelectedItem != null)
                {
                    string SelectedName = Convert.ToString(listBox1.SelectedItem);
                    Buyer buyer=(from s in model1.BuyerSet where s.Name == SelectedName select s).FirstOrDefault();
                    textBox1.Text= buyer.Name;
                    textBox2.Text = buyer.Pasport;
                }
                else
                {
                    MessageBox.Show("Ошибка выбора");
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Formmanag formmanag = new Formmanag();
            formmanag.Show();
            this.Hide();
        }

        private void InfoBuyer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            MessageManag messageManag = new MessageManag();
            messageManag.Show();
            this.Hide();
        }
    }
}
