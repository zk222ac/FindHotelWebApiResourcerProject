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
using FindHotelWebApiResourcerProject;
using FindHotelWebApiResourcerProject.EFClasses;

namespace FindHotelWebApiResourcerProject.Controllers
{
    public class VGuestListsController : ApiController
    {
        private ViewGuestListContext db = new ViewGuestListContext();

        // GET: api/VGuestLists
        public IQueryable<VGuestList> GetVGuestLists()
        {
            return db.VGuestLists;
        }

        // GET: api/VGuestLists/5
        [ResponseType(typeof(VGuestList))]
        public async Task<IHttpActionResult> GetVGuestList(string id)
        {
            VGuestList vGuestList = await db.VGuestLists.FindAsync(id);
            if (vGuestList == null)
            {
                return NotFound();
            }

            return Ok(vGuestList);
        }

        // PUT: api/VGuestLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVGuestList(string id, VGuestList vGuestList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vGuestList.HotelName)
            {
                return BadRequest();
            }

            db.Entry(vGuestList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VGuestListExists(id))
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

        // POST: api/VGuestLists
        [ResponseType(typeof(VGuestList))]
        public async Task<IHttpActionResult> PostVGuestList(VGuestList vGuestList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VGuestLists.Add(vGuestList);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VGuestListExists(vGuestList.HotelName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vGuestList.HotelName }, vGuestList);
        }

        // DELETE: api/VGuestLists/5
        [ResponseType(typeof(VGuestList))]
        public async Task<IHttpActionResult> DeleteVGuestList(string id)
        {
            VGuestList vGuestList = await db.VGuestLists.FindAsync(id);
            if (vGuestList == null)
            {
                return NotFound();
            }

            db.VGuestLists.Remove(vGuestList);
            await db.SaveChangesAsync();

            return Ok(vGuestList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VGuestListExists(string id)
        {
            return db.VGuestLists.Count(e => e.HotelName == id) > 0;
        }
    }
}