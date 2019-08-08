using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRN292_Project
{   
    public partial class FormShop : Form
    {
        private Shop shop = new Shop();
        public  string username;
        public  string password;

        public FormShop()
        {
            InitializeComponent();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //Account a = Shop.getAccount(username, password);
            //Shop s = Shop.getShop(a.AccountID);

            shop.ShopID = "DNP12";
        }
        private void ViewProductLoad()
        {
            GridViewProduct.RowTemplate.Height = 150;
            List<Product> products = Product.getProductsByShop(shop.ShopID);
            DataTable dtproducts = new DataTable();
            dtproducts.Columns.Add("Tên Sản Phẩm");
            dtproducts.Columns.Add("Mô Tả Sản Phẩm");
            dtproducts.Columns.Add("Số Lượng");
            for (int i = 0; i < products.Count; i++)
            {
                dtproducts.Rows.Add(products[i].Title, products[i].Description, products[i].Amount);

            }
            GridViewProduct.DataSource = dtproducts;

            DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
            dgvic.Width = 150;
            dgvic.HeaderText = "Ảnh Minh Họa";
            GridViewProduct.Columns.Add(dgvic);
            for (int row = 0; row < GridViewProduct.Rows.Count; row++)
            {
                Bitmap bmp = new Bitmap(Application.StartupPath + "\\Images\\" + products[row].Image);
                Bitmap bmp2 = new Bitmap(bmp, new Size(150, 150));
                ((DataGridViewImageCell)GridViewProduct.Rows[row].Cells[3]).Value = bmp2;
            }

        }
        private void RequestLoad() {
            GridViewRequest.DataSource = null;
            try
            {
                GridViewRequest.Columns.Clear();
            }
            catch (Exception) { }

            DataTable dtrequests = DataAccess.getOrders(shop.ShopID);
            GridViewRequest.DataSource = dtrequests;
            DataGridViewButtonColumn acceptCol = new DataGridViewButtonColumn();
            acceptCol.Name = "acceptcol";
            acceptCol.HeaderText = "";
            acceptCol.Text = "Accept";
            acceptCol.UseColumnTextForButtonValue = true;
            GridViewRequest.Columns.Add(acceptCol);
            
            DataGridViewButtonColumn denyCol = new DataGridViewButtonColumn();
            denyCol.Name = "denycol";
            denyCol.HeaderText = "";
            denyCol.Text = "Deny";
            denyCol.UseColumnTextForButtonValue = true;
            GridViewRequest.Columns.Add(denyCol);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ViewProductLoad();
            RequestLoad();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            EntryFormcs entryForm = new EntryFormcs();
            entryForm.Show();
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                ptbImage.ImageLocation = open.FileName;
                ptbImage.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal d;
            int i;
            if (!tbxProductName.Text.Equals(String.Empty) && !tbxProductDescription.Text.Equals(String.Empty) && ptbImage.ImageLocation != null
                && int.TryParse(tbxProductAmount.Text, out i) && Convert.ToInt32(tbxProductAmount.Text)>0 && decimal.TryParse(tbxProductPrice.Text, out d) && Convert.ToDecimal(tbxProductPrice.Text)>0)
            {
                string filePath = ptbImage.ImageLocation;
                FileInfo fi = new FileInfo(filePath);
                Image tempImage = Image.FromFile(fi.FullName);
                 
                
                DataAccess.addProduct(tbxProductName.Text, shop.ShopID, fi.Name, Convert.ToDecimal(tbxProductPrice.Text), tbxProductDescription.Text, DateTime.Today, Convert.ToInt32(tbxProductAmount.Text));
                MessageBox.Show("Add successfully!");
            }
            else
            {
                MessageBox.Show("Add failed!");
            }
        }

        private void GridViewRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewRequest.Columns[e.ColumnIndex].Name == "acceptcol")
            {
                int orderid = Convert.ToInt32(GridViewRequest.Rows[e.RowIndex].Cells["OrderID"].Value);
                int k = DataAccess.EditRequest(orderid, "Accepted");
                if (k != 0)
                {
                    MessageBox.Show("Order Accepted");
                    RequestLoad();
                }
            }
            else if (GridViewRequest.Columns[e.ColumnIndex].Name == "denycol")
            {
                int orderid = Convert.ToInt32(GridViewRequest.Rows[e.RowIndex].Cells["OrderID"].Value);
                int k = DataAccess.EditRequest(orderid, "Denied");
                if (k != 0)
                {
                    MessageBox.Show("Order Denied");
                    RequestLoad();
                }
            }
        }


        private void tabControl1_DrawItem_1(object sender, DrawItemEventArgs e)
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

        
    }
}
