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
    public partial class Formmanag : Form
    {
        
        public Formmanag()
        {
            InitializeComponent();
            Form1.formmanag = this;
            UpdateListBoxPokupka();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (Model1Container model1 = new Model1Container())
                {
                    Manager manager = (from p in model1.ManagerSet where p.Name == label1.Text select p).FirstOrDefault();
                    Pokupka pokupka = new Pokupka() { Tovar = textBox1.Text, Price = textBox2.Text, Manager = manager };
                    model1.PokupkaSet.Add(pokupka);
                    manager.Pokupka.Add(pokupka);
                    model1.SaveChanges();
                }
                UpdateListBoxPokupka();
            }
            catch
            {
                MessageBox.Show("Вы что-то не ввели");
            }
        }
        private void UpdateListBoxPokupka()
        {
            listBox1.Items.Clear();
            using(Model1Container model1=new Model1Container())
            {
                var PokupkaList = from t in model1.PokupkaSet select t;
                foreach(Pokupka pokupka in PokupkaList)
                {
                    listBox1.Items.Add(pokupka.Tovar);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (Model1Container model1 = new Model1Container())
                {
                    string str = Convert.ToString(listBox1.SelectedItem);
                    Pokupka pokupka = (from t in model1.PokupkaSet where t.Tovar == str select t).FirstOrDefault();
                    pokupka.Tovar = richTextBox2.Text;
                    model1.SaveChanges();
                }
                UpdateListBoxPokupka();
            }
            catch
            {
                MessageBox.Show("Вы не выбрали товар");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (Model1Container model1 = new Model1Container())
                {
                    string str = Convert.ToString(listBox1.SelectedItem);
                    Pokupka pokupka = (from t in model1.PokupkaSet where t.Tovar == str select t).FirstOrDefault();
                    model1.PokupkaSet.Remove(pokupka);
                    model1.SaveChanges();
                }
                UpdateListBoxPokupka();
            }
            catch
            {
                MessageBox.Show("Вы не выбрали товар");
            }
        }

        private void buttonLook_Click(object sender, EventArgs e)
        {
           InfoBuyer infobuyer = new InfoBuyer();
            infobuyer.Show();
            this.Hide();
        }

        private void Formmanag_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
