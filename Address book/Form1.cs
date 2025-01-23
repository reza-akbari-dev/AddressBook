using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Address_book
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void load_click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                lblPath.Text= file.FileName;
                string contact = File.ReadAllText(lblPath.Text);
                lblContact.Text = contact;
            }

            MessageBox.Show("The contacts list was successfully loaded.");
        }
        private void add_click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please fill out all boxes!!");
            }
            string newContact = txtName.Text + "-" + txtPhone.Text + "-" + txtEmail.Text;

            if (File.Exists(lblPath.Text) && new FileInfo(lblPath.Text).Length > 0)
            {
                newContact = Environment.NewLine + newContact; 
            }
            if (!string.IsNullOrEmpty(lblPath.Text))
            {
                File.AppendAllText(lblPath.Text, newContact);

                lblContact.Text = File.ReadAllText(lblPath.Text);
            }

            MessageBox.Show("Add new contact succefully");

            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }
    }
}
