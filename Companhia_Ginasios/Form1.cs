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

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT GymCompany.Ginasio.NIF, GymCompany.Ginasio.Telefone, " +
                        "GymCompany.Ginasio.Morada, GymCompany.Pessoa.Nome " +
                        "FROM GymCompany.Ginasio " +
                        "INNER JOIN GymCompany.Pessoa ON GymCompany.Ginasio.Gestor = GymCompany.Pessoa.Numero_CC; ", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ginasio gym = new Ginasio();
                        gym.NIF = reader["NIF"].ToString();
                        gym.Telefone = reader["Telefone"].ToString();
                        gym.Morada = reader["Morada"].ToString();
                        gym.Gestor = reader["Nome"].ToString();
                        listBox1.Items.Add("NIF: " + gym.NIF + " Phone number: " + gym.Telefone 
                          + " Address: " + gym.Morada + " Manager: " + gym.Gestor);
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
            listBox1.Visible = false;
            listBox1.Enabled = false;
            panel1.Enabled = true;
            panel1.Visible = true;
            button1.Visible = false;
            button1.Enabled = false;
        }

        private void ListBttn_Click(object sender, EventArgs e)
        {
            RefreshListBox();
            HideAddBttns();
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
            button1.Visible = true;
            button1.Enabled = true;
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
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Enabled = false;
            panel1.Visible = false;
            button1.Visible = true;
            button1.Enabled = true;
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
            DisplayGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
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
    }
}
