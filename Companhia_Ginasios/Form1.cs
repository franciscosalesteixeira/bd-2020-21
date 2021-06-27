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
        private string gymSelected;

        public Form1()
        {
            InitializeComponent();
            DisplayGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
            HideListBttns();
        }

        private void DisplayGym(string dbServer, string dbName, string userName, string userPass)
        {

            panel1.Visible = false;
            panel1.Enabled = false;
            HidePanelPerson();
            miscPanel.Visible = false;
            miscPanel.Enabled = false;

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
            miscPanel.Visible = false;
            miscPanel.Enabled = false;
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
            HideListBttns();
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
            ListClientsCB.Checked = false;
            ListEmpCB.Checked = false;
            ListProductsCB.Checked = false;
            ListEquipCB.Checked = false;
            ListCoursesCB.Checked = false;
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
            SLTBttn.Visible = true;
            SLTBttn.Enabled = true;
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
            SqlCommand sqlcmd2 = new SqlCommand();

            string gestor = "";

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;

                sqlcmd2.CommandText = "SELECT Numero_CC FROM GymCompany.Pessoa WHERE Nome=@gestor";
                sqlcmd2.Parameters.Clear();
                sqlcmd2.Parameters.AddWithValue("@gestor", gym.Gestor);
                sqlcmd2.Connection = CN;

                try
                {
                    SqlDataReader reader;
                    reader = sqlcmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        gestor = reader["Numero_CC"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    db.Logged = false;
                    db.Error = "Failed to get manager id in database. \n ERROR MESSAGE: \n" + ex.Message;
                    MessageBox.Show(db.Error, "An Error Occurred");
                }

                sqlcmd.CommandText = "UPDATE GymCompany.Ginasio SET Telefone=@telefone, Morada=@morada, Gestor=@gestor WHERE NIF=@nif";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@nif", gym.NIF);
                sqlcmd.Parameters.AddWithValue("@telefone", gym.Telefone);
                sqlcmd.Parameters.AddWithValue("@morada", gym.Morada);
                sqlcmd.Parameters.AddWithValue("@gestor", gestor);
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
                    MessageBox.Show("Gym Removed Successfully");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void EditBttn_Click(object sender, EventArgs e)
        {
            if (ListClientsCB.Checked)
            {

            }
            else if (ListEmpCB.Checked)
            {

            }
            else if (ListProductsCB.Checked)
            {

            }
            else if (ListEquipCB.Checked)
            {

            }
            else if (ListCoursesCB.Checked)
            {

            }
            else
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
        }

        private void OkBttn_Click(object sender, EventArgs e)
        {
            if (ListClientsCB.Checked)
            {

            }
            else if (ListEmpCB.Checked)
            {

            }
            else if (ListProductsCB.Checked)
            {

            }
            else if (ListEquipCB.Checked)
            {

            }
            else if (ListCoursesCB.Checked)
            {

            }
            else
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
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            if (ListClientsCB.Checked)
            {

            }
            else if (ListEmpCB.Checked)
            {

            }
            else if (ListProductsCB.Checked)
            {

            }
            else if (ListEquipCB.Checked)
            {

            }
            else if (ListCoursesCB.Checked)
            {

            }
            else
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
        }

        private void RemoveBttn_Click(object sender, EventArgs e)
        {
            if (ListClientsCB.Checked)
            {

            }
            else if (ListEmpCB.Checked)
            {

            }
            else if (ListProductsCB.Checked)
            {

            }
            else if (ListEquipCB.Checked)
            {

            }
            else if (ListCoursesCB.Checked)
            {

            }
            else 
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
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                HideEmployeeBttns();
                HidePersonBttns();
                AddClientBttns();

                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                HideClientBttns();
                HidePersonBttns();
                AddEmployeeBttns();

                checkBox3.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                HideClientBttns();
                HideEmployeeBttns();
                AddPersonBttns();

                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
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

        private void AddEmployeeDb(string dbServer, string dbName, string userName, string userPass, Funcionario func, Tem_Funcionarios addfuncs)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Funcionario(Numero_CC, Numero_Funcionario, Funcao, Salario) VALUES(@numero_cc, @numero_funcionario, @funcao, @salario)";
                sqlcmd2.CommandText = "INSERT INTO GymCompany.Tem_Funcionarios(NIF, Numero_Funcionario) VALUES(@nif, @numero_funcionario)";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@numero_cc", func.Numero_CC);
                sqlcmd.Parameters.AddWithValue("@numero_funcionario", func.Numero_Funcionario);
                sqlcmd.Parameters.AddWithValue("@funcao", func.Funcao);
                sqlcmd.Parameters.AddWithValue("@salario", func.Salario);
                sqlcmd2.Parameters.AddWithValue("@nif", addfuncs.NIF);
                sqlcmd2.Parameters.AddWithValue("@numero_funcionario", addfuncs.Numero_Funcionario);
                sqlcmd.Connection = CN;
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
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

        private void AddClientDb(string dbServer, string dbName, string userName, string userPass, Cliente cliente, Tem_Clientes addclient)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Cliente(Numero_CC, Numero_Cliente, Tipo_Subscricao) VALUES(@numero_cc, @numero_cliente, @tipo_subscricao)";
                sqlcmd2.CommandText = "INSERT INTO GymCompany.Tem_Clientes(NIF, Numero_Cliente) VALUES(@nif, @numero_cliente)";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@numero_cc", cliente.Numero_CC);
                sqlcmd.Parameters.AddWithValue("@numero_cliente", cliente.Numero_Cliente);
                sqlcmd.Parameters.AddWithValue("@tipo_subscricao", cliente.Tipo_Subscricao);
                sqlcmd2.Parameters.AddWithValue("@nif", addclient.NIF);
                sqlcmd2.Parameters.AddWithValue("@numero_cliente", addclient.Numero_Cliente);
                sqlcmd.Connection = CN;
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
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
            Tem_Funcionarios addfuncs = new Tem_Funcionarios();
            Cliente client = new Cliente();
            Tem_Clientes addclients = new Tem_Clientes();

            try
            {
                if (checkBox3.Checked)
                {
                    person.Numero_CC = txtPersonId.Text;
                    person.Nome = txtPersonName.Text;
                    person.Telefone = txtPersonPhone.Text;
                    person.Morada = txtPersonAdd.Text;
                    person.Email = txtPersonEmail.Text;

                    AddPersonDb(db.DbServer, db.DbName, db.UserName, db.UserPass, person);
                    ClearPersonBttns();
                    
                }

                if (checkBox1.Checked)
                {
                    func.Numero_CC = txtIdEmp.Text;
                    func.Numero_Funcionario = txtEnEmp.Text;
                    func.Funcao = txtJobEmp.Text;
                    func.Salario = txtSalEmp.Text;
                    addfuncs.NIF = txtFuncGym.Text;
                    addfuncs.Numero_Funcionario = txtEnEmp.Text;

                    AddEmployeeDb(db.DbServer, db.DbName, db.UserName, db.UserPass, func, addfuncs);
                    ClearEmployeeBttns();
                }

                if (checkBox2.Checked)
                {
                    client.Numero_CC = txtIdClt.Text;
                    client.Numero_Cliente = txtCnClt.Text;
                    client.Tipo_Subscricao = txtSubClt.Text;
                    addclients.NIF = txtClientGym.Text;
                    addclients.Numero_Cliente = txtCnClt.Text;

                    AddClientDb(db.DbServer, db.DbName, db.UserName, db.UserPass, client, addclients);
                    ClearClientBttns();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(db.Error + "\n" + ex.Message, "An Error Occurred");
            }

        }

        private void AddEquip(string dbServer, string dbName, string userName, string userPass, Equipamento equip, Possui pos)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Equipamento(Designacao, Tipo_Equipamento, Quantidade) VALUES(@designacao, @tipo_equipamento, @quantidade)";
                sqlcmd2.CommandText = "INSERT INTO GymCompany.Possui(NIF, Designacao) VALUES(@nif, @designacao)";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@designacao", equip.Designacao);
                sqlcmd.Parameters.AddWithValue("@tipo_equipamento", equip.Tipo_Equipamento);
                sqlcmd.Parameters.AddWithValue("@quantidade", equip.Quantidade);
                sqlcmd.Connection = CN;
                sqlcmd2.Parameters.AddWithValue("@nif", pos.NIF);
                sqlcmd2.Parameters.AddWithValue("@designacao", pos.Designacao);
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Equipment to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddProd(string dbServer, string dbName, string userName, string userPass, Produto prod, Vende ven)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Produto(Codigo, Nome, Preco, Stock) VALUES(@codigo, @nome, @preco, @stock)";
                sqlcmd2.CommandText = "INSERT INTO GymCompany.Vende(NIF, Codigo) VALUES(@nif, @codigo)";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@codigo", prod.Codigo);
                sqlcmd.Parameters.AddWithValue("@nome", prod.Nome);
                sqlcmd.Parameters.AddWithValue("@preco", prod.Preco);
                sqlcmd.Parameters.AddWithValue("@stock", prod.Stock);
                sqlcmd.Connection = CN;
                sqlcmd2.Parameters.AddWithValue("@nif", ven.NIF);
                sqlcmd2.Parameters.AddWithValue("@codigo", ven.Codigo);
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Product to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddClass(string dbServer, string dbName, string userName, string userPass, Aula aula, Oferece ofc)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Aula(Designacao, Tipo_Aula, Hora, Dias_Semana, Nr_Max_Alunos) VALUES(@designacao, @tipo_aula, @hora, @dias_semana, @nr_max_alunos)";
                sqlcmd2.CommandText = "INSERT INTO GymCompany.Oferece(NIF, Designacao) VALUES(@nif, @designacao)";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@designacao", aula.Designacao);
                sqlcmd.Parameters.AddWithValue("@tipo_aula", aula.Tipo_Aula);
                sqlcmd.Parameters.AddWithValue("@hora", aula.Hora);
                sqlcmd.Parameters.AddWithValue("@dias_semana", aula.Dias_Semana);
                sqlcmd.Parameters.AddWithValue("@nr_max_alunos", aula.Nr_Max_Alunos);
                sqlcmd.Connection = CN;
                sqlcmd2.Parameters.AddWithValue("@nif", ofc.NIF);
                sqlcmd2.Parameters.AddWithValue("@designacao", ofc.Designacao);
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Course to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddTeach(string dbServer, string dbName, string userName, string userPass, Professor prof, Leciona lec)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Professor(Numero_Funcionario) VALUES(@numero_funcionario)";
                sqlcmd2.CommandText = "EXEC GymCompany.NewProf @numProf, @aula";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@Numero_Funcionario", prof.Numero_Funcionario);
                sqlcmd.Connection = CN;
                sqlcmd2.Parameters.AddWithValue("@numProf", prof.Numero_Funcionario);
                sqlcmd2.Parameters.AddWithValue("@aula", lec.Designacao_Aula);
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Teacher to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddStu(string dbServer, string dbName, string userName, string userPass, Aluno stu, Inscrito insc)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();
            SqlCommand sqlcmd2 = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.Aluno(Numero_Cliente) VALUES(@numero_cliente)";
                sqlcmd2.CommandText = "EXEC GymCompany.newSub @numero_cliente, @designacao_aula";
                sqlcmd.Parameters.Clear();
                sqlcmd2.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@numero_cliente", stu.Numero_Cliente);
                sqlcmd.Connection = CN;
                sqlcmd2.Parameters.AddWithValue("@numero_cliente", stu.Numero_Cliente);
                sqlcmd2.Parameters.AddWithValue("@designacao_aula", insc.Designacao_Aula);
                sqlcmd2.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Student to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void AddCourseInst (string dbServer, string dbName, string userName, string userPass, Aula_Instancia inst)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            SqlCommand sqlcmd = new SqlCommand();

            CN.Open();
            if (CN.State == ConnectionState.Open)
            {
                db.Logged = true;
                sqlcmd.CommandText = "INSERT INTO GymCompany.AulaInstancia(Fk_Aula, Fk_Professor, Codigo) VALUES(@fk_aula, @fk_professor, @codigo)";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@fk_aula", inst.Fk_Aula);
                sqlcmd.Parameters.AddWithValue("@fk_professor", inst.Fk_Professor);
                sqlcmd.Parameters.AddWithValue("@codigo", inst.Codigo);
                sqlcmd.Connection = CN;
            }

            try
            {
                sqlcmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to add Course Instance to the database. \n ERROR MESSAGE: \n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void SaveMiscBttn_Click_1(object sender, EventArgs e)
        {

            Equipamento eq = new Equipamento();
            Produto prod = new Produto();
            Professor prof = new Professor();
            Aluno aluno = new Aluno();
            Aula aula = new Aula();
            Aula_Instancia insts = new Aula_Instancia();
            Leciona lec = new Leciona();
            Inscrito insc = new Inscrito();
            Vende ven = new Vende();
            Possui pos = new Possui();
            Oferece ofc = new Oferece();

            try
            {
                if (checkBox4.Checked)
                {
                    eq.Designacao = txtDesignation.Text;
                    eq.Tipo_Equipamento = txtEqType.Text;
                    eq.Quantidade = txtQuant.Text;
                    pos.NIF = txtGymEq.Text;
                    pos.Designacao = txtDesignation.Text;
                    
                    AddEquip(db.DbServer, db.DbName, db.UserName, db.UserPass, eq, pos);
                    ClearEquipBttns();
                }

                if (checkBox5.Checked)
                {
                    prod.Codigo = txtCode.Text;
                    prod.Nome = txtProdName.Text;
                    prod.Preco = txtPrice.Text;
                    prod.Stock = txtStock.Text;
                    ven.NIF = txtProdGym.Text;
                    ven.Codigo = txtCode.Text;


                    AddProd(db.DbServer, db.DbName, db.UserName, db.UserPass, prod, ven);
                    ClearProdBttns();
                }

                if (checkBox6.Checked)
                {
                    prof.Numero_Funcionario = txtProfId.Text;
                    lec.Designacao_Aula = txtProfGym.Text;
                    lec.Numero_Professor = txtProfId.Text;

                    AddTeach(db.DbServer, db.DbName, db.UserName, db.UserPass, prof, lec);
                    ClearProfBttns();
                }

                if (checkBox7.Checked)
                {
                    aluno.Numero_Cliente = txtStuId.Text;
                    insc.Designacao_Aula = txtStuId.Text;
                    insc.Numero_Aluno = txtStuId.Text;

                    AddStu(db.DbServer, db.DbName, db.UserName, db.UserPass, aluno, insc);
                    ClearStuBttns();
                }

                if (checkBox8.Checked)
                {
                    aula.Designacao = txtClId.Text;
                    aula.Dias_Semana = txtCldays.Text;
                    aula.Hora = txtCltime.Text;
                    aula.Nr_Max_Alunos = txtClatt.Text;
                    aula.Tipo_Aula = txtCltype.Text;
                    ofc.Designacao = txtClId.Text;
                    ofc.NIF = txtClGym.Text;

                    AddClass(db.DbServer, db.DbName, db.UserName, db.UserPass, aula, ofc);
                    ClearClassBttns();
                }

                if (checkBox9.Checked)
                {
                    insts.Codigo = txtInstCode.Text;
                    insts.Fk_Aula = txtInstCl.Text;
                    insts.Fk_Professor = txtInstProf.Text;

                    AddCourseInst(db.DbServer, db.DbName, db.UserName, db.UserPass, insts);
                    ClearInstBttns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(db.Error + "\n" + ex.Message, "An Error Occurred");
            }
        }

        public void ShowPanelPerson()
        {
            panel3.Enabled = true;
            panel3.Visible = true;
            panel1.Enabled = false;
            panel1.Visible = false;
            panel2.Enabled = false;
            panel2.Visible = false;
        }
        public void HidePanelPerson()
        {
            panel3.Enabled = false;
            panel3.Visible = false;
        }

        private void SLTBttn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                String morada = listBox1.Items[listBox1.SelectedIndex].ToString();
                gymSelected = GetGymNif(db.DbServer, db.DbName, db.UserName, db.UserPass, morada);
                ShowListBttns();
            }
            else
            {
                MessageBox.Show("Please select a gym");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0 && ListClientsCB.Checked)
            {   
                ShowClient(db.DbServer, db.DbName, db.UserName, db.UserPass);
            }
            if (listBox2.SelectedIndex >= 0 && ListEmpCB.Checked)
            {
                ShowEmp(db.DbServer, db.DbName, db.UserName, db.UserPass);
            }
            if (listBox2.SelectedIndex >= 0 && ListProductsCB.Checked)
            {
                ShowProduct(db.DbServer, db.DbName, db.UserName, db.UserPass);
            }
            if (listBox2.SelectedIndex >= 0 && ListEquipCB.Checked)
            {
                ShowEquip(db.DbServer, db.DbName, db.UserName, db.UserPass);
            }
            if (listBox2.SelectedIndex >= 0 && ListCoursesCB.Checked)
            {
                ShowCourse(db.DbServer, db.DbName, db.UserName, db.UserPass);
            }
        }

        private void ShowCourse(string dbServer, string dbName, string userName, string userPass)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            String des = listBox2.Items[listBox2.SelectedIndex].ToString();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT Designacao, Tipo_Aula, Hora, Dias_Semana, Nr_Max_Alunos " +
                        "FROM GymCompany.Aula WHERE Designacao = '" + des + "';", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Aula a = new Aula();
                        a.Designacao = reader["Designacao"].ToString();
                        a.Tipo_Aula = reader["Tipo_Aula"].ToString();
                        a.Hora = reader["Hora"].ToString();
                        a.Dias_Semana = reader["Dias_Semana"].ToString();
                        a.Nr_Max_Alunos = reader["Nr_Max_Alunos"].ToString();
                        textBox14.Text = a.Designacao;
                        textBox13.Text = a.Tipo_Aula;
                        textBox9.Text = a.Hora;
                        textBox15.Text = a.Dias_Semana;
                        textBox16.Text = a.Nr_Max_Alunos;
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

        private void ShowEquip(string dbServer, string dbName, string userName, string userPass)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            String des = listBox2.Items[listBox2.SelectedIndex].ToString();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT Designacao, Tipo_Equipamento, Quantidade " +
                        "FROM GymCompany.Equipamento WHERE Designacao = '" + des + "';", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Equipamento e = new Equipamento();
                        e.Designacao = reader["Designacao"].ToString();
                        e.Tipo_Equipamento = reader["Tipo_Equipamento"].ToString();
                        e.Quantidade = reader["Quantidade"].ToString();
                        textBox12.Text = e.Designacao;
                        textBox11.Text = e.Tipo_Equipamento;
                        textBox10.Text = e.Quantidade;
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


        private void ShowProduct(string dbServer, string dbName, string userName, string userPass)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            String cod = listBox2.Items[listBox2.SelectedIndex].ToString();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT Codigo, Nome, Preco, Stock " +
                        "FROM GymCompany.Produto WHERE Codigo = '" + cod + "';", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Produto p = new Produto();
                        p.Codigo = reader["Codigo"].ToString();
                        p.Nome = reader["Nome"].ToString();
                        p.Preco = reader["Preco"].ToString();
                        p.Stock = reader["Stock"].ToString();
                        textBox3.Text = p.Codigo;
                        textBox2.Text = p.Nome;
                        textBox1.Text = p.Preco;
                        textBox4.Text = p.Stock;
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

        private void ShowEmp(string dbServer, string dbName, string userName, string userPass)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            String num = listBox2.Items[listBox2.SelectedIndex].ToString();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT Numero_CC, Numero_Funcionario, Funcao, Salario " +
                        "FROM GymCompany.Funcionario WHERE Numero_Funcionario = " + num + ";", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Funcionario f = new Funcionario();
                        f.Numero_CC = reader["Numero_CC"].ToString();
                        f.Numero_Funcionario = reader["Numero_Funcionario"].ToString();
                        f.Funcao = reader["Funcao"].ToString();
                        f.Salario = reader["Salario"].ToString();
                        textBox8.Text = f.Numero_CC;
                        textBox7.Text = f.Numero_Funcionario;
                        textBox6.Text = f.Funcao;
                        textBox5.Text = f.Salario;
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

        private void ShowClient(string dbServer, string dbName, string userName, string userPass)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            String num = listBox2.Items[listBox2.SelectedIndex].ToString();

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT Numero_CC, Numero_Cliente, Tipo_subscricao " +
                        "FROM GymCompany.Cliente WHERE Numero_Cliente = " + num + ";", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente c = new Cliente();
                        c.Numero_CC = reader["Numero_CC"].ToString();
                        c.Numero_Cliente = reader["Numero_Cliente"].ToString();
                        c.Tipo_Subscricao = reader["Tipo_Subscricao"].ToString();
                        text_CC.Text = c.Numero_CC;
                        text_CN.Text = c.Numero_Cliente;
                        text_ST.Text = c.Tipo_Subscricao;
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

        private void ListClientsCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ListClientsCB.Checked)
            {
                HideDisplayBttns();
                ShowClientsBttns();
                panel2.Enabled = true;
                panel2.Visible = true;
                listBox2.Enabled = true;
                listBox2.Visible = true;
                listBox2.Items.Clear();

                DisplayClients(db.DbServer, db.DbName, db.UserName, db.UserPass);

                ListEmpCB.Checked = false;
                ListProductsCB.Checked = false;
                ListEquipCB.Checked = false;
                ListCoursesCB.Checked = false;
            }
        }

        private void ListEmpCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ListEmpCB.Checked)
            {
                HideDisplayBttns();
                ShowEmpsBttns();
                panel2.Enabled = true;
                panel2.Visible = true;
                listBox2.Enabled = true;
                listBox2.Visible = true;
                listBox2.Items.Clear();

                DisplayEmps(db.DbServer, db.DbName, db.UserName, db.UserPass);

                ListClientsCB.Checked = false;
                ListProductsCB.Checked = false;
                ListEquipCB.Checked = false;
                ListCoursesCB.Checked = false;
            }
        }

        private void ListProductsCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ListProductsCB.Checked)
            {
                HideDisplayBttns();
                ShowProductsBttns();
                panel2.Enabled = true;
                panel2.Visible = true;
                listBox2.Enabled = true;
                listBox2.Visible = true;
                listBox2.Items.Clear();

                DisplayProducts(db.DbServer, db.DbName, db.UserName, db.UserPass);

                ListEmpCB.Checked = false;
                ListClientsCB.Checked = false;
                ListEquipCB.Checked = false;
                ListCoursesCB.Checked = false;
            }
        }

        private void ListEquipCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ListEquipCB.Checked)
            {
                HideDisplayBttns();
                ShowEquipsBttns();
                panel2.Enabled = true;
                panel2.Visible = true;
                listBox2.Enabled = true;
                listBox2.Visible = true;
                listBox2.Items.Clear();

                DisplayEquips(db.DbServer, db.DbName, db.UserName, db.UserPass);

                ListEmpCB.Checked = false;
                ListProductsCB.Checked = false;
                ListClientsCB.Checked = false;
                ListCoursesCB.Checked = false;
            }
        }

        private void ListCoursesCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ListCoursesCB.Checked)
            {
                HideDisplayBttns();
                ShowCoursesBttns();
                panel2.Enabled = true;
                panel2.Visible = true;
                listBox2.Enabled = true;
                listBox2.Visible = true;
                listBox2.Items.Clear();

                DisplayCourses(db.DbServer, db.DbName, db.UserName, db.UserPass);

                ListEmpCB.Checked = false;
                ListProductsCB.Checked = false;
                ListEquipCB.Checked = false;
                ListClientsCB.Checked = false;
            }
        }

        private void DisplayClients(string dbServer, string dbName, string userName, string userPass)
        {
            HidePanelPerson();
            miscPanel.Visible = false;
            miscPanel.Enabled = false;

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Tem_Clientes WHERE NIF=@nif;");
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@nif", gymSelected);
                    sqlcmd.Connection = CN;

                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string client = reader["Numero_Cliente"].ToString();
                        listBox2.Items.Add(client);
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

        private void DisplayEmps(string dbServer, string dbName, string userName, string userPass)
        {
            HidePanelPerson();
            miscPanel.Visible = false;
            miscPanel.Enabled = false;

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Tem_Funcionarios WHERE NIF=@nif;");
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@nif", gymSelected);
                    sqlcmd.Connection = CN;

                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string emp = reader["Numero_Funcionario"].ToString();
                        listBox2.Items.Add(emp);
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

        private void DisplayProducts(string dbServer, string dbName, string userName, string userPass)
        {
            HidePanelPerson();
            miscPanel.Visible = false;
            miscPanel.Enabled = false;

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Vende WHERE NIF=@nif;");
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@nif", gymSelected);
                    sqlcmd.Connection = CN;

                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string product = reader["Codigo"].ToString();
                        listBox2.Items.Add(product);
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

        private void DisplayEquips(string dbServer, string dbName, string userName, string userPass)
        {
            HidePanelPerson();
            miscPanel.Visible = false;
            miscPanel.Enabled = false;

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Possui WHERE NIF=@nif;");
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@nif", gymSelected);
                    sqlcmd.Connection = CN;

                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string equip = reader["Designacao"].ToString();
                        listBox2.Items.Add(equip);
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

        private void DisplayCourses(string dbServer, string dbName, string userName, string userPass)
        {
            HidePanelPerson();
            miscPanel.Visible = false;
            miscPanel.Enabled = false;

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Oferece WHERE NIF=@nif;");
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@nif", gymSelected);
                    sqlcmd.Connection = CN;

                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string course = reader["Designacao"].ToString();
                        listBox2.Items.Add(course);
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

        private string GetGymNif (string dbServer, string dbName, string userName, string userPass, string morada)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            string nif = "";

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT GymCompany.Ginasio.NIF FROM GymCompany.Ginasio " +
                        "WHERE GymCompany.Ginasio.Morada = '" + morada + "';", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        nif = reader["NIF"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to get nif due to the following error: \r\n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return nif;
        }

        private void ShowClientsBttns()
        {
            HideEmpsBttns();
            HideProductsBttns();
            HideEquipsBttns();
            HideCoursesBttns();
            Clients_panel.Visible = true;
            Clients_panel.Enabled = true;
            Clients_panel.BringToFront();
        }

        private void HideClientsBttns()
        {
            Clients_panel.Visible = false;
            Clients_panel.Enabled = false;
        }

        private void ShowEmpsBttns()
        {
            HideClientsBttns();
            HideProductsBttns();
            HideEquipsBttns();
            HideCoursesBttns();
            Emps_panel.Visible = true;
            Emps_panel.Enabled = true;
            Emps_panel.BringToFront();
        }

        private void HideEmpsBttns()
        {
            Emps_panel.Visible = false;
            Emps_panel.Enabled = false;
        }

        private void ShowProductsBttns()
        {
            HideClientsBttns();
            HideEmpsBttns();
            HideEquipsBttns();
            HideCoursesBttns();
            Products_panel.Visible = true;
            Products_panel.Enabled = true;
            Products_panel.BringToFront();
        }

        private void HideProductsBttns()
        {
            Products_panel.Visible = false;
            Products_panel.Enabled = false;
        }

        private void ShowEquipsBttns()
        {
            HideClientsBttns();
            HideEmpsBttns();
            HideProductsBttns();
            HideCoursesBttns();
            Equips_panel.Visible = true;
            Equips_panel.Enabled = true;
            Equips_panel.BringToFront();
        }

        private void HideEquipsBttns()
        {
            Equips_panel.Visible = false;
            Equips_panel.Enabled = false;
        }

        private void ShowCoursesBttns()
        {
            HideClientsBttns();
            HideEmpsBttns();
            HideProductsBttns();
            HideEquipsBttns();
            Courses_panel.Visible = true;
            Courses_panel.Enabled = true;
            Courses_panel.BringToFront();
        }

        private void HideCoursesBttns()
        {
            Courses_panel.Visible = false;
            Courses_panel.Enabled = false;
        }

        private void ShowListBttns()
        {
            listBox2.Enabled = true;
            listBox2.Visible = true;
            ListClientsCB.Visible = true;
            ListClientsCB.Enabled = true;
            ListEmpCB.Visible = true;
            ListEmpCB.Enabled = true;
            ListProductsCB.Enabled = true;
            ListProductsCB.Visible = true;
            ListEquipCB.Visible = true;
            ListEquipCB.Enabled = true;
            ListCoursesCB.Enabled = true;
            ListCoursesCB.Visible = true;
        }

        private void HideListBttns()
        {
            listBox2.Enabled = false;
            listBox2.Visible = false;
            ListClientsCB.Visible = false;
            ListClientsCB.Enabled = false;
            ListEmpCB.Visible = false;
            ListEmpCB.Enabled = false;
            ListProductsCB.Enabled = false;
            ListProductsCB.Visible = false;
            ListEquipCB.Visible = false;
            ListEquipCB.Enabled = false;
            ListCoursesCB.Enabled = false;
            ListCoursesCB.Visible = false;
            HideClientsBttns();
            HideEmpsBttns();
            HideProductsBttns();
            HideEquipsBttns();
            HideCoursesBttns();
        }

        private void AddPerson_Click_1(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            ClearFields();
            HideDisplayBttns();
            HideAddBttns();
            listBox1.Visible = false;
            listBox1.Enabled = false;
            miscPanel.Visible = false;
            miscPanel.Enabled = false;
            HideClientBttns();
            HideEmployeeBttns();
            panel1.Visible = false;
            panel1.Enabled = false;
            panel3.Visible = true;
            panel3.Enabled = true;
            ShowPanelPerson();
            AddPersonBttns();
        }


        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked)
            {
                HideProdBttns();
                HideProfBttns();
                HideStuBttns();
                HideClassBttns();
                HideInstBttns();
                AddEquipBttns();

                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }
        private void checkBox5_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                HideEquipBttns();
                HideProfBttns();
                HideStuBttns();
                HideClassBttns();
                HideInstBttns();
                AddProdBttns();

                checkBox4.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }
        private void checkBox6_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox6.Checked)
            {
                HideProdBttns();
                HideEquipBttns();
                HideStuBttns();
                HideClassBttns();
                HideInstBttns();
                AddProfBttns();

                checkBox5.Checked = false;
                checkBox4.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }
        private void checkBox7_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                HideProdBttns();
                HideProfBttns();
                HideEquipBttns();
                HideClassBttns();
                HideInstBttns();
                AddStuBttns();

                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }
        private void checkBox8_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                HideProdBttns();
                HideProfBttns();
                HideStuBttns();
                HideEquipBttns();
                HideInstBttns();
                AddClassBttns();

                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox4.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox9_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                HideProdBttns();
                HideProfBttns();
                HideStuBttns();
                HideClassBttns();
                HideEquipBttns();
                AddInstBttns();

                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox4.Checked = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HideDisplayBttns();
            listBox1.Enabled = false;
            listBox1.Visible = false;
            panel1.Enabled = false;
            panel1.Visible = false;
            panel2.Enabled = false;
            panel2.Visible = false;
            panel3.Enabled = false;
            panel3.Visible = false;
            miscPanel.Visible = true;
            miscPanel.Enabled = true;
            checkBox4.Enabled = true;
            checkBox4.Visible = true;
            checkBox4.Checked = true;
        }

        private void AddMiscBttn_Click_1(object sender, EventArgs e)
        {
            
            HideEditBttns();
            HidePersonBttns();
            HideDisplayBttns();
            panel1.Visible = false;
            panel2.Visible = false;
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            listBox1.Visible = false;
            listBox1.Enabled = false;
            miscPanel.Visible = true;
            miscPanel.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = true;
            checkBox6.Enabled = true;
            checkBox7.Enabled = true;
            checkBox5.Visible = true;
            checkBox6.Visible = true;
            checkBox7.Visible = true;
            checkBox4.Visible = true;
            checkBox4.Checked = true;
            
        }

        public void HideEquipBttns()
        {
            labelDesignation.Visible = false;
            labelDesignation.Enabled = false;
            labelEqtype.Visible = false;
            labelEqtype.Enabled = false;
            labelQuant.Visible = false;
            labelQuant.Enabled = false;
            labelGymEq.Visible = false;
            labelGymEq.Enabled = false;
            txtDesignation.Visible = false;
            txtDesignation.Enabled = false;
            txtEqType.Visible = false;
            txtEqType.Enabled = false;
            txtQuant.Visible = false;
            txtQuant.Enabled = false;
            txtGymEq.Visible = false;
            txtGymEq.Enabled = false;

        }

        public void AddEquipBttns()
        {
            labelDesignation.Visible = true;
            labelDesignation.Enabled = true;
            labelEqtype.Visible = true;
            labelEqtype.Enabled = true;
            labelQuant.Visible = true;
            labelQuant.Enabled = true;
            labelGymEq.Visible = true;
            labelGymEq.Enabled = true;
            txtDesignation.Visible = true;
            txtDesignation.Enabled = true;
            txtEqType.Visible = true;
            txtEqType.Enabled = true;
            txtQuant.Visible = true;
            txtQuant.Enabled = true;
            txtGymEq.Visible = true;
            txtGymEq.Enabled = true;
        }

        public void ClearEquipBttns()
        {

            txtDesignation.Text = "";
            txtEqType.Text = "";
            txtQuant.Text = "";
            txtGymEq.Text = "";

        }

        public void HideProdBttns()
        {
            labelCode.Visible = false;
            labelCode.Enabled = false;
            labelProdName.Visible = false;
            labelProdName.Enabled = false;
            labelProdGym.Visible = false;
            labelProdGym.Enabled = false;
            labelPrice.Visible = false;
            labelPrice.Enabled = false;
            labelStock.Visible = false;
            labelStock.Enabled = false;
            txtCode.Visible = false;
            txtCode.Enabled = false;
            txtProdName.Visible = false;
            txtProdName.Enabled = false;
            txtProdGym.Visible = false;
            txtProdGym.Enabled = false;
            txtPrice.Visible = false;
            txtPrice.Enabled = false;
            txtStock.Visible = false;
            txtStock.Enabled = false;

        }

        public void AddProdBttns()
        {
            labelCode.Visible = true;
            labelCode.Enabled = true;
            labelProdName.Visible = true;
            labelProdName.Enabled = true;
            labelProdGym.Visible = true;
            labelProdGym.Enabled = true;
            labelPrice.Visible = true;
            labelPrice.Enabled = true;
            labelStock.Visible = true;
            labelStock.Enabled = true;
            txtCode.Visible = true;
            txtCode.Enabled = true;
            txtProdName.Visible = true;
            txtProdName.Enabled = true;
            txtProdGym.Visible = true;
            txtProdGym.Enabled = true;
            txtPrice.Visible = true;
            txtPrice.Enabled = true;
            txtStock.Visible = true;
            txtStock.Enabled = true;
        }

        public void ClearProdBttns()
        {

            txtCode.Text = "";
            txtProdName.Text = "";
            txtProdGym.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";

        }

        public void HideProfBttns()
        {
            labelProfId.Visible = false;
            labelProfId.Enabled = false;
            labelProfGym.Visible = false;
            labelProfGym.Enabled = false;
            txtProfId.Visible = false;
            txtProfId.Enabled = false;
            txtProfGym.Visible = false;
            txtProfGym.Enabled = false;

        }

        public void AddProfBttns()
        {
            labelProfId.Visible = true;
            labelProfId.Enabled = true;
            labelProfGym.Visible = true;
            labelProfGym.Enabled = true;
            txtProfId.Visible = true;
            txtProfId.Enabled = true;
            txtProfGym.Visible = true;
            txtProfGym.Enabled = true;

        }

        public void ClearProfBttns()
        {

            txtProfId.Text = "";
            txtProfGym.Text = "";

        }

        public void HideStuBttns()
        {
            labelStuId.Visible = false;
            labelStuId.Enabled = false;
            labelStuGym.Visible = false;
            labelStuGym.Enabled = false;
            txtStuId.Visible = false;
            txtStuId.Enabled = false;
            txtStuGym.Visible = false;
            txtStuGym.Enabled = false;

        }

        public void AddStuBttns()
        {
            labelStuId.Visible = true;
            labelStuId.Enabled = true;
            labelStuGym.Visible = true;
            labelStuGym.Enabled = true;
            txtStuId.Visible = true;
            txtStuId.Enabled = true;
            txtStuGym.Visible = true;
            txtStuGym.Enabled = true;

        }

        public void ClearStuBttns()
        {

            txtStuId.Text = "";
            txtStuGym.Text = "";

        }

        public void HideClassBttns()
        {
            labelClId.Visible = false;
            labelClId.Enabled = false;
            labelCltype.Visible = false;
            labelCltype.Enabled = false;
            labelCltime.Visible = false;
            labelCltime.Enabled = false;
            labelCldays.Visible = false;
            labelCldays.Enabled = false;
            labelClatt.Visible = false;
            labelClatt.Enabled = false;
            labelClGym.Visible = false;
            labelClGym.Enabled = false;
            txtClId.Visible = false;
            txtClId.Enabled = false;
            txtCltype.Visible = false;
            txtCltype.Enabled = false;
            txtCltime.Visible = false;
            txtCltime.Enabled = false;
            txtCldays.Visible = false;
            txtCldays.Enabled = false;
            txtClatt.Visible = false;
            txtClatt.Enabled = false;
            txtClGym.Visible = false;
            txtClGym.Enabled = false;

        }

        public void AddClassBttns()
        {
            labelClId.Visible = true;
            labelClId.Enabled = true;
            labelCltype.Visible = true;
            labelCltype.Enabled = true;
            labelCltime.Visible = true;
            labelCltime.Enabled = true;
            labelCldays.Visible = true;
            labelCldays.Enabled = true;
            labelClatt.Visible = true;
            labelClatt.Enabled = true;
            labelClGym.Visible = true;
            labelClGym.Enabled = true;
            txtClId.Visible = true;
            txtClId.Enabled = true;
            txtCltype.Visible = true;
            txtCltype.Enabled = true;
            txtCltime.Visible = true;
            txtCltime.Enabled = true;
            txtCldays.Visible = true;
            txtCldays.Enabled = true;
            txtClatt.Visible = true;
            txtClatt.Enabled = true;
            txtClGym.Visible = true;
            txtClGym.Enabled = true;
        }

        public void ClearClassBttns()
        {

            txtClId.Text = "";
            txtCltype.Text = "";
            txtCltime.Text = "";
            txtCldays.Text = "";
            txtClatt.Text = "";
            txtClGym.Text = "";

        }

        public void HideInstBttns()
        {
            labelInstCl.Visible = false;
            labelInstCl.Enabled = false;
            labelInstProf.Visible = false;
            labelInstProf.Enabled = false;
            labelInstCode.Visible = false;
            labelInstCode.Enabled = false;
            labelInstGym.Visible = false;
            labelInstGym.Enabled = false;
            txtInstCl.Visible = false;
            txtInstCl.Enabled = false;
            txtInstProf.Visible = false;
            txtInstProf.Enabled = false;
            txtInstCode.Visible = false;
            txtInstCode.Enabled = false;
            txtInstGym.Visible = false;
            txtInstGym.Enabled = false;

        }

        public void AddInstBttns()
        {
            labelInstCl.Visible = true;
            labelInstCl.Enabled = true;
            labelInstProf.Visible = true;
            labelInstProf.Enabled = true;
            labelInstCode.Visible = true;
            labelInstCode.Enabled = true;
            labelInstGym.Visible = false;
            labelInstGym.Enabled = false;
            txtInstCl.Visible = true;
            txtInstCl.Enabled = true;
            txtInstProf.Visible = true;
            txtInstProf.Enabled = true;
            txtInstCode.Visible = true;
            txtInstCode.Enabled = true;
            txtInstGym.Visible = false;
            txtInstGym.Enabled = false;

        }

        public void ClearInstBttns()
        {

            txtInstCl.Text = "";
            txtInstProf.Text = "";
            txtInstCode.Text = "";
            txtInstGym.Text = "";

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
            panel1.Enabled = false;
            panel1.Visible = false;
            SLTBttn.Enabled = false;
            SLTBttn.Visible = false;
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
            panel1.Enabled = false;
            panel1.Visible = false;
            panel2.Enabled = false;
            panel2.Visible = false;
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
            labelFuncGym.Enabled = false;
            labelFuncGym.Visible = false;
            txtIdEmp.Visible = false;
            txtEnEmp.Enabled = false;
            txtEnEmp.Visible = false;
            txtJobEmp.Enabled = false;
            txtJobEmp.Visible = false;
            txtSalEmp.Enabled = false;
            txtSalEmp.Visible = false;
            txtFuncGym.Enabled = false;
            txtFuncGym.Visible = false;

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
            labelFuncGym.Enabled = true;
            labelFuncGym.Visible = true;
            txtIdEmp.Visible = true;
            txtEnEmp.Enabled = true;
            txtEnEmp.Visible = true;
            txtJobEmp.Enabled = true;
            txtJobEmp.Visible = true;
            txtSalEmp.Enabled = true;
            txtSalEmp.Visible = true;
            txtFuncGym.Enabled = true;
            txtFuncGym.Visible = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;

        }

        public void HideClientBttns()
        {
            labelIdClt.Enabled = false;
            labelIdClt.Visible = false;
            labelCnClt.Enabled = false;
            labelCnClt.Visible = false;
            labelSubClt.Enabled = false;
            labelSubClt.Visible = false;
            labelClientGym.Enabled = false;
            labelClientGym.Visible = false;
            txtIdClt.Visible = false;
            txtIdClt.Enabled = false;
            txtCnClt.Visible = false;
            txtSubClt.Enabled = false;
            txtSubClt.Visible = false;
            txtSubClt.Enabled = false;
            txtSubClt.Visible = false;
            txtClientGym.Enabled = false;
            txtClientGym.Visible = false;

        }

        public void AddClientBttns()
        {
            labelIdClt.Enabled = true;
            labelIdClt.Visible = true;
            labelCnClt.Enabled = true;
            labelCnClt.Visible = true;
            labelSubClt.Enabled = true;
            labelSubClt.Visible = true;
            labelClientGym.Enabled = true;
            labelClientGym.Visible = true;
            txtIdClt.Visible = true;
            txtIdClt.Enabled = true;
            txtCnClt.Visible = true;
            txtSubClt.Enabled = true;
            txtSubClt.Visible = true;
            txtClientGym.Enabled = true;
            txtClientGym.Visible = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;

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
            labelNamePerson.Visible = false;
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
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;

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
            labelNamePerson.Visible = true;
            txtPersonId.Visible = true;
            txtPersonId.Enabled = true;
            txtPersonPhone.Enabled = true;
            txtPersonPhone.Visible = true;
            txtPersonAdd.Enabled = true;
            txtPersonAdd.Visible = true;
            txtPersonEmail.Enabled = true;
            txtPersonEmail.Visible = true;
            txtPersonName.Enabled = true;
            txtPersonName.Visible = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
        }

        public void ClearPersonBttns()
        {

            txtPersonId.Text = "";
            txtPersonPhone.Text = "";
            txtPersonAdd.Text = "";
            txtPersonEmail.Text = "";
            txtPersonName.Text = "";

        }

        public void ClearClientBttns()
        {

            txtIdClt.Text = "";
            txtCnClt.Text = "";
            txtSubClt.Text = "";
            txtClientGym.Text = "";

        }

        public void ClearEmployeeBttns()
        {

            txtIdEmp.Text = "";
            txtEnEmp.Text = "";
            txtJobEmp.Text = "";
            txtSalEmp.Text = "";
            txtFuncGym.Text = "";

        }
    }
}
