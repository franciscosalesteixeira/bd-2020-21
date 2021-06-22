
using System.Windows.Forms;

namespace Companhia_Ginasios
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ListBttn = new System.Windows.Forms.Button();
            this.AddBttn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveBttn = new System.Windows.Forms.Button();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RemoveBttn = new System.Windows.Forms.Button();
            this.EditBttn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textNIFdisplay = new System.Windows.Forms.TextBox();
            this.textAdressdisplay = new System.Windows.Forms.TextBox();
            this.textPhonedisplay = new System.Windows.Forms.TextBox();
            this.textManagerdisplay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CancelBttn = new System.Windows.Forms.Button();
            this.OkBttn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.labelNamePerson = new System.Windows.Forms.Label();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.labelSubClt = new System.Windows.Forms.Label();
            this.txtSubClt = new System.Windows.Forms.TextBox();
            this.labelCnClt = new System.Windows.Forms.Label();
            this.txtCnClt = new System.Windows.Forms.TextBox();
            this.labelIdClt = new System.Windows.Forms.Label();
            this.txtIdClt = new System.Windows.Forms.TextBox();
            this.labelSalEmp = new System.Windows.Forms.Label();
            this.txtSalEmp = new System.Windows.Forms.TextBox();
            this.labelJobEmp = new System.Windows.Forms.Label();
            this.txtJobEmp = new System.Windows.Forms.TextBox();
            this.labelEnEmp = new System.Windows.Forms.Label();
            this.txtEnEmp = new System.Windows.Forms.TextBox();
            this.labelIdEmp = new System.Windows.Forms.Label();
            this.txtIdEmp = new System.Windows.Forms.TextBox();
            this.labelEmailPerson = new System.Windows.Forms.Label();
            this.txtPersonEmail = new System.Windows.Forms.TextBox();
            this.labelAddPerson = new System.Windows.Forms.Label();
            this.txtPersonAdd = new System.Windows.Forms.TextBox();
            this.labelPhonePerson = new System.Windows.Forms.Label();
            this.txtPersonPhone = new System.Windows.Forms.TextBox();
            this.SavePersonBttn = new System.Windows.Forms.Button();
            this.labelIdPerson = new System.Windows.Forms.Label();
            this.txtPersonId = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.AddPerson = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(319, 364);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ListBttn
            // 
            this.ListBttn.Location = new System.Drawing.Point(21, 9);
            this.ListBttn.Name = "ListBttn";
            this.ListBttn.Size = new System.Drawing.Size(75, 23);
            this.ListBttn.TabIndex = 2;
            this.ListBttn.Text = "Gym List";
            this.ListBttn.UseVisualStyleBackColor = true;
            this.ListBttn.Click += new System.EventHandler(this.ListBttn_Click);
            // 
            // AddBttn
            // 
            this.AddBttn.Location = new System.Drawing.Point(111, 9);
            this.AddBttn.Name = "AddBttn";
            this.AddBttn.Size = new System.Drawing.Size(75, 23);
            this.AddBttn.TabIndex = 3;
            this.AddBttn.Text = "Add Gym";
            this.AddBttn.UseVisualStyleBackColor = true;
            this.AddBttn.Click += new System.EventHandler(this.AddBttn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveBttn);
            this.panel1.Controls.Add(this.txtManager);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNIF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 400);
            this.panel1.TabIndex = 4;
            // 
            // SaveBttn
            // 
            this.SaveBttn.Location = new System.Drawing.Point(43, 314);
            this.SaveBttn.Name = "SaveBttn";
            this.SaveBttn.Size = new System.Drawing.Size(100, 23);
            this.SaveBttn.TabIndex = 8;
            this.SaveBttn.Text = "Save";
            this.SaveBttn.UseVisualStyleBackColor = true;
            this.SaveBttn.Click += new System.EventHandler(this.SaveBttn_Click);
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(43, 253);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(421, 23);
            this.txtManager.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Manager";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(43, 183);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(421, 23);
            this.txtAddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(43, 117);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(421, 23);
            this.txtPhone.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone Number";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(43, 48);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(421, 23);
            this.txtNIF.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "NIF";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.RemoveBttn);
            this.panel2.Controls.Add(this.EditBttn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textNIFdisplay);
            this.panel2.Controls.Add(this.textAdressdisplay);
            this.panel2.Controls.Add(this.textPhonedisplay);
            this.panel2.Controls.Add(this.textManagerdisplay);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.CancelBttn);
            this.panel2.Controls.Add(this.OkBttn);
            this.panel2.Location = new System.Drawing.Point(21, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 385);
            this.panel2.TabIndex = 9;
            // 
            // RemoveBttn
            // 
            this.RemoveBttn.Location = new System.Drawing.Point(649, 328);
            this.RemoveBttn.Name = "RemoveBttn";
            this.RemoveBttn.Size = new System.Drawing.Size(117, 47);
            this.RemoveBttn.TabIndex = 26;
            this.RemoveBttn.Text = "Remove";
            this.RemoveBttn.UseVisualStyleBackColor = true;
            this.RemoveBttn.Click += new System.EventHandler(this.RemoveBttn_Click);
            // 
            // EditBttn
            // 
            this.EditBttn.Location = new System.Drawing.Point(413, 328);
            this.EditBttn.Name = "EditBttn";
            this.EditBttn.Size = new System.Drawing.Size(113, 47);
            this.EditBttn.TabIndex = 25;
            this.EditBttn.Text = "Edit";
            this.EditBttn.UseVisualStyleBackColor = true;
            this.EditBttn.Click += new System.EventHandler(this.EditBttn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "NIF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Address";
            // 
            // textNIFdisplay
            // 
            this.textNIFdisplay.Location = new System.Drawing.Point(413, 32);
            this.textNIFdisplay.Name = "textNIFdisplay";
            this.textNIFdisplay.ReadOnly = true;
            this.textNIFdisplay.Size = new System.Drawing.Size(353, 23);
            this.textNIFdisplay.TabIndex = 17;
            // 
            // textAdressdisplay
            // 
            this.textAdressdisplay.Location = new System.Drawing.Point(413, 167);
            this.textAdressdisplay.Name = "textAdressdisplay";
            this.textAdressdisplay.ReadOnly = true;
            this.textAdressdisplay.Size = new System.Drawing.Size(353, 23);
            this.textAdressdisplay.TabIndex = 18;
            // 
            // textPhonedisplay
            // 
            this.textPhonedisplay.Location = new System.Drawing.Point(413, 99);
            this.textPhonedisplay.Name = "textPhonedisplay";
            this.textPhonedisplay.ReadOnly = true;
            this.textPhonedisplay.Size = new System.Drawing.Size(353, 23);
            this.textPhonedisplay.TabIndex = 19;
            // 
            // textManagerdisplay
            // 
            this.textManagerdisplay.Location = new System.Drawing.Point(413, 234);
            this.textManagerdisplay.Name = "textManagerdisplay";
            this.textManagerdisplay.ReadOnly = true;
            this.textManagerdisplay.Size = new System.Drawing.Size(353, 23);
            this.textManagerdisplay.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Manager";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Phone Number";
            // 
            // CancelBttn
            // 
            this.CancelBttn.Location = new System.Drawing.Point(413, 328);
            this.CancelBttn.Name = "CancelBttn";
            this.CancelBttn.Size = new System.Drawing.Size(111, 47);
            this.CancelBttn.TabIndex = 28;
            this.CancelBttn.Text = "Cancel";
            this.CancelBttn.UseVisualStyleBackColor = true;
            this.CancelBttn.Click += new System.EventHandler(this.CancelBttn_Click);
            // 
            // OkBttn
            // 
            this.OkBttn.Location = new System.Drawing.Point(649, 328);
            this.OkBttn.Name = "OkBttn";
            this.OkBttn.Size = new System.Drawing.Size(117, 47);
            this.OkBttn.TabIndex = 27;
            this.OkBttn.Text = "OK";
            this.OkBttn.UseVisualStyleBackColor = true;
            this.OkBttn.Click += new System.EventHandler(this.OkBttn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox3);
            this.panel3.Controls.Add(this.labelNamePerson);
            this.panel3.Controls.Add(this.txtPersonName);
            this.panel3.Controls.Add(this.labelSubClt);
            this.panel3.Controls.Add(this.txtSubClt);
            this.panel3.Controls.Add(this.labelCnClt);
            this.panel3.Controls.Add(this.txtCnClt);
            this.panel3.Controls.Add(this.labelIdClt);
            this.panel3.Controls.Add(this.txtIdClt);
            this.panel3.Controls.Add(this.labelSalEmp);
            this.panel3.Controls.Add(this.txtSalEmp);
            this.panel3.Controls.Add(this.labelJobEmp);
            this.panel3.Controls.Add(this.txtJobEmp);
            this.panel3.Controls.Add(this.labelEnEmp);
            this.panel3.Controls.Add(this.txtEnEmp);
            this.panel3.Controls.Add(this.labelIdEmp);
            this.panel3.Controls.Add(this.txtIdEmp);
            this.panel3.Controls.Add(this.labelEmailPerson);
            this.panel3.Controls.Add(this.txtPersonEmail);
            this.panel3.Controls.Add(this.labelAddPerson);
            this.panel3.Controls.Add(this.txtPersonAdd);
            this.panel3.Controls.Add(this.labelPhonePerson);
            this.panel3.Controls.Add(this.txtPersonPhone);
            this.panel3.Controls.Add(this.SavePersonBttn);
            this.panel3.Controls.Add(this.labelIdPerson);
            this.panel3.Controls.Add(this.txtPersonId);
            this.panel3.Controls.Add(this.checkBox2);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Location = new System.Drawing.Point(21, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 394);
            this.panel3.TabIndex = 10;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(43, 24);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(62, 19);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "Person";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckStateChanged += new System.EventHandler(this.checkBox3_CheckStateChanged);
            // 
            // labelNamePerson
            // 
            this.labelNamePerson.AutoSize = true;
            this.labelNamePerson.Location = new System.Drawing.Point(43, 126);
            this.labelNamePerson.Name = "labelNamePerson";
            this.labelNamePerson.Size = new System.Drawing.Size(39, 15);
            this.labelNamePerson.TabIndex = 26;
            this.labelNamePerson.Text = "Name";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(43, 144);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(297, 23);
            this.txtPersonName.TabIndex = 25;
            // 
            // labelSubClt
            // 
            this.labelSubClt.AutoSize = true;
            this.labelSubClt.Location = new System.Drawing.Point(43, 180);
            this.labelSubClt.Name = "labelSubClt";
            this.labelSubClt.Size = new System.Drawing.Size(100, 15);
            this.labelSubClt.TabIndex = 24;
            this.labelSubClt.Text = "Subscription Type";
            // 
            // txtSubClt
            // 
            this.txtSubClt.Location = new System.Drawing.Point(43, 201);
            this.txtSubClt.Name = "txtSubClt";
            this.txtSubClt.Size = new System.Drawing.Size(297, 23);
            this.txtSubClt.TabIndex = 23;
            // 
            // labelCnClt
            // 
            this.labelCnClt.AutoSize = true;
            this.labelCnClt.Location = new System.Drawing.Point(43, 126);
            this.labelCnClt.Name = "labelCnClt";
            this.labelCnClt.Size = new System.Drawing.Size(85, 15);
            this.labelCnClt.TabIndex = 22;
            this.labelCnClt.Text = "Client Number";
            // 
            // txtCnClt
            // 
            this.txtCnClt.Location = new System.Drawing.Point(43, 144);
            this.txtCnClt.Name = "txtCnClt";
            this.txtCnClt.Size = new System.Drawing.Size(297, 23);
            this.txtCnClt.TabIndex = 21;
            // 
            // labelIdClt
            // 
            this.labelIdClt.AutoSize = true;
            this.labelIdClt.Location = new System.Drawing.Point(43, 68);
            this.labelIdClt.Name = "labelIdClt";
            this.labelIdClt.Size = new System.Drawing.Size(65, 15);
            this.labelIdClt.TabIndex = 20;
            this.labelIdClt.Text = "ID Number";
            // 
            // txtIdClt
            // 
            this.txtIdClt.Location = new System.Drawing.Point(43, 89);
            this.txtIdClt.Name = "txtIdClt";
            this.txtIdClt.Size = new System.Drawing.Size(297, 23);
            this.txtIdClt.TabIndex = 19;
            // 
            // labelSalEmp
            // 
            this.labelSalEmp.AutoSize = true;
            this.labelSalEmp.Location = new System.Drawing.Point(43, 238);
            this.labelSalEmp.Name = "labelSalEmp";
            this.labelSalEmp.Size = new System.Drawing.Size(38, 15);
            this.labelSalEmp.TabIndex = 18;
            this.labelSalEmp.Text = "Salary";
            // 
            // txtSalEmp
            // 
            this.txtSalEmp.Location = new System.Drawing.Point(43, 259);
            this.txtSalEmp.Name = "txtSalEmp";
            this.txtSalEmp.Size = new System.Drawing.Size(297, 23);
            this.txtSalEmp.TabIndex = 17;
            // 
            // labelJobEmp
            // 
            this.labelJobEmp.AutoSize = true;
            this.labelJobEmp.Location = new System.Drawing.Point(43, 180);
            this.labelJobEmp.Name = "labelJobEmp";
            this.labelJobEmp.Size = new System.Drawing.Size(25, 15);
            this.labelJobEmp.TabIndex = 16;
            this.labelJobEmp.Text = "Job";
            // 
            // txtJobEmp
            // 
            this.txtJobEmp.Location = new System.Drawing.Point(43, 201);
            this.txtJobEmp.Name = "txtJobEmp";
            this.txtJobEmp.Size = new System.Drawing.Size(297, 23);
            this.txtJobEmp.TabIndex = 15;
            // 
            // labelEnEmp
            // 
            this.labelEnEmp.AutoSize = true;
            this.labelEnEmp.Location = new System.Drawing.Point(43, 126);
            this.labelEnEmp.Name = "labelEnEmp";
            this.labelEnEmp.Size = new System.Drawing.Size(106, 15);
            this.labelEnEmp.TabIndex = 14;
            this.labelEnEmp.Text = "Employee Number";
            // 
            // txtEnEmp
            // 
            this.txtEnEmp.Location = new System.Drawing.Point(43, 144);
            this.txtEnEmp.Name = "txtEnEmp";
            this.txtEnEmp.Size = new System.Drawing.Size(297, 23);
            this.txtEnEmp.TabIndex = 13;
            // 
            // labelIdEmp
            // 
            this.labelIdEmp.AutoSize = true;
            this.labelIdEmp.Location = new System.Drawing.Point(43, 68);
            this.labelIdEmp.Name = "labelIdEmp";
            this.labelIdEmp.Size = new System.Drawing.Size(65, 15);
            this.labelIdEmp.TabIndex = 12;
            this.labelIdEmp.Text = "ID Number";
            // 
            // txtIdEmp
            // 
            this.txtIdEmp.Location = new System.Drawing.Point(43, 89);
            this.txtIdEmp.Name = "txtIdEmp";
            this.txtIdEmp.Size = new System.Drawing.Size(297, 23);
            this.txtIdEmp.TabIndex = 11;
            // 
            // labelEmailPerson
            // 
            this.labelEmailPerson.AutoSize = true;
            this.labelEmailPerson.Location = new System.Drawing.Point(43, 297);
            this.labelEmailPerson.Name = "labelEmailPerson";
            this.labelEmailPerson.Size = new System.Drawing.Size(36, 15);
            this.labelEmailPerson.TabIndex = 10;
            this.labelEmailPerson.Text = "Email";
            // 
            // txtPersonEmail
            // 
            this.txtPersonEmail.Location = new System.Drawing.Point(43, 315);
            this.txtPersonEmail.Name = "txtPersonEmail";
            this.txtPersonEmail.Size = new System.Drawing.Size(297, 23);
            this.txtPersonEmail.TabIndex = 9;
            // 
            // labelAddPerson
            // 
            this.labelAddPerson.AutoSize = true;
            this.labelAddPerson.Location = new System.Drawing.Point(43, 241);
            this.labelAddPerson.Name = "labelAddPerson";
            this.labelAddPerson.Size = new System.Drawing.Size(49, 15);
            this.labelAddPerson.TabIndex = 8;
            this.labelAddPerson.Text = "Address";
            // 
            // txtPersonAdd
            // 
            this.txtPersonAdd.Location = new System.Drawing.Point(43, 259);
            this.txtPersonAdd.Name = "txtPersonAdd";
            this.txtPersonAdd.Size = new System.Drawing.Size(297, 23);
            this.txtPersonAdd.TabIndex = 7;
            // 
            // labelPhonePerson
            // 
            this.labelPhonePerson.AutoSize = true;
            this.labelPhonePerson.Location = new System.Drawing.Point(43, 180);
            this.labelPhonePerson.Name = "labelPhonePerson";
            this.labelPhonePerson.Size = new System.Drawing.Size(88, 15);
            this.labelPhonePerson.TabIndex = 6;
            this.labelPhonePerson.Text = "Phone Number";
            // 
            // txtPersonPhone
            // 
            this.txtPersonPhone.Location = new System.Drawing.Point(43, 201);
            this.txtPersonPhone.Name = "txtPersonPhone";
            this.txtPersonPhone.Size = new System.Drawing.Size(297, 23);
            this.txtPersonPhone.TabIndex = 5;
            // 
            // SavePersonBttn
            // 
            this.SavePersonBttn.Location = new System.Drawing.Point(43, 362);
            this.SavePersonBttn.Name = "SavePersonBttn";
            this.SavePersonBttn.Size = new System.Drawing.Size(100, 32);
            this.SavePersonBttn.TabIndex = 4;
            this.SavePersonBttn.Text = "Save";
            this.SavePersonBttn.UseVisualStyleBackColor = true;
            this.SavePersonBttn.Click += new System.EventHandler(this.SavePerson_Click);
            // 
            // labelIdPerson
            // 
            this.labelIdPerson.AutoSize = true;
            this.labelIdPerson.Location = new System.Drawing.Point(43, 68);
            this.labelIdPerson.Name = "labelIdPerson";
            this.labelIdPerson.Size = new System.Drawing.Size(65, 15);
            this.labelIdPerson.TabIndex = 3;
            this.labelIdPerson.Text = "ID Number";
            // 
            // txtPersonId
            // 
            this.txtPersonId.Location = new System.Drawing.Point(43, 89);
            this.txtPersonId.Name = "txtPersonId";
            this.txtPersonId.Size = new System.Drawing.Size(297, 23);
            this.txtPersonId.TabIndex = 2;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(195, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(57, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Client";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckStateChanged += new System.EventHandler(this.checkBox2_CheckStateChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(111, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Employee";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // AddPerson
            // 
            this.AddPerson.Location = new System.Drawing.Point(203, 9);
            this.AddPerson.Name = "AddPerson";
            this.AddPerson.Size = new System.Drawing.Size(86, 23);
            this.AddPerson.TabIndex = 11;
            this.AddPerson.Text = "Add Person";
            this.AddPerson.UseVisualStyleBackColor = true;
            this.AddPerson.Click += new System.EventHandler(this.AddPerson_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.AddPerson);
            this.Controls.Add(this.AddBttn);
            this.Controls.Add(this.ListBttn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "Add Person";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ListBttn;
        private System.Windows.Forms.Button AddBttn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNIF;
        private Button SaveBttn;
        private Panel panel2;
        private Label label5;
        private Label label6;
        private TextBox textNIFdisplay;
        private TextBox textAdressdisplay;
        private TextBox textPhonedisplay;
        private TextBox textManagerdisplay;
        private Label label8;
        private Label label7;
        private Button EditBttn;
        private Button RemoveBttn;
        private Button CancelBttn;
        private Button OkBttn;
        private Panel panel3;
        private Label labelSalEmp;
        private TextBox txtSalEmp;
        private Label labelJobEmp;
        private TextBox txtJobEmp;
        private Label labelEnEmp;
        private TextBox txtEnEmp;
        private Label labelIdEmp;
        private TextBox txtIdEmp;
        private Label labelEmailPerson;
        private TextBox txtPersonEmail;
        private Label labelAddPerson;
        private TextBox txtPersonAdd;
        private Label labelPhonePerson;
        private TextBox txtPersonPhone;
        private Button SavePersonBttn;
        private Label labelIdPerson;
        private TextBox txtPersonId;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label labelSubClt;
        private TextBox txtSubClt;
        private Label labelCnClt;
        private TextBox txtCnClt;
        private Label labelIdClt;
        private TextBox txtIdClt;
        private Label labelNamePerson;
        private TextBox txtPersonName;
        private Button AddPerson;
        private CheckBox checkBox3;
    }
}