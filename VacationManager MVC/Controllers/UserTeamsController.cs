using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacation_Manager.VacationManager;

namespace VacationManager_MVC.Controllers
{
    public class UserTeamsController : Controller
    {
        private readonly VacationManagerContext _context;

        public UserTeamsController(VacationManagerContext context)
        {
            _context = context;
        }

        // GET: UserTeams
        public async Task<IActionResult> Index()
        {
            var vacationManagerContext = _context.UserTeams.Include(u => u.Team).Include(u => u.User);
            return View(await vacationManagerContext.ToListAsync());
        }

        // GET: UserTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserTeams == null)
            {
                return NotFound();
            }

            var userTeam = await _context.UserTeams
                .Include(u => u.Team)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.LeaderId == id);
            if (userTeam == null)
            {
                return NotFound();
            }

            return View(userTeam);
        }

        // GET: UserTeams/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaderId,UserId,TeamId")] UserTeam userTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", userTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTeam.UserId);
            return View(userTeam);
        }

        // GET: UserTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTeams == null)
            {
                return NotFound();
            }

            var userTeam = await _context.UserTeams.FindAsync(id);
            if (userTeam == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", userTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTeam.UserId);
            return View(userTeam);
        }

        // POST: UserTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaderId,UserId,TeamId")] UserTeam userTeam)
        {
            if (id != userTeam.LeaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTeamExists(userTeam.LeaderId))
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
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", userTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userTeam.UserId);
            return View(userTeam);
        }

        // GET: UserTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTeams == null)
            {
                return NotFound();
            }

            var userTeam = await _context.UserTeams
                .Include(u => u.Team)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.LeaderId == id);
            if (userTeam == null)
            {
                return NotFound();
            }

            return View(userTeam);
        }

        // POST: UserTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTeams == null)
            {
                return Problem("Entity set 'VacationManagerContext.UserTeams'  is null.");
            }
            var userTeam = await _context.UserTeams.FindAsync(id);
            if (userTeam != null)
            {
                _context.UserTeams.Remove(userTeam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTeamExists(int id)
        {
          return _context.UserTeams.Any(e => e.LeaderId == id);
        }
    }
}
