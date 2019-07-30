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
using APIProcat.Entities;

namespace APIProcat.Controllers
{
    public class PersonalDetailsController : ApiController
    {
        private Procat3Entities db = new Procat3Entities();

        // GET: api/PersonalDetails
        public IQueryable<PersonalDetail> GetPersonalDetails()
        {
            return db.PersonalDetails;
        }

        // GET: api/PersonalDetails/5
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult GetPersonalDetail(int id)
        {
            PersonalDetail personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return Ok(personalDetail);
        }

        // PUT: api/PersonalDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonalDetail(int id, PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(personalDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDetailExists(id))
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

        // POST: api/PersonalDetails
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult PostPersonalDetail(PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalDetails.Add(personalDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personalDetail.ID }, personalDetail);
        }

        // DELETE: api/PersonalDetails/5
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult DeletePersonalDetail(int id)
        {
            PersonalDetail personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            db.PersonalDetails.Remove(personalDetail);
            db.SaveChanges();

            return Ok(personalDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalDetailExists(int id)
        {
            return db.PersonalDetails.Count(e => e.ID == id) > 0;
        }
    }
}