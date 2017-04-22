using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers.api
{
	public class GreatApiController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<MyGreatTable> Get()
		{
			using (MyDbContext context = new MyDbContext())
			{
				return context.MyGreatTables.ToList();
			}
		}

		// GET api/<controller>/5
		public HttpResponseMessage Get(int id)
		{
			if (id < 1)
			{
				HttpError e = new HttpError();
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
			}

			using (MyDbContext context = new MyDbContext())
			{
				return Request.CreateResponse(HttpStatusCode.OK, context.MyGreatTables.SingleOrDefault(mgt => mgt.MyGreatTableId == id));
			}
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}