using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public partial class SpecInsert : Form
    {
        public SpecInsert()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                // создаём объект для подключения к БД string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value)
                MySqlConnection con = new MySqlConnection(connStr);
                MySqlCommand command = new MySqlCommand("INSERT INTO specialties (name_specialties) VALUES ('" + textBox1.Text + "')", con);
                con.Open();
                command.ExecuteNonQuery();
                textBox1.Text = "";
                con.Close();
                this.Close();
            }
            catch (MySqlException tr)
            {
                MessageBox.Show(tr.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вводе данных!");
            }

        }
    }
}
