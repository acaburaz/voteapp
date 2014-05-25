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
using VoteappAPI.Models;
using VoteappAPI.Context;

namespace VoteappAPI.Controllers
{
      [AllowCrossSiteJson]
    public class VoterController : ApiController
    {
        private VoteContext db = new VoteContext();

        // GET api/Voter
        public IQueryable<Voter> GetVoters()
        {
            return db.Voters;
        }

        // GET api/Voter/5
        [ResponseType(typeof(Voter))]
        public IHttpActionResult GetVoter(int id)
        {
            Voter voter = db.Voters.Find(id);
            if (voter == null)
            {
                return NotFound();
            }

            return Ok(voter);
        }

        // PUT api/Voter/5
        public IHttpActionResult PutVoter(int id, Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voter.VoterId)
            {
                return BadRequest();
            }

            db.Entry(voter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoterExists(id))
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

        // POST api/Voter
        [ResponseType(typeof(Voter))]
        public IHttpActionResult PostVoter(Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voters.Add(voter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voter.VoterId }, voter);
        }

        [ResponseType(typeof(Voter))]
        public IHttpActionResult PostVoterToChoice(int choiceId, Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var choice = db.Choices.Find(choiceId);
                db.Entry(choice).State=EntityState.Modified;
                choice.Voters.Add(voter);

            }
            catch
            {
                return null;
            }


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voter.VoterId }, voter);
        }

        // DELETE api/Voter/5
        [ResponseType(typeof(Voter))]
        public IHttpActionResult DeleteVoter(int id)
        {
            Voter voter = db.Voters.Find(id);
            if (voter == null)
            {
                return NotFound();
            }

            db.Voters.Remove(voter);
            db.SaveChanges();

            return Ok(voter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoterExists(int id)
        {
            return db.Voters.Count(e => e.VoterId == id) > 0;
        }
    }
}