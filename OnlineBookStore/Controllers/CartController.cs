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
    public class CartController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Cart> Get()
        {
            return BusinessManager.ShowCart();
        }

        public Cart Get(int id)
        {
            return BusinessManager.GetCartitembyid(id);
        }
        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public bool Post([FromBody] Cart newOrder)
        {
            return BusinessManager.AddtoCart(newOrder);
        }

        // PUT api/<controller>/5
        public Cart Put(int id, [FromBody] Cart oldorder)
        {
            return BusinessManager.UpdateCart(oldorder);
        }

        // DELETE api/<controller>/5
        public bool deletefromCart(int cart_id)
        {
            return BusinessManager.deletefromCart(cart_id);
        }
    }
}