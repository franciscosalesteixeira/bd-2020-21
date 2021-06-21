
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textNIFdisplay = new System.Windows.Forms.TextBox();
            this.textAdressdisplay = new System.Windows.Forms.TextBox();
            this.textPhonedisplay = new System.Windows.Forms.TextBox();
            this.textManagerdisplay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(21, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(289, 394);
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
            this.panel1.Location = new System.Drawing.Point(21, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 400);
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
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textNIFdisplay);
            this.panel2.Controls.Add(this.textAdressdisplay);
            this.panel2.Controls.Add(this.textPhonedisplay);
            this.panel2.Controls.Add(this.textManagerdisplay);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(336, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 394);
            this.panel2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "NIF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Address";
            // 
            // textNIFdisplay
            // 
            this.textNIFdisplay.Location = new System.Drawing.Point(106, 163);
            this.textNIFdisplay.Name = "textNIFdisplay";
            this.textNIFdisplay.ReadOnly = true;
            this.textNIFdisplay.Size = new System.Drawing.Size(100, 23);
            this.textNIFdisplay.TabIndex = 17;
            // 
            // textAdressdisplay
            // 
            this.textAdressdisplay.Location = new System.Drawing.Point(254, 163);
            this.textAdressdisplay.Name = "textAdressdisplay";
            this.textAdressdisplay.ReadOnly = true;
            this.textAdressdisplay.Size = new System.Drawing.Size(100, 23);
            this.textAdressdisplay.TabIndex = 18;
            // 
            // textPhonedisplay
            // 
            this.textPhonedisplay.Location = new System.Drawing.Point(106, 230);
            this.textPhonedisplay.Name = "textPhonedisplay";
            this.textPhonedisplay.ReadOnly = true;
            this.textPhonedisplay.Size = new System.Drawing.Size(100, 23);
            this.textPhonedisplay.TabIndex = 19;
            // 
            // textManagerdisplay
            // 
            this.textManagerdisplay.Location = new System.Drawing.Point(254, 230);
            this.textManagerdisplay.Name = "textManagerdisplay";
            this.textManagerdisplay.ReadOnly = true;
            this.textManagerdisplay.Size = new System.Drawing.Size(100, 23);
            this.textManagerdisplay.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Manager";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Phone Number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.AddBttn);
            this.Controls.Add(this.ListBttn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Gym Company";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}