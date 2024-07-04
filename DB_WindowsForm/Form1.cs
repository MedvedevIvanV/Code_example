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
    public partial class Form1 : Form
    {
        int i;
        MySqlConnection conn;
        private MySqlDataAdapter mySqlDataAdapter;
        public Form1(string _status)
        {

            InitializeComponent();
            if(String.Equals(_status, "0"))
            {
                label1.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox2.Visible = false;
                button3.Visible = false;
                button9.Visible = false;
                button1.Visible = false;
                button10.Visible = false;

            }
            textBoxLog.Text = "LOG\r\n";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = ((DataTable)dataGridView1.DataSource).GetChanges();

            if (changes != null)
            {

                MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
                mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                textBoxLog.Text += "Rows has been updated: " + changes.Rows.Count.ToString() + "\r\n";
                mySqlDataAdapter.Update(changes);
                ((DataTable)dataGridView1.DataSource).AcceptChanges();
            }
        }     
       
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            label4.Visible = true;
            comboBox5.Visible = true;
            i = comboBox1.SelectedIndex;
            this.Width=759;
            this.Height=692;
            dataGridView1.Width = 482;
            dataGridView1.Height = 249;
            int j = 0;
            textBoxLog.Width = 720;
            textBoxLog.Height = 156;
            if (i == 0)
            {
                try
                {
                    //dataGridView1.AutoResizeColumns();
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView1.AutoSizeRowsMode =
                    //DataGridViewAutoSizeRowsMode.AllCells;
                    // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    /*  foreach (DataGridViewColumn column in dataGridView1.Columns)
                          column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                      this.Width = dataGridView1.Width + 500;*/
                    // dataGridView1.AutoSizeColumnsMode = true;
                    // строка подключения к БД
                 
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                     conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT idApplicants as Номер,full_name as ФИО,Date_of_Birth as `Дата рождения`,graduation_date as `Дата выпуска`,passport_id as `Номер паспорта`,name_social_categories as `Социальная категория` FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories;";
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
              //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                   rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        j += dataGridView1.Columns[i].Width;
                    }
                    this.Width += j - dataGridView1.Width + 60;
                    textBoxLog.Width += j - dataGridView1.Width + 60; 
                    dataGridView1.Width +=j- dataGridView1.Width+60;

                    // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // dataGridView1.Width = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) +
                    // dataGridView1.ColumnHeadersHeight + 1000;



                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    textBoxLog.Text += ex.Message + "\r\n";
                }

            }
            if (i == 2)
            {
                try
                {                    
                     // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT idSubjects as `Номер предмета`, nameSubject as `Название предмета` FROM subjects;";
                    
                    
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
          
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                     for (int i = 0; i < dataGridView1.Rows.Count; i++)
                     {
                         j += dataGridView1.Rows[i].Height;
                     }
                  //   this.Width += j - dataGridView1.Width + 60;
                     dataGridView1.Height += j- dataGridView1.Height + 23;
                   

                    //  dataGridView1.Width = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) +
                    // dataGridView1.ColumnHeadersHeight;


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i == 1)
            {


                try
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name as `ФИО`, applicants.passport_id as `Номер паспорта`, subjects.nameSubject as `Предмет`, number_of_scores as `Баллы` " +
                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects; ";
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        j += dataGridView1.Columns[i].Width;
                    }
                    this.Width += j - dataGridView1.Width -212;
                    textBoxLog.Width += j - dataGridView1.Width - 212;
                    dataGridView1.Width += j-dataGridView1.Width-212;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height += 50;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i == 6)
            {

                try
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT idSpecialties as `Номер специальности`,name_specialties as `Специальность` FROM specialties;";
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        j += dataGridView1.Rows[i].Height;
                    }
                    //   this.Width += j - dataGridView1.Width + 60;
                    dataGridView1.Height += j - dataGridView1.Height + 23;

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i == 5)
            {
                try
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT idTypes_of_recruitment as `Номер вида набора`, name_types as `Тип набора` FROM types_of_recruitment;";
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        j += dataGridView1.Rows[i].Height;
                    }
                    //   this.Width += j - dataGridView1.Width + 60;
                    dataGridView1.Height += j - dataGridView1.Height + 23;



                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i == 4)
            {
                try
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                   conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT Applicants_idApplicants,Specialities_id,Types_id,full_name as `ФИО`,passport_id as `Номер паспрорта`,name_specialties as `Специальность`,name_types as `Тип набора`,status as `Статус зачисления`,date_of_enrollment as `Дата зачисления` FROM recruitments INNER JOIN specialties ON recruitments.Specialities_id = specialties.idSpecialties INNER JOIN types_of_recruitment ON recruitments.Types_id = types_of_recruitment.idTypes_of_recruitment INNER JOIN applicants ON recruitments.Applicants_idApplicants = applicants.idApplicants;";
                    // объект для чтения ответа сервера
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        j += dataGridView1.Columns[i].Width;
                    }
                    this.Width += j - dataGridView1.Width -257;
                    textBoxLog.Width += j - dataGridView1.Width - 257;
                    dataGridView1.Width += j - dataGridView1.Width - 257;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height += 50;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i == 3)
            {

                try
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT idSocial_categories as `Номер категории`,name_social_categories as `Название категории`,priority_social_categories as `Приоритет категории` FROM social_categories;";
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                    int rowsGot = -1;
                    DataSet DS = new DataSet();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        j += dataGridView1.Rows[i].Height;
                    }
                    //   this.Width += j - dataGridView1.Width + 60;
                    dataGridView1.Height += j - dataGridView1.Height + 23;




                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i == 7)
            {

                try
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT name_specialties as 'Специальность',name_types  as 'Тип набора',total_place  as 'Всего мест',math_min  as 'Минимальный балл по математике',rus_min as 'Минимальный балл по рус.яз.',social_science_min as 'Минимальный балл по обществознанию',sum_min as 'Минимальная сумма баллов'FROM specialities_place INNER JOIN specialties ON specialities_place.Specialties_idSpecialties = specialties.idSpecialties INNER JOIN types_of_recruitment ON specialities_place.Types_idTypes = types_of_recruitment.idTypes_of_recruitment;";
                    // объект для чтения ответа сервера
                    mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                    int rowsGot = -1;
                    DataSet DS = new DataSet();

                    rowsGot = await mySqlDataAdapter.FillAsync(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        j += dataGridView1.Columns[i].Width;
                    }
                    this.Width += j - dataGridView1.Width + 60;
                    textBoxLog.Width += j - dataGridView1.Width + 60;
                    dataGridView1.Width += j - dataGridView1.Width + 60;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            comboBox3.Items.Clear();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                comboBox3.Items.Add(dataGridView1.Columns[i].HeaderText);
            comboBox4.Items.Clear();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                comboBox4.Items.Add(dataGridView1.Columns[i].HeaderText);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                Form2 newForm = new Form2(conn);
                newForm.Show();
            }
            if (i == 1)
            {
                Form5 newForm = new Form5(conn);
                newForm.Show();
            }
            if (i == 3)
            {
                SocCatInsert newForm = new SocCatInsert(conn);
                newForm.Show();
            }
            if (i == 4)
            {
             RecInsert newForm = new RecInsert(conn);
             newForm.Show();
            }
            if (i == 6)
            {
                SpecInsert newForm = new SpecInsert();
                newForm.Show();
            }
            if (i == 7)
            {
                SpecPlace newForm = new SpecPlace(conn);
                newForm.Show();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM applicants WHERE idApplicants='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", conn);
                conn.Open();
                command.ExecuteNonQuery();
                comboBox1_SelectedIndexChanged(this,null);
                conn.Close();
            }
            if (i == 1)
            {
                //string sql = "SELECT full_name,passport_id,nameSubject,number_of_scores FROM scores INNER JOIN applicants ON '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' = applicants.full_name INNER JOIN subjects ON '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' = subjects.nameSubject;";
                string sql = "select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name,subjects.nameSubject, number_of_scores from scores   join applicants on scores.Applicants_idApplicants = applicants.idApplicantsjoin subjects on scores.Subjects_idSubjects = subjects.idSubjects;";
               // select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name,subjects.nameSubject, number_of_scores from scores   join applicants on scores.Applicants_idApplicants = applicants.idApplicantsjoin subjects on scores.Subjects_idSubjects = subjects.idSubjects;
                // MySqlCommand command = new MySqlCommand("DELETE FROM scores  INNER JOIN applicants ON 'Владиславов Владислав Владиславович' = applicants.full_name INNER JOIN subjects ON 'русский язык' = subjects.nameSubject", conn);
                MySqlCommand command = new MySqlCommand("DELETE FROM scores WHERE Applicants_idApplicants= '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' AND Subjects_idSubjects = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            if (i == 3)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM social_categories WHERE idSocial_categories='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", conn);
                conn.Open();
                command.ExecuteNonQuery();
                comboBox1_SelectedIndexChanged(this, null);
                conn.Close();
            }
            if (i == 4)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM recruitments  WHERE Applicants_idApplicants='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' AND  Specialities_id='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' AND Types_id='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", conn);
                conn.Open();
                command.ExecuteNonQuery();
                comboBox1_SelectedIndexChanged(this, null);
                conn.Close();
            }
            if (i == 6)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM specialties  WHERE idSpecialties='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", conn);
                conn.Open();
                command.ExecuteNonQuery();
                comboBox1_SelectedIndexChanged(this, null);
                conn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
              string _id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
              string _name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DateTime _birth = Convert.ToDateTime(string.Format("{0:dd.MM.yyyy}", dataGridView1.CurrentRow.Cells[2].Value));
                DateTime _graduate =  Convert.ToDateTime(string.Format("{0:dd.MM.yyyy}", dataGridView1.CurrentRow.Cells[3].Value));
                string _passport = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string soc_cat = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Form4 newForm = new Form4(conn, _id, _name, _birth, _graduate, _passport, soc_cat);
              newForm.Show();
            }
            if (i == 1)
            {
                string _id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string _sub = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string _score = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Form5 newForm = new Form5(conn, _id, _sub, _score);
                newForm.Show();
            }
            if (i == 3)
            {
                string _id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string _name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string _priority = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                SocCatInsert newForm = new SocCatInsert(conn, _id, _name, _priority);
                newForm.Show();
            }
            if (i == 4)
            {
                string _applicants = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string _spec = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string _type = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                RecInsert newForm = new RecInsert(conn, _applicants, _spec, _type);
                newForm.Show();
            }
            if (i == 6)
            {
                string _id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string _name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                SpecUpdate newForm = new SpecUpdate(conn, _id, _name);
                newForm.Show();
            }
            if (i == 7)
            {

            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            i = comboBox1.SelectedIndex;
            if (i == 0)
            {
                try
                {
                    // строка подключения к БД
                    string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                    // создаём объект для подключения к БД
                    conn = new MySqlConnection(connStr);
                    // запрос
                    string sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories WHERE applicants.full_name LIKE '%" + textBox1.Text + "%' OR Date_of_Birth LIKE '%" + textBox1.Text + "%' OR graduation_date LIKE '%" + textBox1.Text + "%' OR passport_id LIKE '%" + textBox1.Text + "%' OR social_categories.name_social_categories LIKE '%" + textBox1.Text + "%';";
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
                    textBoxLog.Text += ex.Message + "\r\n";
                }

            }
       
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "";
            int j = comboBox1.SelectedIndex;
            i = comboBox2.SelectedIndex;
            int k = comboBox5.SelectedIndex;
            if (j == 0)
            {
                try
                {
                    if (k == 0)
                    {
                        if (i == 0)
                            sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY `" + comboBox4.SelectedItem.ToString() + "`;";
                        if (i == 1)
                            sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY `" + comboBox4.SelectedItem.ToString() + "` DESC;";
                    }
                    if (k == 1)
                    {
                        if (i == 0)
                            sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY `" + comboBox4.SelectedItem.ToString() + "`, `" + comboBox3.SelectedItem.ToString() + "` ;";
                        if (i == 1)
                            sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY `" + comboBox4.SelectedItem.ToString() + "`  DESC, `" + comboBox3.SelectedItem.ToString() + "` DESC;";
                        if (i == 2)
                            sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY `" + comboBox4.SelectedItem.ToString() + "` ASC, `" + comboBox3.SelectedItem.ToString() + "` DESC;";
                        if (i == 3)
                            sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY `" + comboBox4.SelectedItem.ToString() + "`  DESC, `" + comboBox3.SelectedItem.ToString() + "` ASC;";
                    }
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
                    textBoxLog.Text += ex.Message + "\r\n";
                }

            }
            if (j == 1)
            {
                try
                {
                    if (k == 0)
                    {
                        if (i == 0)
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                 "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                 "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by `" + comboBox4.SelectedItem.ToString() + "`;"; 
                        if (i == 1)
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                 "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                 "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by `" + comboBox4.SelectedItem.ToString() + "` DESC;";
                    }
                    if (k == 1)
                    {
                        if (i == 0)
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                 "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                 "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by `" + comboBox4.SelectedItem.ToString() + "` ASC, `" + comboBox3.SelectedItem.ToString() + "` ASC;";
                        if (i == 1)
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                 "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                 "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by `" + comboBox4.SelectedItem.ToString() + "` DESC, `" + comboBox3.SelectedItem.ToString() + "` DESC;";
                        if (i == 2)
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                 "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                 "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by `" + comboBox4.SelectedItem.ToString() + "` ASC, `" + comboBox3.SelectedItem.ToString() + "` DESC;";
                        if (i == 3)
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                 "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                 "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by `" + comboBox4.SelectedItem.ToString() + "` DESC, `" + comboBox3.SelectedItem.ToString() + "` ASC;";
                    }
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
                    textBoxLog.Text += ex.Message + "\r\n";
                }
            }
            /*    if (j == 0)
                {
                    if (i == 0)
                    {
                        try
                        {
                            if (columnIndex == 0)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.idApplicants;";
                            }
                            if (columnIndex == 1)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.full_name;";
                            }
                            if (columnIndex == 2)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.Date_of_Birth;";
                            }
                            if (columnIndex == 3)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.graduation_date;";
                            }
                            if (columnIndex == 4)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.passport_id;";
                            }
                            if (columnIndex == 5)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY social_categories.name_social_categories;";
                            }
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
                            textBoxLog.Text += ex.Message + "\r\n";
                        }

                    }
                    if (i == 1)
                    {
                        try
                        {
                            if (columnIndex == 0)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.idApplicants DESC;";
                            }
                            if (columnIndex == 1)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.full_name DESC;";
                            }
                            if (columnIndex == 2)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.Date_of_Birth DESC;";
                            }
                            if (columnIndex == 3)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.graduation_date DESC;";
                            }
                            if (columnIndex == 4)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY applicants.passport_id DESC;";
                            }
                            if (columnIndex == 5)
                            {
                                sql = "SELECT idApplicants,full_name,Date_of_Birth,graduation_date,passport_id,name_social_categories FROM applicants LEFT JOIN social_categories ON applicants.Social_categories_idSocial_categories = social_categories.idSocial_categories ORDER BY social_categories.name_social_categories DESC;";
                            }
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
                            textBoxLog.Text += ex.Message + "\r\n";
                        }

                    }
                }
            if (j == 1)
            {
                if (i == 0)
                {
                    try
                    { 
                        if (columnIndex == 2)
                        {
                         sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                            "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                            "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by applicants.full_name;";
                        }
                        if (columnIndex == 3)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by passport_id;";
                        }
                        if (columnIndex == 4)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by subjects.nameSubject;";
                        }
                        if (columnIndex == 5)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by number_of_scores;";
                        }
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
                        textBoxLog.Text += ex.Message + "\r\n";
                    }

                }
                if (i == 1)
                {
                    try
                    {
                        if (columnIndex == 2)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                               "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                               "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by applicants.full_name DESC;";
                        }
                        if (columnIndex == 3)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by passport_id DESC;";
                        }
                        if (columnIndex == 4)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by subjects.nameSubject DESC;";
                        }
                        if (columnIndex == 5)
                        {
                            sql = " select scores.Applicants_idApplicants, scores.Subjects_idSubjects,applicants.full_name, applicants.passport_id,subjects.nameSubject, number_of_scores " +
                                                        "from scores join applicants on scores.Applicants_idApplicants = applicants.idApplicants " +
                                                        "join subjects on scores.Subjects_idSubjects = subjects.idSubjects order by number_of_scores DESC;";
                        }
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
                        textBoxLog.Text += ex.Message + "\r\n";
                    }

                }
            }*/
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // строка подключения к БД
                string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                // создаём объект для подключения к БД
                conn = new MySqlConnection(connStr);
                // запрос
                string sql = textBox2.Text;
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
                textBoxLog.Text += ex.Message + "\r\n";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            string sql = "select idSpecialties,name_specialties from specialties;";
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox7.DataSource = ds.Tables[0];
            comboBox7.DisplayMember = "name_specialties";
            comboBox7.ValueMember = "idSpecialties";

            string sql1 = "select idTypes_of_recruitment,name_types from types_of_recruitment;";
            MySqlDataAdapter adp1 = new MySqlDataAdapter(sql1, conn);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboBox8.DataSource = ds1.Tables[0];
            comboBox8.DisplayMember = "name_types";
            comboBox8.ValueMember = "idTypes_of_recruitment";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            i = comboBox5.SelectedIndex;
            label1.Visible = false;
            comboBox2.Visible = false;
            label5.Visible = false;
            comboBox4.Visible = false;
            label3.Visible = false;
            comboBox3.Visible = false;
            if (i == 0)
            {
                label1.Visible = true;
                comboBox2.Visible = true;
                label5.Visible = true;
                comboBox4.Visible = true;
            }
            if (i == 1)
            {
                label1.Visible = true;
                comboBox2.Visible = true;
                label5.Visible = true;
                comboBox4.Visible = true;
                label3.Visible = true;
                comboBox3.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // строка подключения к БД
                string connStr = "server=localhost;user=root;database=stud;password=vfqrfynjh71129;";
                // создаём объект для подключения к БД
                conn = new MySqlConnection(connStr);
                // запро
                string sql = "CALL r('" + comboBox6.SelectedItem.ToString() + "', '" + comboBox7.Text.ToString() + "', '" + comboBox8.Text.ToString() + "');";
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
                textBoxLog.Text += ex.Message + "\r\n";
            }
        }

        private void Fill(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }
    }
}
