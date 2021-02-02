using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BOL;
using MySql.Data.MySqlClient;
using System.Data;


namespace DAL
{
    public static class DBManager
    {
        public static readonly string connstring = string.Empty;
        static DBManager()
        {
            connstring = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }
        public static List<Users> GetAllUser()
        {

            {
                List<Users> users = new List<Users>();
                IDbConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                string query = "Select * from users";
                IDbCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
                DataSet ds = new DataSet();
                try
                {
                    MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    {
                        foreach (DataRow datarow in dt.Rows)
                        {
                            int user_id = int.Parse(datarow["user_id"].ToString());
                            string address = datarow["address"].ToString();
                            int contact_no = int.Parse(datarow["contact_no"].ToString());
                            string password = datarow["password"].ToString();
                            string role = datarow["role"].ToString();
                            string username = datarow["username"].ToString();
                            string first_name = datarow["first_name"].ToString();
                            string last_name = datarow["last_name"].ToString();
                            string city = datarow["city"].ToString();
                            string country = datarow["country"].ToString();
                            int zip = int.Parse(datarow["zip"].ToString());
                            users.Add(new Users()
                            {
                                user_id = user_id,
                                address = address,
                                contact_no = contact_no,
                                password = password,
                                role = role,
                                username = username,
                                FirstName = first_name,
                                LastName = last_name,
                                City = city,
                                Country = country,
                                Zip = zip


                            });
                        }
                    }

                }
                catch (MySqlException e)

                {
                    string msg = e.Message;
                }
                return users;
            }
        }


        public static List<Books> GetAllBooks()
        {
            List<Books> books = new List<Books>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from books";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                {
                    foreach (DataRow datarow in dt.Rows)
                    {
                        int book_id = int.Parse(datarow["book_id"].ToString());
                        string desc = datarow["description"].ToString();
                        string author = datarow["author"].ToString();
                        string title = datarow["title"].ToString();
                        double price = double.Parse(datarow["price"].ToString());
                        int count = int.Parse(datarow["count"].ToString());
                        books.Add(new Books()
                        {
                            Book_id = book_id,
                            Title = title,
                            Description = desc,
                            Price = price,
                            count = count,
                            Author = author,

                        });
                    }
                }

            }
            catch (MySqlException e)

