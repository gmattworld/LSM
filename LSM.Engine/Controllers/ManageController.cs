using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
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
            .Serialize(new
            {
                date = "hihih",
                value = "ksdjkjfsd"
            });
        }
    }
}
