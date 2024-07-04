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
    public partial class RecInsert : Form
    {
        MySqlConnection con;
        private string ap, sp, ty;
        private int type;// 0 -insert, 1 - update
        public RecInsert(MySqlConnection conn)
        {
            InitializeComponent();

            con = conn;
            string sql = "select idApplicants,CONCAT(passport_id, ' - ', full_name) as applicant from applicants;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "applicant";
            comboBox1.ValueMember = "idApplicants";


            string _sql = "select idSpecialties,name_specialties from specialties;";
            MySqlDataAdapter _adp = new MySqlDataAdapter(_sql, con);
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            comboBox2.DataSource = _ds.Tables[0];
            comboBox2.DisplayMember = "name_specialties";
            comboBox2.ValueMember = "idSpecialties";

            string SQL = "select idTypes_of_recruitment,name_types from types_of_recruitment;";
            MySqlDataAdapter ADP = new MySqlDataAdapter(SQL, con);
            DataSet DS = new DataSet();
            ADP.Fill(DS);
            comboBox3.DataSource = DS.Tables[0];
            comboBox3.DisplayMember = "name_types";
            comboBox3.ValueMember = "idTypes_of_recruitment";
            button1.Text = "Добавить";
            type = 0; //insert
        }
        public RecInsert(MySqlConnection conn, string _applicant, string _specialties, string _types)
        {
            InitializeComponent();
            con = conn;
            string sql = "select idApplicants,CONCAT(passport_id, ' - ', full_name) as applicant from applicants;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "applicant";
            comboBox1.ValueMember = "idApplicants";


            string _sql = "select idSpecialties,name_specialties from specialties;";
            MySqlDataAdapter _adp = new MySqlDataAdapter(_sql, con);
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            comboBox2.DataSource = _ds.Tables[0];
            comboBox2.DisplayMember = "name_specialties";
            comboBox2.ValueMember = "idSpecialties";

            string SQL = "select idTypes_of_recruitment,name_types from types_of_recruitment;";
            MySqlDataAdapter ADP = new MySqlDataAdapter(SQL, con);
            DataSet DS = new DataSet();
            ADP.Fill(DS);
            comboBox3.DataSource = DS.Tables[0];
            comboBox3.DisplayMember = "name_types";
            comboBox3.ValueMember = "idTypes_of_recruitment";
            button1.Text = "Изменить";
            comboBox1.SelectedValue = _applicant;
            comboBox2.SelectedValue = _specialties;
            comboBox3.SelectedValue = _types;
            ap= _applicant;
            sp = _specialties;
            ty = _types;
            type = 1; //update

        }
        private void RecInsert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlCommand command;
            if (type == 0)
            {
   
                       command = new MySqlCommand("INSERT INTO recruitments (Applicants_idApplicants,Specialities_id, Types_id) VALUES ('" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.SelectedValue.ToString() + "', '" + comboBox3.SelectedValue.ToString() + "')", con);
                    if (con.State != ConnectionState.Open) con.Open();
                    command.ExecuteNonQuery();
                this.Close();
            }
            else if (type == 1)
            {

               command = new MySqlCommand("UPDATE recruitments SET Applicants_idApplicants='" + comboBox1.SelectedValue.ToString() + "',  Specialities_id='" + comboBox2.SelectedValue.ToString() + "', Types_id='" + comboBox3.SelectedValue.ToString() + "' " +
              " WHERE Applicants_idApplicants='"+ ap + "' AND  Specialities_id='" + sp + "' AND Types_id='" + ty + "'", con);
              
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
