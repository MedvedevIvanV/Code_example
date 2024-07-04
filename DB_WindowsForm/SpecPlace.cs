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
    public partial class SpecPlace : Form
    {
        MySqlConnection con;
        private int type;// 0 -insert, 1 - update
        private string Spec, Rec;
        public SpecPlace(MySqlConnection conn)
        {
            InitializeComponent();
            con = conn;
            string sql = "select idSpecialties,name_specialties from specialties;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "name_specialties";
            comboBox1.ValueMember = "idSpecialties";


            string _sql = "select idTypes_of_recruitment,name_types from types_of_recruitment;";
            MySqlDataAdapter _adp = new MySqlDataAdapter(_sql, con);
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            comboBox2.DataSource = _ds.Tables[0];
            comboBox2.DisplayMember = "name_types";
            comboBox2.ValueMember = "idTypes_of_recruitment";
            type = 0; //insert
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command;
                if (type == 0)
                {
                    command = new MySqlCommand("INSERT INTO specialities_place (Specialties_idSpecialties, Types_idTypes, total_place) VALUES ('" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox1.Text + "')", con);
                    con.Open();
                    command.ExecuteNonQuery();
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
    }
}
