using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BetABeer.Api.Controllers
{
    public abstract class BaseCRUDController<T> : ApiController where T : class, IClientEntity
    {
        protected readonly IRepository<T> _repo;

        public BaseCRUDController(IRepository<T> repo)
            : base()
        {
            this._repo = repo;
        }

        // GET api/T
        public virtual List<T> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        // GET api/T/5
        public virtual T Get(long id)
        {
            T entity = _repo.GetById(id);
            if (entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return entity;
        }

        // PUT api/T/5
        public virtual HttpResponseMessage Put(long id, [FromBody] T entity)
        {
            if (ModelState.IsValid && id == entity.Id)
            {
                _repo.Attach(entity);

                try
                {
                    _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/T
        public virtual HttpResponseMessage Post([FromBody] T entity)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert(entity);
                _repo.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, entity);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/T/5
        public virtual HttpResponseMessage Delete(long id)
        {
            T entity = _repo.GetById(id);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _repo.Delete(entity);

            try
            {
                _repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
    }
}
