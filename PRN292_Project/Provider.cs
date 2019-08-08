using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PRN292_Project
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountID { get; set; }
        public string Role { get; set; }

        public Account() { }

        public Account(string username, string password, int accountID, string role)
        {
            Username = username;
            Password = password;
            AccountID = accountID;
            Role = role;
        }

        public static Account getAccount(string username, string password)
        {
            DataTable dt = DataAccess.GetAccount(username, password);
            foreach (DataRow dr in dt.Rows)
            {
                Account a = new Account(username, password, Convert.ToInt32(dr["accountid"]),dr["role"].ToString());
                return a;
            }
            return null;
        }

        public static Account getAccountByUsername(string username)
        {
            DataTable dt = DataAccess.GetAccount(username);
            foreach (DataRow dr in dt.Rows)
            {
                Account a = new Account(username, "zzz", Convert.ToInt32(dr["accountid"]), dr["role"].ToString());
                return a;
            }
            return null;
        }
    }

    class User : Account
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }

        public User() { }

        public User(string fullname, string address, int contact, string email, DateTime dOB)
        {
            Fullname = fullname;
            Address = address;
            Contact = contact;
            Email = email;
            DOB = dOB;
        }

        public static User getUser(int accountID)
        {
            DataTable dt = DataAccess.GetUser(accountID);
            foreach (DataRow dr in dt.Rows)
            {
                User u = new User(dr["fullname"].ToString(), dr["address"].ToString(),
                    Convert.ToInt32(dr["contact"]), dr["email"].ToString(),Convert.ToDateTime(dr["DOB"]));
                return u;
            }
            return null;
        }
    }

    class Shop : Account
    {
        public string ShopID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Shop() { }

        public Shop(string shopID, string title, string address, int contact, string email, string description, string image)
        {
            ShopID = shopID;
            Title = title;
            Address = address;
            Contact = contact;
            Email = email;
            Description = description;
            Image = image;
        }

        public static List<Shop> searchShop(string keyword, int pageId, int pageSize) {
            List<Shop> shops = new List<Shop>();
            DataTable dt = DataAccess.GetListShops(keyword, pageId, pageSize);
            foreach (DataRow dr in dt.Rows)
            {
                Shop s = new Shop(dr["shopid"].ToString(), dr["title"].ToString(), dr["address"].ToString(),
                    Convert.ToInt32(dr["contact"]), dr["email"].ToString(), dr["description"].ToString(),dr["image"].ToString());
                shops.Add(s);
            }
            return shops;
        }   
        
        public static Shop getShop(string shopID)
        {
            DataTable dt = DataAccess.GetShop(shopID);
            foreach (DataRow dr in dt.Rows)
            {
                Shop s = new Shop(dr["shopid"].ToString(), dr["title"].ToString(), dr["address"].ToString(),
                    Convert.ToInt32(dr["contact"]), dr["email"].ToString(), dr["description"].ToString(), dr["image"].ToString());
                return s;
            }
            return null;
        }
    }

    class Product
    {
        public int ProductID { get; set; }
        public String ShopID { get; set; }
        public String Title { get; set; }
        public String Image { get; set; }
        public Decimal Price { get; set; }
        public String Description { get; set; }
        public DateTime UploadDate { get; set; }
        public int Amount { get; set; }

        public Product() { }

        public Product(int productID,string title, string shopID, string image, decimal price, string description, DateTime uploadDate,int amount)
        {
            ProductID = productID;
            Title = title;
            ShopID = shopID;
            Image = image;
            Price = price;
            Description = description;
            UploadDate = uploadDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return Title + Environment.NewLine + ShopID + Environment.NewLine + Price 
                + Environment.NewLine + Description + Environment.NewLine + Amount + Environment.NewLine;
        }

        public static List<Product> searchProduct(string keyword, int pageId, int pageSize)
        {
            List<Product> products = new List<Product>();
            DataTable dt = DataAccess.GetListProducts(keyword, pageId, pageSize);
            foreach (DataRow dr in dt.Rows)
            {
                Product p = new Product(Convert.ToInt32(dr["productid"]),dr["title"].ToString(), dr["shopid"].ToString(), dr["image"].ToString(),
                    Convert.ToDecimal(dr["price"]), dr["description"].ToString(), Convert.ToDateTime(dr["uploaddate"]),Convert.ToInt32(dr["amount"]));
                products.Add(p);
            }
            return products;
        }

        public static List<Product> getProductsByShop(string shopID)
        {
            List<Product> products = new List<Product>();
            DataTable dt = DataAccess.GetProductsByShop(shopID);
            foreach (DataRow dr in dt.Rows)
            {
                Product p = new Product(Convert.ToInt32(dr["productid"]), dr["title"].ToString(), dr["shopid"].ToString(), dr["image"].ToString(),
                    Convert.ToDecimal(dr["price"]), dr["description"].ToString(), Convert.ToDateTime(dr["uploaddate"]), Convert.ToInt32(dr["amount"]));
                products.Add(p);
            }
            return products;
        } 
    }

    class Cart
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public Cart(int p, int q, double t)
        {
            this.ProductID = p;
            this.Quantity = q;
            this.TotalPrice = t;
        }

        public static List<Cart> getAllCarts(int userID)
        {
            List<Cart> carts = new List<Cart>();
            DataTable dt = DataAccess.GetCarts(userID);
            foreach (DataRow dr in dt.Rows)
            {
                Cart c = new Cart(Convert.ToInt32(dr["productid"]), Convert.ToInt32(dr["quantity"]),
                    Convert.ToDouble(dr["totalprice"]));
                carts.Add(c);
            }
            return carts;
        }

        public static Cart getCartByProductID(int productID)
        {

            DataTable dt = DataAccess.GetCartByProductID(productID);
            foreach (DataRow dr in dt.Rows)
            {
                Cart c = new Cart(Convert.ToInt32(dr["productid"]), Convert.ToInt32(dr["quantity"]),
                    Convert.ToDouble(dr["totalprice"]));
                return c;
            }
            return null;
        }
    }

    class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Fee { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public Order(int oid, int pid, decimal p, int q, decimal c, decimal f, decimal t, DateTime od, DateTime sd, string s)
        {
            OrderID = oid;
            ProductID = pid;
            Price = p;
            Quantity = q;
            Cost = c;
            Fee = f;
            Total = t;
            OrderDate = od;
            ShipDate = sd;
            Status = s;
        }
        public static List<Order> getOrders(string ShopID)
        {
            List<Order> orders = new List<Order>();
            DataTable dt = DataAccess.getOrders(ShopID);
            foreach (DataRow dr in dt.Rows)
            {
                Order o = new Order(Convert.ToInt32(dr["OrderID"]), Convert.ToInt32(dr["ProductID"]), Convert.ToDecimal(dr["Price"]), Convert.ToInt32(dr["Quantity"]), Convert.ToDecimal(dr["Cost"]), Convert.ToDecimal(dr["Fee"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["OrderDate"]), Convert.ToDateTime(dr["ShipDate"]), dr["Status"].ToString());

                orders.Add(o);
            }
            return orders;
        }
    }
}
