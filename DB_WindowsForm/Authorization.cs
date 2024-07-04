using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Authorization : Form
    {
        MySqlConnection conn;
        private MySqlDataAdapter mySqlDataAdapter;
        public Authorization()
        {
            InitializeComponent();
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
            conn = new MySqlConnection(connStr);
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand();
            string sql = "SELECT * FROM users WHERE login = '" + textBox1.Text + "' AND passw =  md5('" + textBox2.Text + "');";
            mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
            mySqlDataAdapter.Fill(table);
            if (table.Rows.Count > 0)
            {
               string sql1 = "SELECT user_status FROM users WHERE login = '" + textBox1.Text + "' AND passw =  md5('" + textBox2.Text + "');";
                MySqlCommand command1 = new MySqlCommand(sql1, conn);
                conn.Open();
                string status = command1.ExecuteScalar().ToString();
                  Form1 newForm = new Form1(status);
                this.Visible = false;
                newForm.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
           

        }
    }
}
