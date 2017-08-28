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
using DiyetisyenimBot.EF;
using DiyetisyenimBot.Models;

namespace DiyetisyenimBot.Controllers
{
    public class AnswersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Answers
        public IQueryable<Answers> GetAnswers()
        {
            return db.Answers;
        }

        // GET: api/Answers/5
        [ResponseType(typeof(Answers))]
        public IHttpActionResult GetAnswers(int id)
        {
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return NotFound();
            }

            return Ok(answers);
        }

        // PUT: api/Answers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnswers(int id, Answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answers.ID)
            {
                return BadRequest();
            }

            db.Entry(answers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswersExists(id))
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

        // POST: api/Answers
        [ResponseType(typeof(Answers))]
        public IHttpActionResult PostAnswers(Answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Answers.Add(answers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = answers.ID }, answers);
        }

        // DELETE: api/Answers/5
        [ResponseType(typeof(Answers))]
        public IHttpActionResult DeleteAnswers(int id)
        {
            Answers answers = db.Answers.Find(id);
            if (answers == null)
            {
                return NotFound();
            }

            db.Answers.Remove(answers);
            db.SaveChanges();

            return Ok(answers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswersExists(int id)
        {
            return db.Answers.Count(e => e.ID == id) > 0;
        }
    }
}