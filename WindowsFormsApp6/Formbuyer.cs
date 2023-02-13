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
    public partial class Formbuyer : Form
    {
        public Formbuyer()
        {
            InitializeComponent();
            Form1.formbuyer=this;
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
        Infomanag infomanag = new Infomanag();
        

        private void buttonLook_Click(object sender, EventArgs e)
        {
            infomanag.Show();
            this.Hide();
        }

        private void Formbuyer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            MessageBuyer messageBuyer = new MessageBuyer();
            messageBuyer.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
