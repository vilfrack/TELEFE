using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TableCoordenadasController : ApiController
    {
        private CoordenadasEntities db = new CoordenadasEntities();

        // GET: api/TableCoordenadas
        public IQueryable<TableCoordenadas> GetTableCoordenadas()
        {
            return db.TableCoordenadas;
        }

        // GET: api/TableCoordenadas/5
        [ResponseType(typeof(TableCoordenadas))]
        public IHttpActionResult GetTableCoordenadas(int id)
        {
            TableCoordenadas tableCoordenadas = db.TableCoordenadas.Find(id);
            if (tableCoordenadas == null)
            {
                return NotFound();
            }

            return Ok(tableCoordenadas);
        }

        // PUT: api/TableCoordenadas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTableCoordenadas(int id, TableCoordenadas tableCoordenadas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableCoordenadas.id)
            {
                return BadRequest();
            }

            db.Entry(tableCoordenadas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableCoordenadasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TableCoordenadas
        [ResponseType(typeof(TableCoordenadas))]
        public IHttpActionResult PostTableCoordenadas(TableCoordenadas tableCoordenadas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TableCoordenadas.Add(tableCoordenadas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tableCoordenadas.id }, tableCoordenadas);
        }

        // DELETE: api/TableCoordenadas/5
        [ResponseType(typeof(TableCoordenadas))]
        public IHttpActionResult DeleteTableCoordenadas(int id)
        {
            TableCoordenadas tableCoordenadas = db.TableCoordenadas.Find(id);
            if (tableCoordenadas == null)
            {
                return NotFound();
            }

            db.TableCoordenadas.Remove(tableCoordenadas);
            db.SaveChanges();

            return Ok(tableCoordenadas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TableCoordenadasExists(int id)
        {
            return db.TableCoordenadas.Count(e => e.id == id) > 0;
        }
    }
}