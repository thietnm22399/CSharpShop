using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRN292_Project
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Account account = Account.getAccountByUsername(tbxUsername.Text);
            if (account != null)
            {
                MessageBox.Show("This username has been used");
            }
            else
            {
                if(dateTimePicker1.Value > DateTime.Now || dateTimePicker1.Value == null)
                {
                    MessageBox.Show("Invalid date");
                }
                else if (tbxAddress.Text == "" || tbxContact.Text == "" || tbxEmail.Text == "" ||
                    tbxFullname.Text == "" || tbxPassword.Text == "" || tbxUsername.Text == "")
                {
                    MessageBox.Show("Please fill all the fields before submit");
                }
                else
                {
                    try
                    {
                        DataAccess.addUser(tbxUsername.Text, tbxPassword.Text, tbxFullname.Text,
                        tbxAddress.Text, tbxEmail.Text, tbxContact.Text, dateTimePicker1.Value);
                        FormUser formUser = new FormUser(tbxUsername.Text, tbxPassword.Text);
                        //formUser.username = tbxUsername.Text;
                        //formUser.password = tbxPassword.Text;
                        formUser.Show();
                        this.Visible = false;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error input!");
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EntryFormcs entryForm = new EntryFormcs();
            entryForm.Show();
            Close();
        }
    }
}
