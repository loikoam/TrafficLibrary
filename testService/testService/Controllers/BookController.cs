using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testService.Models;
using testService.Logic.Services;

namespace testService.Controllers
{
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet, Route("{id}")]//можно указать какой тип id
        [Description("Get Book model by Id")]// для описания ,но в данном примере не работает...
        [SwaggerResponse(HttpStatusCode.BadRequest, "Invalid paramater format")]// описать возможные ответы от сервиса, может быть Ок, badrequest, internalServer error...
        [SwaggerResponse(HttpStatusCode.NotFound, "Book doesn't exists")]
        [SwaggerResponse(HttpStatusCode.OK, "Book found", typeof(Book))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something wrong")]

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

        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody]Book book)
        {
            // validate book here  //todo, обычно проводиться на стороне клиента
            //201 статус обычно и используют для Create, но там нужно описать, что он возвращает URL, по которому можно обратиться к книге
            return Ok(BookStorage.Add(book));
        }

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
