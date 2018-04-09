using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace LmycWeb.Controllers
{
    [Authorize]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ApplicationUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Street,City,Province,PostalCode,Country,MobileNumber,Experience,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            var passwordHash = new PasswordHasher<ApplicationUser>();
            if (ModelState.IsValid)
            {
                applicationUser.SecurityStamp = Guid.NewGuid().ToString();
                applicationUser.PasswordHash = passwordHash.HashPassword(applicationUser, "P@$$w0rd");
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Street,City,Province,PostalCode,Country,MobileNumber,Experience,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (!id.Equals(applicationUser.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }
            
        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }

        // GET: Role/Create
        public ActionResult AddRoleToUser(string id)
        {
            List<string> rnames = new List<string>();
            List<IdentityRole> roles = _context.Roles.ToList();

            for (int i = 0; i < roles.Count(); i++)
            {
                rnames.Add(roles[i].Name);
            }

            ViewBag.roles = rnames;

            AddRoleToUser viewModel = new AddRoleToUser()
            {
                UserName = id,
                RoleName = null
            };
            return View(viewModel);
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRoleToUser(AddRoleToUser viewModel)
        {
            var uId = viewModel.UserName;
            var rName = viewModel.RoleName;
            var user =  await _userManager.FindByIdAsync(uId);

            if (ModelState.IsValid)
            {
                await _userManager.AddToRoleAsync(user, rName);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = viewModel.UserName });
            }
            return View("Index");
        }

        public async Task<ActionResult> RemoveRoleFromUser(string id)
        {
            List<string> rnames = new List<string>();
            List<IdentityRole> roles = _context.Roles.ToList();
            var user = await _userManager.FindByIdAsync(id);

            for (int i = 0; i < roles.Count(); i++)
            {
                if (await _userManager.IsInRoleAsync(user, roles[i].Name))
                {
                    rnames.Add(roles[i].Name);
                }
            }

            ViewBag.roles = rnames;

            AddRoleToUser viewModel = new AddRoleToUser()
            {
                UserName = id,
                RoleName = null
            };
            return View(viewModel);
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveRoleFromUser(AddRoleToUser viewModel)
        {
            var uId = viewModel.UserName;
            var rName = viewModel.RoleName; 
            var user = await _userManager.FindByIdAsync(uId);

            if (ModelState.IsValid)
            {
                await _userManager.RemoveFromRoleAsync(user, rName);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = viewModel.UserName });
            }

            return View("Index");
        }

        // GET: Role/Create
        public async Task<ActionResult> ViewRolesAsync(string id)
        {
            List<string> rnames = new List<string>();
            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach(var i in roles)
                {
                    rnames.Add(i);
                }
                ViewBag.roles = rnames;
                ViewBag.id = id;
            }

            AddRoleToUser viewModel = new AddRoleToUser()
            {
                UserName = id,
                RoleName = null
            };

            return View(viewModel);
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ViewRoles(AddRoleToUser viewModel)
        {
            var uId = viewModel.UserName;
            var rName = viewModel.RoleName;
            var user = await _userManager.FindByIdAsync(uId);

            if (ModelState.IsValid)
            {

                await _userManager.AddToRoleAsync(user, rName);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = viewModel.UserName });
            }

            return View("Index");
        }
    }
}
