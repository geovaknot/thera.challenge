using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Thera.Talent.Management.Authorization;
using Thera.Talent.Management.Domain.Entities;
using Thera.Talent.Management.Infrastructure.Context;
using Thera.Talent.Management.Models;

namespace Thera.Talent.Management.Controllers
{

    public class UsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: api/Users/Login
        [AllowAnonymous]
        [Route("api/Users/Login")]
        [HttpPost]
        [ResponseType(typeof(object))]
        public async Task<IHttpActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == request.Login && u.Password == request.Password);

            if (user == null)
            {
                return BadRequest("Login ou senha inválidos!");
            }

            return Ok(TokenService.GetToken(user));
        }

        // GET: api/Users
        [Authorize(Roles = "Administrators,Secretaries")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await db.Users.OrderBy(u => u.Name).ToListAsync();
            return Ok(new { users });
        }

        // GET: api/Users/5
        [Authorize(Roles = "Administrators,Secretaries")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new { user });
        }

        // PUT: api/Users/5
        [Authorize(Roles = "Administrators,Secretaries")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            var oldUser = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            if (oldUser.Profile == Profile.Administrators)
            {
                return Unauthorized();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [Authorize(Roles = "Administrators,Secretaries")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = User.Identity as ClaimsIdentity;
            var profile = identity.Claims.ToList().Find(x => x.Type == ClaimTypes.Role).Value;

            if (profile != "Administrators" && user.Profile == Profile.Administrators)
            {
                return Unauthorized();
            }

            var alreadyExist = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email);

            if (alreadyExist != null)
            {
                return BadRequest("E-mail já cadastrado!");
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return Ok(true);
        }

        // DELETE: api/Users/5
        [Authorize(Roles = "Administrators")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (user.Profile == Profile.Administrators)
            {
                return Unauthorized();
            }

            db.Users.Remove(user);
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

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }

    }
}