using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FindHotelWebApiResourcerProject.EFClasses;

namespace FindHotelWebApiResourcerProject.Controllers
{
    public class BookingInfoesController : ApiController
    {
        private VBookingInfoContext db = new VBookingInfoContext();

        // GET: api/BookingInfoes
        public IQueryable<BookingInfo> GetBookingInfoes()
        {
            return db.BookingInfoes;
        }

        // GET: api/BookingInfoes/5
        [ResponseType(typeof(BookingInfo))]
        public async Task<IHttpActionResult> GetBookingInfo(int id)
        {
            BookingInfo bookingInfo = await db.BookingInfoes.FindAsync(id);
            if (bookingInfo == null)
            {
                return NotFound();
            }

            return Ok(bookingInfo);
        }

        // PUT: api/BookingInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingInfo(int id, BookingInfo bookingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingInfo.BookingId)
            {
                return BadRequest();
            }

            db.Entry(bookingInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingInfoExists(id))
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

        // POST: api/BookingInfoes
        [ResponseType(typeof(BookingInfo))]
        public async Task<IHttpActionResult> PostBookingInfo(BookingInfo bookingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookingInfoes.Add(bookingInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingInfoExists(bookingInfo.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookingInfo.BookingId }, bookingInfo);
        }

        // DELETE: api/BookingInfoes/5
        [ResponseType(typeof(BookingInfo))]
        public async Task<IHttpActionResult> DeleteBookingInfo(int id)
        {
            BookingInfo bookingInfo = await db.BookingInfoes.FindAsync(id);
            if (bookingInfo == null)
            {
                return NotFound();
            }

            db.BookingInfoes.Remove(bookingInfo);
            await db.SaveChangesAsync();

            return Ok(bookingInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingInfoExists(int id)
        {
            return db.BookingInfoes.Count(e => e.BookingId == id) > 0;
        }
    }
}