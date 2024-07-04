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
    public partial class Form5 : Form
    {
        MySqlConnection con;
        private int type;// 0 -insert, 1 - update
        private string _Applicants_idApplicants, _Subjects_idSubjects;
        public Form5(MySqlConnection conn)
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
            
            
            string _sql = "select idSubjects,nameSubject from subjects;";
            MySqlDataAdapter _adp = new MySqlDataAdapter(_sql, con);
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            comboBox2.DataSource = _ds.Tables[0];
            comboBox2.DisplayMember = "nameSubject";
            comboBox2.ValueMember = "idSubjects";
            type = 0; //insert
        }

        public Form5(MySqlConnection conn, string Applicants_idApplicants,string Subjects_idSubjects, string number_of_scores)
        {
            InitializeComponent();
            button1.Text = "Изменить";
            con = conn;
            string sql = "select idApplicants,CONCAT(passport_id, ' - ', full_name) as applicant from applicants;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "applicant";
            comboBox1.ValueMember = "idApplicants";


            string _sql = "select idSubjects,nameSubject from subjects;";
            MySqlDataAdapter _adp = new MySqlDataAdapter(_sql, con);
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            comboBox2.DataSource = _ds.Tables[0];
            comboBox2.DisplayMember = "nameSubject";
            comboBox2.ValueMember = "idSubjects";

            string applicants_idApplicants = Applicants_idApplicants;
            comboBox1.SelectedValue = applicants_idApplicants;
            comboBox2.SelectedValue = Subjects_idSubjects;
            textBox3.Text = number_of_scores;
            type = 1;//update

            _Applicants_idApplicants= Applicants_idApplicants;
            _Subjects_idSubjects= Subjects_idSubjects;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command;
                if (type == 0)
                {
                    command = new MySqlCommand("INSERT INTO scores (Applicants_idApplicants, Subjects_idSubjects, number_of_scores) VALUES ('" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox3.Text + "')", con);
                    if (con.State!=ConnectionState.Open) con.Open();
                    command.ExecuteNonQuery();
                    this.Close();
                }
                else if (type == 1)
                {
                    // MySqlCommand command = new MySqlCommand("UPDATE scores SET idScores = '" + textBox1.Text + "',Applicants_idApplicants='" + textBox4.Text + "',  Subjects_idSubjects='" + textBox2.Text + "', number_of_scores='" + textBox3.Text + "' WHERE idScores='" + textBox1.Text + "'", conn);

                    command = new MySqlCommand("UPDATE scores SET Applicants_idApplicants='" + comboBox1.SelectedValue.ToString() + "',  Subjects_idSubjects='" + comboBox2.SelectedValue.ToString() + "', number_of_scores='" + textBox3.Text + "' " +
                        " WHERE Applicants_idApplicants='" + _Applicants_idApplicants + "' AND  Subjects_idSubjects='" + _Subjects_idSubjects + "'", con);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