            {
                string msg = e.Message;
            }
            return books;
        }
        public static bool AddBook(Books books)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from books";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataRow row = ds.Tables[0].NewRow();
                row["book_id"] = books.Book_id;
                row["title"] = books.Title;
                row["description"] = books.Description;
                row["price"] = books.Price;
                row["count"] = books.count;
                row["isbn"] = books.ISBN;
                row["author"] = books.Author;
                ds.Tables[0].Rows.Add(row);
                da.Update(ds);
                status = true;
            }
            catch (MySqlException e)

            {
                string msg = e.Message;
            }

            return status;
        }
        public static bool AddUser(Users users)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from users";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataRow row = ds.Tables[0].NewRow();
                row["user_id"] = users.user_id;
                row["address"] = users.address;
                row["contact_no"] = users.contact_no;
                row["password"] = users.password;
                row["role"] = users.role;
                row["username"] = users.username;
                row["first_name"] = users.FirstName;
                row["last_name"] = users.LastName;
                row["city"] = users.City;
                row["country"] = users.Country;
                row["zip"] = users.Zip;
                ds.Tables[0].Rows.Add(row);
                da.Update(ds);
                status = true;
            }
            catch (MySqlException e)

            {
                string msg = e.Message;
            }

            return status;
        }



        public static bool deleteBook(int book_id)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from books where book_id=" + book_id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keysColumns = new DataColumn[1];
                keysColumns[0] = ds.Tables[0].Columns["book_id"];
                ds.Tables[0].PrimaryKey = keysColumns;
                DataRow dataRow = ds.Tables[0].Rows.Find(book_id);
                dataRow.Delete();
                da.Update(ds);
                status = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }

            return status;
        }

        public static bool deleteUser(int user_id)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from users where user_id=" + user_id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keysColumns = new DataColumn[1];
                keysColumns[0] = ds.Tables[0].Columns["user_id"];
                ds.Tables[0].PrimaryKey = keysColumns;
                DataRow dataRow = ds.Tables[0].Rows.Find(user_id);
                dataRow.Delete();
                da.Update(ds);
                status = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }

            return status;
        }

        public static Books UpdateBook(Books book)
        {
            //bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from books";
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["book_id"];
                ds.Tables[0].PrimaryKey = keyColumns;
                DataRow row = ds.Tables[0].Rows.Find(book.Book_id);
                row["author"] = book.Author;
                row["count"] = book.count;
                row["description"] = book.Description;
                row["isbn"] = book.ISBN;
                row["price"] = book.Price;
                row["title"] = book.Title;
                da.Update(ds);
                //status = true;
                return book;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }

            return null;
        }

        public static Users UpdateUser(Users users)
        {
            //bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from users";
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["user_id"];
                ds.Tables[0].PrimaryKey = keyColumns;
                DataRow row = ds.Tables[0].Rows.Find(users.user_id);
                row["address"] = users.address;
                row["contact_no"] = users.contact_no;
                row["password"] = users.password;
                row["role"] = users.role;
                row["username"] = users.username;
                row["first_name"] = users.FirstName;
                row["last_name"] = users.LastName;
                row["city"] = users.City;
                row["country"] = users.Country;
                row["zip"] = users.Zip;
                da.Update(ds);
                //status = true;
                return users;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }

            return null;
        }

        public static Users ValidateUser(Login dto)
        {
            Users login = new Users();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from users where username='" + dto.Username + "' and password='" + dto.Password + "'";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                {
                    foreach (DataRow datarow in dt.Rows)
                    {
                        login.user_id = int.Parse(datarow["user_id"].ToString());
                        login.FirstName = datarow["first_name"].ToString();
                        login.LastName = datarow["last_name"].ToString();
                        login.username = datarow["username"].ToString();
                        login.password = datarow["password"].ToString();
                        login.role = datarow["role"].ToString();
                    }
                }
            }
            catch (MySqlException e)
            {
                string msg = e.Message;
            }
            return login;
        }

        public static bool AddtoCart(Cart cart)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from cart";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataRow row = ds.Tables[0].NewRow();
                row["cart_id"] = cart.cart_id;
                row["quantity"] = cart.Quantity;
                row["total_amount"] = cart.Total_amount;
                row["user_id"] = cart.user_id;
                row["price"] = cart.Price;
                row["title"] = cart.Title;
                ds.Tables[0].Rows.Add(row);
                da.Update(ds);
                status = true;
            }
            catch (MySqlException e)

            {
                string msg = e.Message;
            }

            return status;
        }

        public static List<BOL.Cart> ShowCart()
        {

            {
                List<Cart> cart = new List<Cart>();
                IDbConnection conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                string query = "Select * from cart";

                IDbCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
                DataSet ds = new DataSet();
                try
                {
                    MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    {
                        foreach (DataRow datarow in dt.Rows)
                        {
                            int cart_id = int.Parse(datarow["cart_id"].ToString());
                            int quantity = int.Parse(datarow["quantity"].ToString());
                            double total_amount = int.Parse(datarow["total_amount"].ToString());
                            int user_id = int.Parse(datarow["user_id"].ToString());
                            int price = int.Parse(datarow["price"].ToString());
                            string title = datarow["title"].ToString();

                            cart.Add(new Cart()
                            {
                                cart_id = cart_id,
                                Quantity = quantity,
                                Total_amount = quantity*price,
                                user_id = user_id,
                                Price = price,
                                Title = title



                            });
                        }
                    }

                }
                catch (MySqlException e)

                {
                    string msg = e.Message;
                }
                return cart;
            }
        }
        public static bool deletefromCart(int cart_id)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from cart where cart_id=" + cart_id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keysColumns = new DataColumn[1];
                keysColumns[0] = ds.Tables[0].Columns["cart_id"];
                ds.Tables[0].PrimaryKey = keysColumns;
                DataRow dataRow = ds.Tables[0].Rows.Find(cart_id);
                dataRow.Delete();
                da.Update(ds);
                status = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }

            return status;
        }

        public static Cart UpdateCart(BOL.Cart cart)
        {
            //bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from cart";
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["cart_id"];
                ds.Tables[0].PrimaryKey = keyColumns;
                DataRow row = ds.Tables[0].Rows.Find(cart.cart_id);
                row["quantity"] = cart.Quantity;
                row["total_amount"] = cart.Total_amount;
                row["user_id"] = cart.user_id;
                row["price"] = cart.Price;
                row["title"] = cart.Title;
                da.Update(ds);
                //status = true;
                return cart;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }

            return null;
        }

        public static Books GetBookbyid(int book_id)
        {
            Books thebook = new Books();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from books WHERE book_id=" + book_id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    thebook.Book_id = int.Parse(row["book_id"].ToString());
                    thebook.Author = row["author"].ToString();
                    thebook.count = int.Parse(row["count"].ToString());
                    thebook.Description = row["description"].ToString();
                    thebook.Price = double.Parse(row["price"].ToString());
                    thebook.ISBN=(row["isbn"].ToString());
                    thebook.Title = row["title"].ToString();
                }
            }
            catch (MySqlException e)
            {
                string msg = e.Message;
            }
            return thebook;

        }

        public static Cart GetCartitembyid(int cart_id)
        {
            Cart thecart = new Cart();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            string query = "Select * from cart WHERE cart_id=" + cart_id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    thecart.cart_id = int.Parse(row["cart_id"].ToString());
                    thecart.Quantity = int.Parse(row["quantity"].ToString());
                    thecart.Total_amount = double.Parse(row["total_amount"].ToString());
                    thecart.user_id = int.Parse(row["user_id"].ToString());
                    thecart.Price = int.Parse(row["price"].ToString());
                    thecart.Title = row["title"].ToString();
                }
            }
            catch (MySqlException e)
            {
                string msg = e.Message;
            }
            return thecart;

        }
    }
}
