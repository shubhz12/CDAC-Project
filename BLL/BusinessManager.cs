using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
namespace BLL
{
    public class BusinessManager
    {
        public static Users ValidateUser(Login dto)
        {
            return DBManager.ValidateUser(dto);
        }
        public static List<Users> getAllUser()
        {
            return DBManager.GetAllUser();
        }

        public static List<Books> GetAllBooks()
        {
            return DBManager.GetAllBooks();
        }
        public static bool AddBook(Books book)
        {
            return DBManager.AddBook(book);
        }
        public static  bool deleteBook(int bookid)
        {
            return  DBManager.deleteBook(bookid);
        }

        public static bool deleteUser(int userid)
        {
            return DBManager.deleteUser(userid);
        }
        public static Books UpdateBook(Books book)
        {
            return DBManager.UpdateBook(book);
        }

        public static Users UpdateUser(Users users)
        {
            return DBManager.UpdateUser(users);
        }
        public static bool AddUser(Users users)
        {
            return DBManager.AddUser(users);
        }

        public static List<Cart> ShowCart()
        {
            return DBManager.ShowCart();
        }

        public static bool AddtoCart(Cart cart)
        {
            return DBManager.AddtoCart(cart);
        }

        public static bool deletefromCart(int cartid)
        {
            return DBManager.deletefromCart(cartid);
        }

        public static Cart UpdateCart(Cart cart)
        {
            return DBManager.UpdateCart(cart);
        }
        public static Books GetBookbyid(int bookid)
        {
            return DBManager.GetBookbyid(bookid);
        }
        public static Cart GetCartitembyid(int cartid)
        {
            return DBManager.GetCartitembyid(cartid);
        }

    }
}
