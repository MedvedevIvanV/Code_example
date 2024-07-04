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
    public partial class Form4 : Form
    {

        MySqlConnection conn;
        public Form4(MySqlConnection cont, string id, string name, DateTime birth, DateTime graduate, string passport, string soc_cat)
        {   
            InitializeComponent();
            // строка подключения к БД
            string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            textBox3.Text = id;
            textBox1.Text = name;
            dateTimePicker1.Value = birth;
            dateTimePicker2.Value = graduate;
            textBox2.Text = passport;

            string sql = "select idSocial_categories,name_social_categories from social_categories;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "name_social_categories";
            comboBox1.ValueMember = "idSocial_categories";
            if(soc_cat=="") comboBox1.SelectedIndex = -1;
            comboBox1.Text = soc_cat;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Enabled == false || comboBox1.SelectedIndex == -1)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE applicants SET full_name = '" + textBox1.Text + "',Date_of_Birth='" + string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value) + "', graduation_date='" + string.Format("{0:yyyy-MM-dd}", dateTimePicker2.Value) + "', passport_id='" + textBox2.Text + "' WHERE idApplicants='" + textBox3.Text + "'", conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменено");
                    this.Close();


                }
                if (comboBox1.Enabled == true && comboBox1.SelectedIndex != -1)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE applicants SET full_name = '" + textBox1.Text + "',Date_of_Birth='" + string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value) + "', graduation_date='" + string.Format("{0:yyyy-MM-dd}", dateTimePicker2.Value) + "', passport_id='" + textBox2.Text + "', Social_categories_idSocial_categories = '" + comboBox1.SelectedValue.ToString() + "' WHERE idApplicants='" + textBox3.Text + "'", conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменено");
                    this.Close();

                }
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

        private async void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "X")
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.Enabled = false;
                button2.Text = "+";
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;
                button2.Text = "X";
            }
        }
    }
}
