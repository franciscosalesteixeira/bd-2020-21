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
            HidePanelPerson();

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
                db.Error = "Failed to add gym to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        public void AddBttn_Click(object sender, EventArgs e)
        {
            ClearFields();
            ShowAddBttns();
            HideDisplayBttns();
            listBox1.Visible = false;
            listBox1.Enabled = false;
            panel1.Enabled = true;
            panel1.Visible = true;

        }

        public void ListBttn_Click(object sender, EventArgs e)
        {
            RefreshListBox();
            HideAddBttns();
            HidePanelPerson();
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
            textAdressdisplay.Text = "";
            textManagerdisplay.Text = "";
            textNIFdisplay.Text = "";
            textPhonedisplay.Text = "";
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

        public void ShowPanelPerson()
        {
            panel1.Enabled = false;
            panel1.Visible = false;
            panel3.Enabled = true;
            panel3.Visible = true;
        }
        public void HidePanelPerson()
        {
            panel3.Enabled = false;
            panel3.Visible = false;
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


        public void HideAddBttns()
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

        private void ShowGym(string dbServer, string dbName, string userName, string userPass)
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

        private void EditGym(string dbServer, string dbName, string userName, string userPass, Ginasio gym)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "UPDATE GymCompany.Ginasio SET Telefone=@telefone, Morada=@morada, Gestor=@gestor WHERE NIF=@nif";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@nif", gym.NIF);
                sqlcmd.Parameters.AddWithValue("@telefone", gym.Telefone);
                sqlcmd.Parameters.AddWithValue("@morada", gym.Morada);
                sqlcmd.Parameters.AddWithValue("@gestor", gym.Gestor);
                sqlcmd.Connection = CN;
            }

            int rows = 0;

            try
            {
                rows = sqlcmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to edit gym in database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }
            finally
            {
                if (rows == 1)
                    MessageBox.Show("Info edited");
                else
                    MessageBox.Show("Info NOT edited");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void RemoveGym(string dbServer, string dbName, string userName, string userPass, Ginasio gym)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "EXEC GymCompany.RemoveGym @nif";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@nif", gym.NIF);
                sqlcmd.Connection = CN;
            }

            int rows = 0;

            try
            {
                rows = sqlcmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to remove gym in database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }
            finally
            {
                if (rows == 1)
                    MessageBox.Show("Gym Removed Successfully");
                else
                    MessageBox.Show("Remove Gym Failed");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void EditBttn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a contact to edit");
                return;
            }
            textNIFdisplay.ReadOnly = false;
            textPhonedisplay.ReadOnly = false;
            textManagerdisplay.ReadOnly = false;
            textAdressdisplay.ReadOnly = false;
            ShowEditBttns();
            listBox1.Enabled = false;
        }

        public void ShowEditBttns()
        {
            OkBttn.Enabled = true;
            OkBttn.Visible = true;
            CancelBttn.Enabled = true;
            CancelBttn.Visible = true;
            EditBttn.Enabled = false;
            EditBttn.Visible = false;
            RemoveBttn.Enabled = false;
            RemoveBttn.Visible = false;
        }

        public void HideEditBttns()
        {
            OkBttn.Enabled = false;
            OkBttn.Visible = false;
            CancelBttn.Enabled = false;
            CancelBttn.Visible = false;
            EditBttn.Enabled = true;
            EditBttn.Visible = true;
            RemoveBttn.Enabled = true;
            RemoveBttn.Visible = true;
        }

        public void HideEmployeeBttns()
        {
            labelIdEmp.Enabled = false;
            labelIdEmp.Visible = false;
            labelEnEmp.Enabled = false;
            labelEnEmp.Visible = false;
            labelJobEmp.Enabled = false;
            labelJobEmp.Visible = false;
            labelSalEmp.Enabled = false;
            labelSalEmp.Visible = false;
            labelIdEmp.Enabled = false;
            txtIdEmp.Visible = false;
            txtEnEmp.Enabled = false;
            txtEnEmp.Visible = false;
            txtJobEmp.Enabled = false;
            txtJobEmp.Visible = false;
            txtSalEmp.Enabled = false;
            txtSalEmp.Visible = false;

        }

        public void AddEmployeeBttns()
        {
            labelIdEmp.Enabled = true;
            labelIdEmp.Visible = true;
            labelEnEmp.Enabled = true;
            labelEnEmp.Visible = true;
            labelJobEmp.Enabled = true;
            labelJobEmp.Visible = true;
            labelSalEmp.Enabled = true;
            labelSalEmp.Visible = true;
            labelIdEmp.Enabled = true;
            txtIdEmp.Visible = true;
            txtEnEmp.Enabled = true;
            txtEnEmp.Visible = true;
            txtJobEmp.Enabled = true;
            txtJobEmp.Visible = true;
            txtSalEmp.Enabled = true;
            txtSalEmp.Visible = true;

        }

        public void HideClientBttns()
        {
            labelIdClt.Enabled = false;
            labelIdClt.Visible = false;
            labelCnClt.Enabled = false;
            labelCnClt.Visible = false;
            labelSubClt.Enabled = false;
            labelSubClt.Visible = false;
            txtIdClt.Visible = false;
            txtIdClt.Enabled = false;
            txtCnClt.Visible = false;
            txtSubClt.Enabled = false;
            txtSubClt.Visible = false;

        }

        public void AddClientBttns()
        {
            labelIdClt.Enabled = true;
            labelIdClt.Visible = true;
            labelCnClt.Enabled = true;
            labelCnClt.Visible = true;
            labelSubClt.Enabled = true;
            labelSubClt.Visible = true;
            txtIdClt.Visible = true;
            txtIdClt.Enabled = true;
            txtCnClt.Visible = true;
            txtSubClt.Enabled = true;
            txtSubClt.Visible = true;

        }

        public void HidePersonBttns()
        {
            labelPhonePerson.Visible = false;
            labelPhonePerson.Enabled = false;
            labelEmailPerson.Visible = false;
            labelEmailPerson.Enabled = false;
            labelAddPerson.Visible = false;
            labelAddPerson.Enabled = false;
            labelIdPerson.Enabled = false;
            labelIdPerson.Visible = false;
            labelNamePerson.Enabled = false;
            labelNamePerson.Enabled = false;
            txtPersonId.Visible = false;
            txtPersonId.Enabled = false;
            txtPersonPhone.Enabled = false;
            txtPersonPhone.Visible = false;
            txtPersonAdd.Enabled = false;
            txtPersonAdd.Visible = false;
            txtPersonEmail.Enabled = false;
            txtPersonEmail.Visible = false;
            txtPersonName.Enabled = false;
            txtPersonName.Visible = false;

        }

        public void AddPersonBttns()
        {
            labelPhonePerson.Visible = true;
            labelPhonePerson.Enabled = true;
            labelEmailPerson.Visible = true;
            labelEmailPerson.Enabled = true;
            labelAddPerson.Visible = true;
            labelAddPerson.Enabled = true;
            labelIdPerson.Enabled = true;
            labelIdPerson.Visible = true;
            labelNamePerson.Enabled = true;
            labelNamePerson.Enabled = true;
            txtPersonId.Visible = true;
            txtPersonId.Enabled = true;
            txtPersonPhone.Enabled = true;
            txtPersonPhone.Visible = true;
            txtPersonAdd.Enabled = true;
            txtPersonAdd.Visible = true;
            txtPersonEmail.Enabled = true;
            txtPersonEmail.Visible = true;
        }

        private void OkBttn_Click(object sender, EventArgs e)
        {
            HideEditBttns();

            Ginasio gym = new Ginasio();
            try
            {
                gym.NIF = textNIFdisplay.Text;
                gym.Telefone = textPhonedisplay.Text;
                gym.Morada = textAdressdisplay.Text;
                gym.Gestor = textManagerdisplay.Text;

                EditGym(db.DbServer, db.DbName, db.UserName, db.UserPass, gym);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textNIFdisplay.ReadOnly = true;
            textPhonedisplay.ReadOnly = true;
            textManagerdisplay.ReadOnly = true;
            textAdressdisplay.ReadOnly = true;
            listBox1.Enabled = true;
            RefreshListBox();
            ShowDisplayBttns();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            HideEditBttns();
            textNIFdisplay.ReadOnly = true;
            textPhonedisplay.ReadOnly = true;
            textManagerdisplay.ReadOnly = true;
            textAdressdisplay.ReadOnly = true;
            listBox1.Enabled = true;
            RefreshListBox();
            ShowDisplayBttns();
        }

        private void RemoveBttn_Click(object sender, EventArgs e)
        {
            Ginasio gym = new Ginasio();

            if (listBox1.SelectedIndex > -1)
            {
                try
                {
                    gym.NIF = textNIFdisplay.Text;
                    RemoveGym(db.DbServer, db.DbName, db.UserName, db.UserPass, gym);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                if (listBox1.Items.Count == -1)
                {
                    ClearFields();
                    MessageBox.Show("There are no more gyms");
                }
                else
                {
                    RefreshListBox();
                    ShowDisplayBttns();
                }
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            HideEmployeeBttns();
            HidePersonBttns();
            AddClientBttns();

            checkBox1.Checked = false;
            checkBox3.Checked = false;

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            HideClientBttns();
            HidePersonBttns();
            AddEmployeeBttns();

            checkBox3.Checked = false;
            checkBox2.Checked = false;

        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            HideClientBttns();
            HideEmployeeBttns();
            AddPersonBttns();
            checkBox1.Checked = false;
            checkBox2.Checked = false;

        }

        private void AddPersonDb(string dbServer, string dbName, string userName, string userPass, Pessoa person)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Pessoa(Numero_CC, Nome, Telefone, Morada, Email) VALUES(@numero_cc, @nome, @telefone, @morada, @email)";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@numero_cc", person.Numero_CC);
                sqlcmd.Parameters.AddWithValue("@nome", person.Nome);
                sqlcmd.Parameters.AddWithValue("@telefone", person.Telefone);
                sqlcmd.Parameters.AddWithValue("@morada", person.Morada);
                sqlcmd.Parameters.AddWithValue("@email", person.Email);
                sqlcmd.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Person to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddEmployeeDb(string dbServer, string dbName, string userName, string userPass, Funcionario func)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Funcionario(Numero_CC, Numero_Funcionario, Funcao, Salario) VALUES(@numero_cc, @numero_funcionario, @funcao, @salario)";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@numero_cc", func.Numero_CC);
                sqlcmd.Parameters.AddWithValue("@numero_funcionario", func.Numero_Funcionario);
                sqlcmd.Parameters.AddWithValue("@funcao", func.Funcao);
                sqlcmd.Parameters.AddWithValue("@salario", func.Salario);
                sqlcmd.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Employee to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddClientDb(string dbServer, string dbName, string userName, string userPass, Cliente cliente)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Cliente(Numero_CC, Numero_Cliente, Tipo_Subscricao) VALUES(@numero_cc, @numero_cliente, @tipo_subscricao)";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@numero_cc", cliente.Numero_CC);
                sqlcmd.Parameters.AddWithValue("@numero_cliente", cliente.Numero_Cliente);
                sqlcmd.Parameters.AddWithValue("@tipo_subscricao", cliente.Tipo_Subscricao);
                sqlcmd.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Client to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void SavePerson_Click(object sender, EventArgs e)
        {

            Pessoa person = new Pessoa();
            Funcionario func = new Funcionario();
            Cliente client = new Cliente();

            try
            {
                if (checkBox3.Checked)
                {
                    person.Numero_CC = txtPersonId.Text;
                    person.Nome = txtPersonName.Text;
                    person.Telefone = txtPersonPhone.Text;
                    person.Morada = txtPersonAdd.Text;
                    person.Email = txtPersonEmail.Text;
                    MessageBox.Show("Operation Successful");

                    AddPersonDb(db.DbServer, db.DbName, db.UserName, db.UserPass, person);
                }

                if (checkBox1.Checked)
                {
                    func.Numero_CC = txtIdEmp.Text;
                    func.Numero_Funcionario = txtEnEmp.Text;
                    func.Funcao = txtJobEmp.Text;
                    func.Salario = txtSalEmp.Text;

                    AddEmployeeDb(db.DbServer, db.DbName, db.UserName, db.UserPass, func);
                    MessageBox.Show("Operation Successful");
                }

                if (checkBox2.Checked)
                {
                    client.Numero_CC = txtIdClt.Text;
                    client.Numero_Cliente = txtCnClt.Text;
                    client.Tipo_Subscricao = txtSubClt.Text;

                    AddClientDb(db.DbServer, db.DbName, db.UserName, db.UserPass, client);
                    MessageBox.Show("Operation Successful");
                }

            }
            catch (Exception ex)
            {
                if (func.Numero_CC != person.Numero_CC)
                    db.Error = "ID Numbers must be equal";
                MessageBox.Show(db.Error + "\n" + ex.Message, "An Error Occurred");
            }

        }

        private void AddPerson_Click_1(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            ClearFields();
            HideDisplayBttns();
            listBox1.Visible = false;
            listBox1.Enabled = false;
            ShowPanelPerson();
            HideClientBttns();
            HideEmployeeBttns();
        }
    }
}
