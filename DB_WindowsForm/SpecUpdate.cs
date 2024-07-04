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
    public partial class SpecUpdate : Form
    {
        int i;
        MySqlConnection con;
        string _id;
        private MySqlDataAdapter mySqlDataAdapter;
        public SpecUpdate(MySqlConnection conn,string id, string name)
        {
            InitializeComponent();
            con = conn;
            _id = id;
            textBox2.Text = name;
        }

        private void SpecUpdate_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE specialties SET  name_specialties ='" + textBox2.Text + "' WHERE idSpecialties= '" + _id + "'", con);
                if (con.State != ConnectionState.Open) con.Open();
                command.ExecuteNonQuery();
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
