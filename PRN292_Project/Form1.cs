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
    public partial class FormUser : Form
    {

        public  String username;
        public  String password;
        private Account acc;
        private int pageId = 1;
        private int pageIdShop = 1;
        private int totalPageSize = 3;
        private Product product1, product2, product3, product4;
        private Shop shop1, shop2, shop3, shop4;
        private void setProducts(int pageId, string keyword)
        {
            List<Product> productList = Product.searchProduct(keyword, pageId, 4);
            panelProduct1.Visible = false;
            panelProduct2.Visible = false;
            panelProduct3.Visible = false;
            panelProduct4.Visible = false;
            if (productList.Count >= 1)
            {
                product1 = productList[0];
                titleProduct1.Text = product1.Title;
                PriceProduct1.Text = product1.Price.ToString();
                ptbProduct1.ImageLocation = (Application.StartupPath + "\\Images\\" + product1.Image);
                panelProduct1.Visible = true;
                if (product1.Amount == 0) buttonDetail1.Enabled = false;
                if (productList.Count >= 2)
                {
                    product2 = productList[1];
                    titleProduct2.Text = product2.Title;
                    PriceProduct2.Text = product2.Price.ToString();
                    ptbProduct2.ImageLocation = (Application.StartupPath + "\\Images\\" + product2.Image);
                    panelProduct2.Visible = true;
                    if (product2.Amount == 0) buttonDetail2.Enabled = false;
                    if (productList.Count >= 3)
                    {
                        product3 = productList[2];
                        titleProduct3.Text = product3.Title;
                        PriceProduct3.Text = product3.Price.ToString();
                        ptbProduct3.ImageLocation = (Application.StartupPath + "\\Images\\" + product3.Image);
                        panelProduct3.Visible = true;
                        if (product3.Amount == 0) buttonDetail3.Enabled = false;
                        if (productList.Count >= 4)
                        {
                            product4 = productList[3];
                            titleProduct4.Text = product4.Title;
                            PriceProduct4.Text = product4.Price.ToString();
                            ptbProduct4.ImageLocation = (Application.StartupPath + "\\Images\\" + product4.Image);
                            panelProduct4.Visible = true;
                            if (product4.Amount == 0) buttonDetail4.Enabled = false;
                        }
                    }
                }
            }
        }

        private void setShops(int pageId, string keyword)
        {
            List<Shop> listShop = Shop.searchShop(keyword, pageId, 4);
            panelShop1.Visible = false;
            panelShop2.Visible = false;
            panelShop3.Visible = false;
            panelShop4.Visible = false;
            if(listShop.Count >= 1)
            {
                shop1 = listShop[0];
                TitleShop1.Text = shop1.Title;
                addressShop1.Text = shop1.Address;
                ptbShop1.ImageLocation = (Application.StartupPath + "\\Images\\" + shop1.Image);
                panelShop1.Visible = true;
                if (listShop.Count >= 2)
                {
                    shop2 = listShop[1];
                    TitleShop2.Text = shop2.Title;
                    addressShop2.Text = shop2.Address;
                    ptbShop2.ImageLocation = (Application.StartupPath + "\\Images\\" + shop2.Image);
                    panelShop2.Visible = true;
                    if (listShop.Count >= 3)
                    {
                        shop3 = listShop[2];
                        TitleShop3.Text = shop3.Title;
                        addressShop3.Text = shop3.Address;
                        ptbShop3.ImageLocation = (Application.StartupPath + "\\Images\\" + shop3.Image);
                        panelShop3.Visible = true;
                        if (listShop.Count >= 4)
                        {
                            shop4 = listShop[3];
                            TitleShop4.Text = shop4.Title;
                            addressShop4.Text = shop4.Address;
                            ptbShop4.ImageLocation = (Application.StartupPath + "\\Images\\" + shop4.Image);
                            panelShop4.Visible = true;
                        }
                    }
                }
            }
        }

        public FormUser(string username, string password)
        {
            this.username = username;
            this.password = password;
            InitializeComponent();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            setProducts(1, "");
            setShops(1, "");
            Account acc = Account.getAccount(username, password);
            int userID = DataAccess.GetUserID(acc.AccountID);
            List<Cart> carts = Cart.getAllCarts(userID);
            Console.WriteLine(userID);
            GridViewCart.DataSource = carts;
            addCol();

        }

        public void addCol()
        {
            DataGridViewButtonColumn delcol = new DataGridViewButtonColumn();
            delcol.Name = "delcol";
            delcol.Text = "Delete";
            delcol.UseColumnTextForButtonValue = true;
            GridViewCart.Columns.Add(delcol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntryFormcs entryForm = new EntryFormcs();
            entryForm.Show();
            Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tabControl1.TabPages[e.Index];

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;  //optional

            // This is the rectangle to draw "over" the tabpage title
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);

            // This is the default colour to use for the non-selected tabs
            SolidBrush sb = new SolidBrush(Color.Yellow);

            // This changes the colour if we're trying to draw the selected tabpage
            if (tabControl1.SelectedIndex == e.Index)
                sb.Color = Color.Orange;

            // Colour the header of the current tabpage based on what we did above
            g.FillRectangle(sb, e.Bounds);

            //Remember to redraw the text - I'm always using black for title text
            g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.Black), headerRect, sf);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDetail1_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show(product1.ToString() + Environment.NewLine + "Do you want to buy this product", "confirm",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                acc = Account.getAccount(username, password);
                int userID = DataAccess.GetUserID(acc.AccountID);
                Double price = Convert.ToDouble(product1.Price);
                if (Cart.getCartByProductID(product1.ProductID) == null)
                {
                    DataAccess.addToCart(product1.ProductID, userID, 1, price);
                }
                else
                {
                    Cart c = Cart.getCartByProductID(product1.ProductID);
                    Console.WriteLine("id is"+c.ProductID);
                    c.Quantity += 1;
                    DataAccess.updateCart(userID, c.ProductID, c.Quantity, Convert.ToDecimal(c.TotalPrice) + product1.Price);
                }

            }
        }

        private void buttonDetail2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(product2.ToString() + Environment.NewLine + "Do you want to buy this product", "confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                acc = Account.getAccount(username, password);
                int userID = DataAccess.GetUserID(acc.AccountID);
                Double price = Convert.ToDouble(product2.Price);
                if (Cart.getCartByProductID(product2.ProductID) == null)
                {
                    DataAccess.addToCart(product2.ProductID, userID, 1, price);
                }
                else
                {
                    Cart c = Cart.getCartByProductID(product2.ProductID);
                    DataAccess.updateCart(userID, c.ProductID, c.Quantity + 1, Convert.ToDecimal(c.TotalPrice) + product2.Price);
                }

            }
        }

        private void btnSearchShop_Click(object sender, EventArgs e)
        {
            pageIdShop = 1;
            setShops(pageId, tbxSearchShop.Text);
        }

        private void btnShopPrevius_Click(object sender, EventArgs e)
        {
            if (pageIdShop > 1)
            {
                pageIdShop -= 1;
                setShops(pageIdShop, tbxSearchShop.Text);
            }
        }

        private void btnShopNext_Click(object sender, EventArgs e)
        {
            if (pageIdShop < totalPageSize)
            {
                pageIdShop += 1;
                setShops(pageIdShop, tbxSearchShop.Text);
            }
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            acc = Account.getAccount(username, password);
            User user = User.getUser(acc.AccountID);
            labelName.Text = user.Fullname;
            labelDOB.Text = user.DOB.ToShortDateString();
            labelUsername.Text = username;
            labelAddress.Text = user.Address;
            labelContact.Text = user.Contact.ToString();
        }

        private void GridViewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (GridViewCart.Columns[e.ColumnIndex].Name == "delcol")
                {
                    int rowindex = e.RowIndex;
                    List<Cart> listCart = (List<Cart>)GridViewCart.DataSource;
                    Cart c = listCart[rowindex];
                    Account acc = Account.getAccount(username, password);
                    int userID = DataAccess.GetUserID(acc.AccountID);
                    if (MessageBox.Show("Are you sure want to delete this row?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataAccess.deleteCart(userID, c.ProductID);
                        GridViewCart.DataSource = null;
                        GridViewCart.Columns.Clear();
                        GridViewCart.DataSource = Cart.getAllCarts(userID);
                        addCol();
                    }
                }
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            acc = Account.getAccount(username, password);
            int UserID = DataAccess.GetUserID(acc.AccountID);
            DataTable dt = DataAccess.GetShopID(UserID);
            foreach (DataRow dr in dt.Rows)
            {
                string id = dr["shopid"].ToString();
                int sum = DataAccess.GetSum(id, UserID);
                float fee = 0.1f;
                DateTime orderdate = DateTime.Now;
                DateTime shipdate = orderdate.AddDays(3);
                String status = "waiting";
                int k = DataAccess.addToOrder(UserID, id, fee, sum, orderdate, shipdate, status);
                int k2 = 0;
                if (k != 0)
                {
                    int oid = DataAccess.GetOrderID(UserID, id);
                    List<Cart> carts = Cart.getAllCarts(UserID);
                    foreach (Cart c in carts)
                    {
                        k2 = DataAccess.addToOrderDetail(oid, c.ProductID, c.TotalPrice, c.Quantity);
                    }
                    if (k2 != 0)
                        MessageBox.Show("Create Order successfully!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account acc = Account.getAccount(username, password);
            int userID = DataAccess.GetUserID(acc.AccountID);
            GridViewCart.DataSource = null;
            GridViewCart.Columns.Clear();
            List<Cart> carts = Cart.getAllCarts(userID);
            Console.WriteLine(userID);
            GridViewCart.DataSource = carts;
            addCol();
        }

        private void buttonDetail3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(product3.ToString() + Environment.NewLine + "Do you want to buy this product", "confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                acc = Account.getAccount(username, password);
                int userID = DataAccess.GetUserID(acc.AccountID);
                Double price = Convert.ToDouble(product3.Price);
                if (Cart.getCartByProductID(product3.ProductID) == null)
                {
                    DataAccess.addToCart(product3.ProductID, userID, 1, price);
                }
                else
                {
                    Cart c = Cart.getCartByProductID(product3.ProductID);
                    DataAccess.updateCart(userID, c.ProductID, c.Quantity + 1, Convert.ToDecimal(c.TotalPrice) + product3.Price);
                }

            }
        }

        private void buttonDetail4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(product4.ToString() + Environment.NewLine + "Do you want to buy this product", "confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                acc = Account.getAccount(username, password);

                int userID = DataAccess.GetUserID(acc.AccountID);
                Double price = Convert.ToDouble(product4.Price);
                if (Cart.getCartByProductID(product4.ProductID) == null)
                {
                    DataAccess.addToCart(product4.ProductID, userID, 1, price);
                }
                else
                {
                    Cart c = Cart.getCartByProductID(product4.ProductID);
                    DataAccess.updateCart(userID, c.ProductID, c.Quantity + 1, Convert.ToDecimal(c.TotalPrice) + product4.Price);
                }

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnProductPrevius_Click(object sender, EventArgs e)
        {
            if (pageId > 1)
            {
                pageId -= 1;
                setProducts(pageId, tbxSearchProduct.Text);
            }
        }

        private void btnProductNext_Click(object sender, EventArgs e)
        {
            if(pageId < totalPageSize)
            {
                pageId += 1;
                setProducts(pageId, tbxSearchProduct.Text);
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            pageId = 1;
            setProducts(pageId, tbxSearchProduct.Text);
        }
    }
}
