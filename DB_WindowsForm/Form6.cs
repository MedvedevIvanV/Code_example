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
    public partial class Form6 : Form
    {
        int i;
        MySqlConnection conn;
        private MySqlDataAdapter mySqlDataAdapter;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM scores WHERE idScores='" + textBox1.Text + "'", conn);
            conn.Open();
            command.ExecuteNonQuery();
            textBox1.Text = "";
            Update();

        }
        private async void Update()
        {
            try
            {
                // строка подключения к БД
                string connStr = "server=localhost;user=root;database=variant21;password=vfqrfynjh71129;";
                // создаём объект для подключения к БД
                conn = new MySqlConnection(connStr);
                // запрос
                string sql = "SELECT * FROM scores;";
                // объект для чтения ответа сервера
                mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                int rowsGot = -1;
                DataSet DS = new DataSet();

                rowsGot = await mySqlDataAdapter.FillAsync(DS);
                dataGridView1.DataSource = DS.Tables[0];

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

            if (changes != null)
            {

                MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                mySqlDataAdapter.Update(changes);
                ((DataTable)dataGridView1.DataSource).AcceptChanges();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Update();
        }
    }
}
