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
    public partial class EntryFormcs : Form
    {
        public EntryFormcs()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = tbxUsername.Text;
            String password = tbxPassword.Text;
            Account account = Account.getAccount(username, password);
            if (account == null)
            {
                MessageBox.Show("invalid Username/Password");
            }
            else
            {
                if (account.Role == "Client")
                {
                    FormUser formUser = new FormUser(username, password);
                    formUser.Show();
                    this.Visible = false;
                }
                else if (account.Role == "Shop")
                {
                    FormShop form2 = new FormShop();
                    form2.username = username;
                    form2.password = password;
                    form2.Show();
                    this.Visible = false;
                }
            }
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            new UserRegister().Show();
            this.Visible = false;
        }

        private void btnRegisterShop_Click(object sender, EventArgs e)
        {
            new ShopRegister().Show();
            this.Visible = false;
        }
    }
}
