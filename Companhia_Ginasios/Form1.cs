using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Companhia_Ginasios
{
    public partial class Form1 : Form
    {

        private Database db = new Database();

        public Form1()
        {
            InitializeComponent();
            DisplayGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
        }

        private void DisplayGym(string dbServer, string dbName, string userName, string userPass)
        {

            panel1.Visible = false;
            panel1.Enabled = false;

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    string morada = "";
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Ginasio; ", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        morada = reader["Morada"].ToString();
                        listBox1.Items.Add(morada);
                    }
                }
            }
            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to display data due to the following error: \r\n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

        }

        private void AddGym(string dbServer, string dbName, string userName, string userPass, Ginasio gym)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Ginasio(NIF, Telefone, Morada, Gestor) VALUES(@nif, @telefone, @morada, @gestor)";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@nif", gym.NIF);
                sqlcmd.Parameters.AddWithValue("@telefone", gym.Telefone);
                sqlcmd.Parameters.AddWithValue("@morada", gym.Morada);
                sqlcmd.Parameters.AddWithValue("@gestor", gym.Gestor);
                sqlcmd.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            
            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add gym in database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String table = db.getTableContent(db.DbServer, db.DbName, db.UserName, db.UserPass);

            if (!db.Logged)
                MessageBox.Show(db.Error, "Operation Failed");
            else
                MessageBox.Show(table);
        }

        private void AddBttn_Click(object sender, EventArgs e)
        {
            ClearFields();
            ShowAddBttns();
            HideDisplayBttns();
            listBox1.Visible = false;
            listBox1.Enabled = false;
            panel1.Enabled = true;
            panel1.Visible = true;
            
        }

        private void ListBttn_Click(object sender, EventArgs e)
        {
            RefreshListBox();
            HideAddBttns();
            ShowDisplayBttns();
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
            
        }

        private void SaveBttn_Click(object sender, EventArgs e)
        {
            Ginasio gym = new Ginasio();
            try
            {
                gym.NIF = txtNIF.Text;
                gym.Telefone = txtPhone.Text;
                gym.Morada = txtAddress.Text;
                gym.Gestor = txtManager.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            AddGym(db.DbServer, db.DbName, db.UserName, db.UserPass, gym);
            RefreshListBox();
            ShowDisplayBttns();
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Enabled = false;
            panel1.Visible = false;
            
        }

        public void ClearFields()
        {
            txtAddress.Text = "";
            txtManager.Text = "";
            txtNIF.Text = "";
            txtPhone.Text = "";
        }

        public void RefreshListBox()
        {
            listBox1.Items.Clear();
            ShowDisplayBttns();
            DisplayGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
        }

        public void ShowDisplayBttns()
        {
            textAdressdisplay.Enabled = true;
            textAdressdisplay.Visible = true;
            textPhonedisplay.Enabled = true;
            textPhonedisplay.Visible = true;
            textNIFdisplay.Enabled = true;
            textNIFdisplay.Visible = true;
            textManagerdisplay.Enabled = true;
            textManagerdisplay.Visible = true;
            label5.Enabled = true;
            label5.Visible = true;
            label6.Enabled = true;
            label6.Visible = true;
            label7.Enabled = true;
            label7.Visible = true;
            label8.Enabled = true;
            label8.Visible = true;
            panel2.Enabled = true;
            panel2.Visible = true;
        }

        public void HideDisplayBttns()
        {
            textAdressdisplay.Enabled = false;
            textAdressdisplay.Visible = false;
            textPhonedisplay.Enabled = false;
            textPhonedisplay.Visible = false;
            textNIFdisplay.Enabled = false;
            textNIFdisplay.Visible = false;
            textManagerdisplay.Enabled = false;
            textManagerdisplay.Visible = false;
            label5.Enabled = false;
            label5.Visible = false;
            label6.Enabled = false;
            label6.Visible = false;
            label7.Enabled = false;
            label7.Visible = false;
            label8.Enabled = false;
            label8.Visible = false;
            panel2.Enabled = false;
            panel2.Visible = false;
        }


        public void HideAddBttns ()
        {
            SaveBttn.Enabled = false;
            SaveBttn.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
            txtNIF.Enabled = false;
            txtNIF.Visible = false;
            label2.Enabled = false;
            label2.Visible = false;
            txtPhone.Enabled = false;
            txtPhone.Visible = false;
            label3.Enabled = false;
            label3.Visible = false;
            txtAddress.Enabled = false;
            txtAddress.Visible = false;
            label4.Enabled = false;
            label4.Visible = false;
            txtManager.Enabled = false;
            txtManager.Visible = false;
            
        }

        public void ShowAddBttns()
        {
            SaveBttn.Enabled = true;
            SaveBttn.Visible = true;
            label1.Enabled = true;
            label1.Visible = true;
            txtNIF.Enabled = true;
            txtNIF.Visible = true;
            label2.Enabled = true;
            label2.Visible = true;
            txtPhone.Enabled = true;
            txtPhone.Visible = true;
            label3.Enabled = true;
            label3.Visible = true;
            txtAddress.Enabled = true;
            txtAddress.Visible = true;
            label4.Enabled = true;
            label4.Visible = true;
            txtManager.Enabled = true;
            txtManager.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ShowGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
            }
        }

        public void ShowGym(string dbServer, string dbName, string userName, string userPass)
        {

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            String morada = listBox1.Items[listBox1.SelectedIndex].ToString();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT GymCompany.Ginasio.NIF, GymCompany.Ginasio.Telefone, GymCompany.Ginasio.Morada, GymCompany.Pessoa.Nome " +
                        "FROM GymCompany.Ginasio " +
                        "INNER JOIN GymCompany.Pessoa ON GymCompany.Ginasio.Gestor = GymCompany.Pessoa.Numero_CC " +
                        "WHERE GymCompany.Ginasio.Morada = '" + morada + "';", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ginasio gym = new Ginasio();
                        gym.NIF = reader["NIF"].ToString();
                        gym.Telefone = reader["Telefone"].ToString();
                        gym.Morada = reader["Morada"].ToString();
                        gym.Gestor = reader["Nome"].ToString();
                        textAdressdisplay.Text = gym.Morada;
                        textManagerdisplay.Text = gym.Gestor;
                        textPhonedisplay.Text = gym.Telefone;
                        textNIFdisplay.Text = gym.NIF;
                    }
                }
            }
            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to display data due to the following error: \r\n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }
    }
}
