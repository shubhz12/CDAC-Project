using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineBookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

    public class BooksController : ApiController
    {

        public IEnumerable<Books> Get()
        {
            return BusinessManager.GetAllBooks();
        }
        // GET api/<controller>
       /* public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }  */

        // GET api/<controller>/5
        public Books  Get(int id)
        {
            return BusinessManager.GetBookbyid(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Books newBook)
        {
           return BusinessManager.AddBook(newBook);
        }

        // PUT api/<controller>/5
        public Books Put(int id, [FromBody] Books oldbook)
        {
            return BusinessManager.UpdateBook(oldbook);
        }

        // DELETE api/<controller>/5
        public bool Delete(int book_id)
        {
            return BusinessManager.deleteBook(book_id);
        }
    }
}