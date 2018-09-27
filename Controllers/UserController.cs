using AMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Mvc;

namespace AMSApi.Controllers
{
    public class UserController : ODataController
    {
        private UserContext dbContext = new UserContext();

        private bool UserExists(string key)
        {
            return dbContext.Users.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<User> Get()
        {
            return dbContext.Users;
        }

        [EnableQuery]
        public SingleResult<User> Get([FromODataUri] string key)
        {
            IQueryable<User> result = dbContext.Users.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }
    }
}