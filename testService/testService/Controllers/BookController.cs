using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testService.Models;

namespace testService.Controllers
{
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
        [HttpGet, Route("{id}")]//можно указать какой тип id
        public IHttpActionResult GetById(string id)
        {
            //valideate id
            if(string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }

            try
            {
                var result = BookStorage.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch(InvalidOperationException ex)
            {
                return InternalServerError(ex);
            }

        }

        //TODO

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var result = BookStorage.GetAll();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        //[HttpPost, Route("")]
        //public IHttpActionResult Create([FromBody]Book book)
        //{

        //}

        //[HttpPut, Route("")]
        //public IHttpActionResult Update([FromBody]Book book)
        //{

        //}

        //[HttpDelete, Route("{id}")]
        //public IHttpActionResult Delete(string id)
        //{

        //}
    }
}
