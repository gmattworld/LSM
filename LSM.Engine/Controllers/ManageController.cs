using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using LSM.Engine.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LSM.Engine.Controllers
{
    public class ManageController : WebApiController
    {

        // Gets all records.
        // This will respond to 
        //     GET /api/manage
        [Route(HttpVerbs.Get, "/manage")]
        public object Get()
        {
            return new JavaScriptSerializer()
            .Serialize(DB.contacts);
        }

        // Gets all records.
        // This will respond to 
        //     GET /api/manage
        [Route(HttpVerbs.Get, "/first")]
        public object GetFirst()
        {
            Contact ct = new Contact();
            ct = null;
            if (DB.contacts != null)
            {
                ct = DB.contacts.FirstOrDefault();
            }
            return new JavaScriptSerializer()
            .Serialize(ct);
        }

        // Gets all records.
        // This will respond to 
        //     GET /api/manage
        [Route(HttpVerbs.Post, "/data")]
        public object PostData([FormData] NameValueCollection model)
        {
            string name = model.Get(0);
            string email = model.Get(1);
            string message = model.Get(2);
            Contact cl = new Contact()
            {
                CreatedDate = DateTime.Now,
                ID = Guid.NewGuid(),
                UpdateDate = DateTime.Now,

                Email = name,
                Message = message,
                Name = email,
            };
            if (DB.contacts == null)
            {
                DB.contacts = new List<Contact>();
            }

            DB.contacts.Add(cl);

            return new JavaScriptSerializer().Serialize(cl);
        }
    }
}
