using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        MySqlConnection con;


        public Form2(MySqlConnection conn)
        {
            InitializeComponent();
            con = conn;
            string sql = "select idSocial_categories,name_social_categories from social_categories;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "name_social_categories";
            comboBox1.ValueMember = "idSocial_categories";

        }
        
        private async void Form2_Load(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {

            // создаём объект для подключения к БД string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value)
            if (comboBox1.Enabled == false)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO applicants (full_name, Date_of_Birth, graduation_date, passport_id) VALUES ('" + textBox1.Text + "','" + string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value) + "','" + string.Format("{0:yyyy-MM-dd}", dateTimePicker2.Value) + "','" + textBox4.Text + "')", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    comboBox1.Enabled = true;
                    comboBox1.SelectedIndex = 0;
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

            else
            {

                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO applicants (full_name, Date_of_Birth, graduation_date, passport_id, Social_categories_idSocial_categories) VALUES ('" + textBox1.Text + "','" + string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value) + "','" + string.Format("{0:yyyy-MM-dd}", dateTimePicker2.Value) + "','" + textBox4.Text + "', '" + comboBox1.SelectedValue.ToString() + "')", con);
                    con.Open();
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
