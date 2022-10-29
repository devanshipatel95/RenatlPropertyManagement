using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class AppartmentsController : Controller
    {
        private readonly FinalProjectContext _context = new FinalProjectContext();

        private readonly ILogger<AppartmentsController> _logger;
        public AppartmentsController(ILogger<AppartmentsController> logger)
        {
            _logger = logger;
        }

        // GET: Appartments
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.Appartments.Include(a => a.Building);
            return View(await finalProjectContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchAppt)
        {
            ViewData["GetApartmentDetails"] = searchAppt;

            var appart = from x in _context.Appartments select x;

            if (!String.IsNullOrEmpty(searchAppt))
            {
                appart = appart.Where(x => x.Status.Contains(searchAppt) || x.RentalPrice.Contains(searchAppt));
            }
            return View(await appart.AsNoTracking().ToListAsync());
        }

        // GET: Appartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appartments == null)
            {
                return NotFound();
            }

            var appartment = await _context.Appartments
                .Include(a => a.Building)
                .FirstOrDefaultAsync(m => m.AppartmentId == id);
            if (appartment == null)
            {
                return NotFound();
            }

            return View(appartment);
        }

        // GET: Appartments/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId");
            return View();
        }

        // POST: Appartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppartmentId,BuildingId,Number,Description,Status,RentalPrice")] Appartment appartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId", appartment.BuildingId);
            return View(appartment);
        }

        // GET: Appartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appartments == null)
            {
                return NotFound();
            }

            var appartment = await _context.Appartments.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId", appartment.BuildingId);
            return View(appartment);
        }

        // POST: Appartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppartmentId,BuildingId,Number,Description,Status,RentalPrice")] Appartment appartment)
        {
            if (id != appartment.AppartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppartmentExists(appartment.AppartmentId))
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
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "BuildingId", "BuildingId", appartment.BuildingId);
            return View(appartment);
        }

        // GET: Appartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appartments == null)
            {
                return NotFound();
            }

            var appartment = await _context.Appartments
                .Include(a => a.Building)
                .FirstOrDefaultAsync(m => m.AppartmentId == id);
            if (appartment == null)
            {
                return NotFound();
            }

            return View(appartment);
        }

        // POST: Appartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appartments == null)
            {
                return Problem("Entity set 'FinalProjectContext.Appartments'  is null.");
            }
            var appartment = await _context.Appartments.FindAsync(id);
            if (appartment != null)
            {
                _context.Appartments.Remove(appartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppartmentExists(int id)
        {
          return _context.Appartments.Any(e => e.AppartmentId == id);
        }
    }
}
