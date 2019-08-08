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
    public partial class ShopRegister : Form
    {
        public ShopRegister()
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
                if (tbxAddress.Text == "" || tbxContact.Text == "" || tbxEmail.Text == "" ||
                    tbxTitle.Text == "" || tbxPassword.Text == "" || tbxUsername.Text == "" ||
                    tbxDescription.Text == "" || tbxImage.Text == "")
                {
                    MessageBox.Show("Please fill all the fields before submit");
                }
                else
                {
                    
                        DataAccess.addShop(tbxUsername.Text.ToUpper(), tbxUsername.Text, tbxPassword.Text, tbxTitle.Text, tbxAddress.Text,
                        tbxEmail.Text, tbxContact.Text, tbxDescription.Text, tbxImage.Text);
                        FormShop form2 = new FormShop();
                        form2.username = tbxUsername.Text;
                        form2.password = tbxPassword.Text;
                        form2.Show();
                        this.Visible = false;
                    
                    
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
