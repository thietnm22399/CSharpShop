using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PRN292_Project
{
    public class DataAccess
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            return new SqlConnection(connectionString);
        }
        public static DataTable GetDataBySql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetAccount(string u, string p)
        {
            string sql = @"Select * from Account where username = '"+u+"' and password = '"+p +"'";
            return GetDataBySql(sql);
        }

        public static DataTable GetAccount(string u)
        {
            string sql = @"Select * from Account where username = '" + u + "'";
            return GetDataBySql(sql);
        }

        public static DataTable getOrders(string shopid)
        {
            string sql = "select  [Order].[OrderID],[OrderDetail].ProductID, [OrderDetail].Price, [OrderDetail].Quantity,Price*[OrderDetail].Quantity as Cost, [Order].Fee, [Order].Total, [Order].OrderDate, [Order].ShipDate from [Order], [OrderDetail] where [Order].OrderID = [OrderDetail].OrderID and [Order].[Status] = 'Waiting' and [Order].ShopID = '" + shopid + "'";
            return GetDataBySql(sql);
        }

        public static DataTable GetShop(string s)
        {
            string sql = @"Select * from ShopUser where shopid like '%" + s + "%'";
            return GetDataBySql(sql);
        }

        public static DataTable GetShopID(int u)
        {
            string sql = @"select distinct ShopID from Product p inner join Cart c on 
            c.ProductID = p.ProductID where c.UserID = " + u;
            return GetDataBySql(sql);
        }

        public static int GetSum(string sid, int uid)
        {
            string sql = @"select SUM(a.TotalPrice) as Total from (select c.ProductID,c.UserID,c.TotalPrice,
            p.ShopID from Product p inner join Cart c on p.ProductID = c.ProductID 
            where p.ShopID = '" + sid + "') as a where a.UserID = " + uid;
            DataTable dt = GetDataBySql(sql);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                int res = Convert.ToInt32(dr["total"]);
                return res;
            }
            return 0;
        }

        public static DataTable GetListShops(string keyword, int pageId, int pageSize)
        {
            int from = (pageId - 1) * pageSize + 1;
            int to = pageId * pageSize;
            string sql = @"SELECT * FROM(SELECT ROW_NUMBER() OVER"
                 + " (ORDER BY AccountID ASC) as row_num,* FROM ShopUser) tbShop "
                 + "WHERE row_num BETWEEN " + from 
                 + " AND " + to + " and Title like '%" + keyword + "%'";
            return GetDataBySql(sql);
        }

        public static DataTable GetUser(int a)
        {
            string sql = @"Select * from [User] where accountid = " + a;
            return GetDataBySql(sql);
        }

        public static int GetUserID(int a)
        {
            string sql = @"Select userID from [User] where accountid = " + a;
            Console.WriteLine(sql);
            DataTable dt =  GetDataBySql(sql);
            foreach(System.Data.DataRow dr in dt.Rows)
            {
                int res = Convert.ToInt32(dr["userID"]);
                return res;
            }
            return 0;
        }

        public static int addToOrder(int uid, string sid, float fee, double total, DateTime o, DateTime s, String status)
        {
            string sql = @"INSERT INTO [Order]
                       ([userid],[shopid],[fee],[total],[orderdate],[shipdate],[status])
                        VALUES (@userid, @shopid, @fee,@total,@orderdate,@shipdate,@status) ";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter param1 = new SqlParameter("@userid", SqlDbType.Int);
            param1.Value = uid;
            SqlParameter param2 = new SqlParameter("@shopid", SqlDbType.VarChar);
            param2.Value = sid;
            SqlParameter param3 = new SqlParameter("@fee", SqlDbType.Float);
            param3.Value = fee;
            SqlParameter param4 = new SqlParameter("@total", SqlDbType.Money);
            param4.Value = total;
            SqlParameter param5 = new SqlParameter("@orderdate", SqlDbType.DateTime);
            param5.Value = o;
            SqlParameter param6 = new SqlParameter("@shipdate", SqlDbType.DateTime);
            param6.Value = s;
            SqlParameter param7 = new SqlParameter("@status", SqlDbType.VarChar);
            param7.Value = status;
            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);
            command.Parameters.Add(param4);
            command.Parameters.Add(param5);
            command.Parameters.Add(param6);
            command.Parameters.Add(param7);
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

        public static int addToOrderDetail(int oid, int productID, double price, int quantity)
        {
            string sql = @"INSERT INTO [orderdetail]
                       ([orderid],[productid],[price],[quantity])
                        VALUES (@orderid, @productid,@price, @quantity) ";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter param1 = new SqlParameter("@orderid", SqlDbType.Int);
            param1.Value = oid;
            SqlParameter param2 = new SqlParameter("@productid", SqlDbType.Int);
            param2.Value = productID;
            SqlParameter param3 = new SqlParameter("@price", SqlDbType.Money);
            param3.Value = price;
            SqlParameter param4 = new SqlParameter("@quantity", SqlDbType.Int);
            param4.Value = quantity;
            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);
            command.Parameters.Add(param4);

            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }



        public static DataTable GetListProducts(string keyword, int pageId, int pageSize)
        {
            int from = (pageId - 1) * pageSize + 1;
            int to = pageId * pageSize;
            string sql = @"SELECT * FROM(SELECT ROW_NUMBER() OVER"
                 + " (ORDER BY ProductID ASC) as row_num,* FROM Product) tbPro "
                 + "WHERE row_num "
                 + "BETWEEN " + from + " AND " + to + " and title like '%" + keyword + "%'";
                 
            return GetDataBySql(sql);
        }

        public static DataTable GetProductsByShop(string shopid)
        {
            string sql = @"Select * from Product where shopid like '%" + shopid + "%'";
            return GetDataBySql(sql);
        }

        public static DataTable GetCarts(int u)
        {
            string sql = @"Select * from Cart where userid = " + u;
            return GetDataBySql(sql);
        }

        public static int addProduct(string title,string shopID, string img, decimal price, string Description, DateTime uploadDate, int amount)
        {
            string sql = @"INSERT INTO [Product]
                       ([title],[shopid],[image],[price],[description],[uploaddate],[amount])
                        VALUES (@title, @shopid, @image,@price,@description,@uploaddate,@amount) ";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar);
            param1.Value = title;
            SqlParameter param2 = new SqlParameter("@shopid", SqlDbType.VarChar);
            param2.Value = shopID;
            SqlParameter param3 = new SqlParameter("@image", SqlDbType.VarChar);
            param3.Value = img;
            SqlParameter param4 = new SqlParameter("@price", SqlDbType.Money);
            param4.Value = price;
            SqlParameter param5 = new SqlParameter("@description", SqlDbType.NVarChar);
            param5.Value = Description;
            SqlParameter param6 = new SqlParameter("@uploaddate", SqlDbType.DateTime);
            param6.Value = uploadDate;
            SqlParameter param7 = new SqlParameter("@amount", SqlDbType.Int);
            param7.Value = amount;
            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);
            command.Parameters.Add(param4);
            command.Parameters.Add(param5);
            command.Parameters.Add(param6);
            command.Parameters.Add(param7);
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

        public static int GetOrderID(int u, string s)
        {
            string sql = @"Select OrderID from [Order] where userid = " + u + " and shopid = '" + s + "'";
            DataTable dt = GetDataBySql(sql);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                int res = Convert.ToInt32(dr["orderid"]);
                return res;
            }
            return 0;
        }

        public static int addToCart(int productID, int userID,int quantity, double total)
        {
            string sql = @"INSERT INTO [Cart]
                       ([userid],[productid],[quantity],[totalprice])
                        VALUES (@userid, @productid, @quantity,@totalprice) ";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter param1 = new SqlParameter("@userid", SqlDbType.Int);
            param1.Value = userID;
            SqlParameter param2 = new SqlParameter("@productid", SqlDbType.Int);
            param2.Value = productID ;
            SqlParameter param3 = new SqlParameter("@quantity", SqlDbType.Int);
            param3.Value = quantity;
            SqlParameter param4 = new SqlParameter("@totalprice", SqlDbType.Money);
            param4.Value = total;
            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);
            command.Parameters.Add(param4);
            
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

        private static void addAccount(string username, string password, string role)
        {
            string sql = "insert into Account (username, [Password], [role]) values (@pusername,@ppassword,@prole)";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter para1 = new SqlParameter("@pusername", SqlDbType.VarChar);
            para1.Value = username;
            SqlParameter para2 = new SqlParameter("@ppassword", SqlDbType.VarChar);
            para2.Value = password;
            SqlParameter para3 = new SqlParameter("@prole", SqlDbType.VarChar);
            para3.Value = role;
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);
            command.Parameters.Add(para3);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static DataTable GetCartByProductID(int productID)
        {
            string sql = "select * from cart where productID = " + productID;
            return GetDataBySql(sql);
        }

        public static void updateCart(int userID, int productID, int amount, decimal totalPrice)
        {
            string sql = "update Cart set quantity = @p1, totalPrice = @p2 where userID = @p3 and productID = @p4";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter para1 = new SqlParameter("@p1", SqlDbType.Int);
            para1.Value = amount;
            SqlParameter para2 = new SqlParameter("@p2", SqlDbType.Money);
            para2.Value = totalPrice;
            SqlParameter para3 = new SqlParameter("@p3", SqlDbType.Int);
            para3.Value = userID;
            SqlParameter para4 = new SqlParameter("@p4", SqlDbType.Int);
            para4.Value = productID;
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);
            command.Parameters.Add(para3);
            command.Parameters.Add(para4);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void addUser(string username, string password, string fullname, string address, string email, string contact, DateTime dob)
        {
            addAccount(username, password, "Client");
            Account account = Account.getAccount(username, password);
            string sql = "insert into [User] (fullname, accountID, [address], contact, email, DOB) values (@p1,@p2,@p3,@p4,@p5,@p6)";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter para1 = new SqlParameter("@p1", SqlDbType.VarChar);
            para1.Value = fullname;
            SqlParameter para2 = new SqlParameter("@p2", SqlDbType.Int);
            para2.Value = account.AccountID;
            SqlParameter para3 = new SqlParameter("@p3", SqlDbType.NVarChar);
            para3.Value = address;
            SqlParameter para4 = new SqlParameter("@p4", SqlDbType.NVarChar);
            para4.Value = contact;
            SqlParameter para5 = new SqlParameter("@p5", SqlDbType.VarChar);
            para5.Value = email;
            SqlParameter para6 = new SqlParameter("@p6", SqlDbType.Date);
            para6.Value = dob;
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);
            command.Parameters.Add(para3);
            command.Parameters.Add(para4);
            command.Parameters.Add(para5);
            command.Parameters.Add(para6);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public static void addShop(string ShopID, string username, string password, string title, string address, string email, string contact, string description, string image)
        {
            addAccount(username, password, "Shop");
            Account account = Account.getAccount(username, password);
            string sql = "insert into ShopUser (ShopID,accountID,title,[address],contact,email,description, image) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter para1 = new SqlParameter("@p1", SqlDbType.VarChar);
            para1.Value = ShopID;
            SqlParameter para2 = new SqlParameter("@p2", SqlDbType.Int);
            para2.Value = account.AccountID;
            SqlParameter para3 = new SqlParameter("@p3", SqlDbType.NVarChar);
            para3.Value = title;
            SqlParameter para4 = new SqlParameter("@p4", SqlDbType.NVarChar);
            para4.Value = address;
            SqlParameter para5 = new SqlParameter("@p5", SqlDbType.Int);
            para5.Value = contact;
            SqlParameter para6 = new SqlParameter("@p6", SqlDbType.VarChar);
            para6.Value = email;
            SqlParameter para7 = new SqlParameter("@p7", SqlDbType.NVarChar);
            para7.Value = description;
            SqlParameter para8 = new SqlParameter("@p8", SqlDbType.VarChar);
            para8.Value = image;
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);
            command.Parameters.Add(para3);
            command.Parameters.Add(para4);
            command.Parameters.Add(para5);
            command.Parameters.Add(para6);
            command.Parameters.Add(para7);
            command.Parameters.Add(para8);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        internal static void deleteCart(int userID, int productID)
        {
            string sql = "DELETE FROM Cart where userid = " + userID + " and productid = " + productID;
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            
        }

        public static int EditRequest(int orderid, string status)
        {
            string sql = "update [Order] set [Status] = '" + status + "' where OrderID = " + orderid;
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;


        }

    }
}
