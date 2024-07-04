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
    public partial class Form7 : Form
    {
        int i;
        MySqlConnection conn;
        private MySqlDataAdapter mySqlDataAdapter;
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("UPDATE scores SET idScores = '" + textBox1.Text + "',Applicants_idApplicants='" + textBox4.Text + "',  Subjects_idSubjects='" + textBox2.Text + "', number_of_scores='" + textBox3.Text + "' WHERE idScores='" + textBox1.Text + "'", conn);
            conn.Open();
            command.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Update();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Update();
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
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
    }
}
