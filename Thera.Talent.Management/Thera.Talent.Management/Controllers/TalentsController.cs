using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Thera.Talent.Management.Infrastructure.Context;

namespace Thera.Talent.Management.Controllers
{
    public class TalentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Talents
        [Authorize(Roles = "Administrators,Secretaries,Readers")]
        public async Task<IHttpActionResult> GetTalents()
        {
            var talents = await db.Talents.OrderBy(t => t.Name).ToListAsync();
            return Ok(new { talents });
        }

        // GET: api/Talents/5
        [Authorize(Roles = "Administrators,Secretaries,Readers")]
        [ResponseType(typeof(Domain.Entities.Talent))]
        public async Task<IHttpActionResult> GetTalent(int id)
        {
            Domain.Entities.Talent talent = await db.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }

            return Ok(new { talent });
        }

        // PUT: api/Talents/5
        [Authorize(Roles = "Administrators,Secretaries")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTalent(int id, Domain.Entities.Talent talent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != talent.Id)
            {
                return BadRequest();
            }

            db.Entry(talent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(true);
        }

        // POST: api/Talents
        [Authorize(Roles = "Administrators,Secretaries")]
        [ResponseType(typeof(Domain.Entities.Talent))]
        public async Task<IHttpActionResult> PostTalent(Domain.Entities.Talent talent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alreadyExist = await db.Talents.AsNoTracking().FirstOrDefaultAsync(t => t.Email == talent.Email);

            if (alreadyExist != null)
            {
                return BadRequest("E-mail já cadastrado!");
            }

            db.Talents.Add(talent);
            await db.SaveChangesAsync();

            return Ok(true);
        }

        // DELETE: api/Talents/5
        [Authorize(Roles = "Administrators")]
        [ResponseType(typeof(Domain.Entities.Talent))]
        public async Task<IHttpActionResult> DeleteTalent(int id)
        {
            Domain.Entities.Talent talent = await db.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }

            db.Talents.Remove(talent);
            await db.SaveChangesAsync();

            return Ok(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TalentExists(int id)
        {
            return db.Talents.Count(e => e.Id == id) > 0;
        }
    }
}