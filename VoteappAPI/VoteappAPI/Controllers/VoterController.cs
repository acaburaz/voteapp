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
<<<<<<< HEAD
=======
      [AllowCrossSiteJson]
>>>>>>> e8c208570015f68785a50e040a3c1677b249248f
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

<<<<<<< HEAD
=======
        //VoterChoiceView
        [ResponseType(typeof(VoterChoiceView))]
        public IHttpActionResult PostVoter(VoterChoiceView device)
        {
            if (!ModelState.IsValid && device == null)
            {
                return BadRequest(ModelState);
            }

            db.Voters.Add(device.Voter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = device.Voter.VoterId }, device.Voter);
        }
>>>>>>> e8c208570015f68785a50e040a3c1677b249248f
        // POST api/Voter
        [ResponseType(typeof(Voter))]
        public IHttpActionResult PostVoter(Voter voter)
        {
<<<<<<< HEAD
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

=======
            if (!ModelState.IsValid && voter == null)
            {
                return BadRequest(ModelState);
            }
            voter.Timestamp = DateTime.Today;
>>>>>>> e8c208570015f68785a50e040a3c1677b249248f
            db.Voters.Add(voter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voter.VoterId }, voter);
        }

<<<<<<< HEAD
=======
        [ResponseType(typeof(Voter))]
        public IHttpActionResult PostVoter( Voter voter,int choiceId)
        {
            if (!ModelState.IsValid && voter == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
               var ipAdress = ((System.Web.HttpContextWrapper) this.Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                voter.IpAdress = ipAdress;

                var choice = db.Choices.Find(choiceId);
                db.Entry(choice).State=EntityState.Modified;
                voter.Timestamp = DateTime.Today;
                choice.Voters.Add(voter);

            }
            catch
            {
                return null;
            }


            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voter.VoterId }, voter);
        }

>>>>>>> e8c208570015f68785a50e040a3c1677b249248f
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