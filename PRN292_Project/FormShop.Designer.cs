namespace PRN292_Project
{
    partial class FormShop
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageViewProduct = new System.Windows.Forms.TabPage();
            this.GridViewProduct = new System.Windows.Forms.DataGridView();
            this.tabPageAddProduct = new System.Windows.Forms.TabPage();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxProductPrice = new System.Windows.Forms.TextBox();
            this.tbxProductAmount = new System.Windows.Forms.TextBox();
            this.tbxProductDescription = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tabPageRequest = new System.Windows.Forms.TabPage();
            this.GridViewRequest = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageViewProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProduct)).BeginInit();
            this.tabPageAddProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.tabPageRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageViewProduct);
            this.tabControl1.Controls.Add(this.tabPageAddProduct);
            this.tabControl1.Controls.Add(this.tabPageRequest);
            this.tabControl1.ItemSize = new System.Drawing.Size(210, 21);
            this.tabControl1.Location = new System.Drawing.Point(15, 86);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(845, 511);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem_1);
            // 
            // tabPageViewProduct
            // 
            this.tabPageViewProduct.Controls.Add(this.GridViewProduct);
            this.tabPageViewProduct.Location = new System.Drawing.Point(4, 25);
            this.tabPageViewProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageViewProduct.Name = "tabPageViewProduct";
            this.tabPageViewProduct.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageViewProduct.Size = new System.Drawing.Size(837, 482);
            this.tabPageViewProduct.TabIndex = 0;
            this.tabPageViewProduct.Text = "View Product";
            this.tabPageViewProduct.UseVisualStyleBackColor = true;
            // 
            // GridViewProduct
            // 
            this.GridViewProduct.AllowUserToAddRows = false;
            this.GridViewProduct.BackgroundColor = System.Drawing.Color.White;
            this.GridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewProduct.Location = new System.Drawing.Point(5, 19);
            this.GridViewProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridViewProduct.Name = "GridViewProduct";
            this.GridViewProduct.RowTemplate.Height = 24;
            this.GridViewProduct.Size = new System.Drawing.Size(827, 463);
            this.GridViewProduct.TabIndex = 0;
            // 
            // tabPageAddProduct
            // 
            this.tabPageAddProduct.Controls.Add(this.ptbImage);
            this.tabPageAddProduct.Controls.Add(this.label4);
            this.tabPageAddProduct.Controls.Add(this.label3);
            this.tabPageAddProduct.Controls.Add(this.label2);
            this.tabPageAddProduct.Controls.Add(this.label1);
            this.tabPageAddProduct.Controls.Add(this.btnAdd);
            this.tabPageAddProduct.Controls.Add(this.tbxProductPrice);
            this.tabPageAddProduct.Controls.Add(this.tbxProductAmount);
            this.tabPageAddProduct.Controls.Add(this.tbxProductDescription);
            this.tabPageAddProduct.Controls.Add(this.tbxProductName);
            this.tabPageAddProduct.Controls.Add(this.btnBrowse);
            this.tabPageAddProduct.Location = new System.Drawing.Point(4, 25);
            this.tabPageAddProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAddProduct.Name = "tabPageAddProduct";
            this.tabPageAddProduct.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAddProduct.Size = new System.Drawing.Size(837, 482);
            this.tabPageAddProduct.TabIndex = 1;
            this.tabPageAddProduct.Text = "Add Product";
            this.tabPageAddProduct.UseVisualStyleBackColor = true;
            // 
            // ptbImage
            // 
            this.ptbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.ptbImage.Location = new System.Drawing.Point(39, 47);
            this.ptbImage.Margin = new System.Windows.Forms.Padding(4);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(265, 219);
            this.ptbImage.TabIndex = 10;
            this.ptbImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(533, 288);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxProductPrice
            // 
            this.tbxProductPrice.Location = new System.Drawing.Point(424, 247);
            this.tbxProductPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxProductPrice.Name = "tbxProductPrice";
            this.tbxProductPrice.Size = new System.Drawing.Size(308, 22);
            this.tbxProductPrice.TabIndex = 4;
            // 
            // tbxProductAmount
            // 
            this.tbxProductAmount.Location = new System.Drawing.Point(424, 178);
            this.tbxProductAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxProductAmount.Name = "tbxProductAmount";
            this.tbxProductAmount.Size = new System.Drawing.Size(308, 22);
            this.tbxProductAmount.TabIndex = 3;
            // 
            // tbxProductDescription
            // 
            this.tbxProductDescription.Location = new System.Drawing.Point(424, 118);
            this.tbxProductDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxProductDescription.Name = "tbxProductDescription";
            this.tbxProductDescription.Size = new System.Drawing.Size(308, 22);
            this.tbxProductDescription.TabIndex = 2;
            // 
            // tbxProductName
            // 
            this.tbxProductName.Location = new System.Drawing.Point(424, 47);
            this.tbxProductName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(308, 22);
            this.tbxProductName.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(129, 288);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tabPageRequest
            // 
            this.tabPageRequest.Controls.Add(this.GridViewRequest);
            this.tabPageRequest.Location = new System.Drawing.Point(4, 25);
            this.tabPageRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRequest.Name = "tabPageRequest";
            this.tabPageRequest.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRequest.Size = new System.Drawing.Size(837, 482);
            this.tabPageRequest.TabIndex = 2;
            this.tabPageRequest.Text = "Request";
            this.tabPageRequest.UseVisualStyleBackColor = true;
            // 
            // GridViewRequest
            // 
            this.GridViewRequest.AllowUserToAddRows = false;
            this.GridViewRequest.BackgroundColor = System.Drawing.Color.White;
            this.GridViewRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewRequest.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewRequest.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GridViewRequest.Location = new System.Drawing.Point(7, 25);
            this.GridViewRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridViewRequest.Name = "GridViewRequest";
            this.GridViewRequest.RowTemplate.Height = 24;
            this.GridViewRequest.Size = new System.Drawing.Size(825, 446);
            this.GridViewRequest.TabIndex = 0;
            this.GridViewRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewRequest_CellClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(13, 31);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(109, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(880, 626);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormShop";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageViewProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProduct)).EndInit();
            this.tabPageAddProduct.ResumeLayout(false);
            this.tabPageAddProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.tabPageRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageViewProduct;
        private System.Windows.Forms.TabPage tabPageAddProduct;
        private System.Windows.Forms.TabPage tabPageRequest;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView GridViewProduct;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView GridViewRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxProductPrice;
        private System.Windows.Forms.TextBox tbxProductAmount;
        private System.Windows.Forms.TextBox tbxProductDescription;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptbImage;
    }
}