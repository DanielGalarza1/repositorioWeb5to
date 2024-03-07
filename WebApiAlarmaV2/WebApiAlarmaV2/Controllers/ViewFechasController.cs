using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAlarmaV2.Models;

namespace WebApiAlarmaV2.Controllers
{
    public class ViewFechasController : ApiController
    {
        private AlarmasComunitariasEntities3 db = new AlarmasComunitariasEntities3();

        // GET: api/Alarmas
        public IHttpActionResult GetViewFechasData()
        {
            var viewData = db.ViewFechas();
            return Ok(viewData);
        }
    }
}
