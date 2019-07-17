using System;
using System.Web.Http;

namespace APIDeEekhoorn.Controllers
{
    public class EekApiController : ApiController
    {
        protected DateTime startDate;

        public EekApiController()
        {
            startDate = DateTime.Now;
        }
    }
}
