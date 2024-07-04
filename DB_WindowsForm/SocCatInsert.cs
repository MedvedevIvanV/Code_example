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
    public partial class SocCatInsert : Form
    {
        MySqlConnection con;
        private int type;// 0 -insert, 1 - update
        private string _Applicants_idApplicants, _Subjects_idSubjects;
        string id;
        public SocCatInsert(MySqlConnection conn)
        {
            InitializeComponent();
            con = conn;
            type = 0;
        }
        public SocCatInsert(MySqlConnection conn, string _id, string _name, string _priority)
        {
            InitializeComponent();
            button1.Text = "Изменить";
            con = conn;
            type = 1;
            textBox1.Text = _name;
            textBox1.Text = _priority;
            id = _id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("INSERT INTO social_categories (name_social_categories, priority_social_categories) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    textBox1.Text = "";
                    textBox2.Text = "";
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
            if (type == 1)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("UPDATE scores SET name_social_categories = '" + textBox1.Text + "' AND priority_social_categories = '" + textBox2.Text + "' WHERE idSocial_categories= '" + id + "'", con);
                    if (con.State != ConnectionState.Open) con.Open();
                    command.ExecuteNonQuery();
                    textBox1.Text = "";
                    textBox2.Text = "";
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

        private void SocCatInsert_Load(object sender, EventArgs e)
        {

        }
    }
}
