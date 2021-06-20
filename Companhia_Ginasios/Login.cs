using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Companhia_Ginasios
{
    public partial class Login : Form
    {

        private Database db = new Database();

        public Login()
        {
            InitializeComponent();
        }

        public void getAuth(string dbServer, string dbName, string userName, string userPass)
        {

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {

                    
                    SqlDataAdapter sqlcmd = new SqlDataAdapter("SELECT COUNT(*) FROM GymCompany.Login WHERE Username = '"+ textBox1.Text +
                        "' AND Pass = '"+ textBox2.Text +"'", CN);
                    DataTable login = new DataTable();
                    sqlcmd.Fill(login);
                    
                    if(login.Rows[0][0].ToString() == "1")
                    {
                        db.Logged = true;

                    }
                    
                    else
                    {
                        db.Logged = false;
                        db.Error = "Failed to login due to the following error: \r\n" + "Invalid username or password";
                    }
                }
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = ex.Message;
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAuth(db.DbServer, db.DbName, db.UserName, db.UserPass);
            if (db.Logged)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }

            else
                MessageBox.Show(db.Error, "Login Failed");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
