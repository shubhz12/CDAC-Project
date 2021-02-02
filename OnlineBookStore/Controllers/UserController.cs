using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BOL;
using System.Web.Http.Cors;

namespace OnlineBookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        //GET api/User
        public IEnumerable<Users> Get()
        {
            return BusinessManager.getAllUser();
        }
       /* public IEnumerable<Books> Get()
        {
            return BusinessManager.GetAllBooks();
        } */

        // GET api/<controller>/5//getbyid
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>//addnewuser
        public bool Post([FromBody] Users newUser)
        {
            return BusinessManager.AddUser(newUser);
        }

        // PUT api/<controller>/5//update
        public Users Put(int id, [FromBody] Users olduser)
        {
            return BusinessManager.UpdateUser(olduser);
        }

        // DELETE api/<controller>/5//delete
        public bool deleteUser(int user_id)
        {
            return BusinessManager.deleteUser(user_id);
        }
    }
}