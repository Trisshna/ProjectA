using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagementSystemApplication.Models;

namespace TransportManagementSystemApplication.Controllers
{
    public class AllocateVehiclesController : Controller
    {
        private readonly TransportContext _context;

        public AllocateVehiclesController(TransportContext context)
        {
            _context = context;
        }

        // GET: AllocateVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllocateVehicles.ToListAsync());
        }

        // GET: AllocateVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateVehicle = await _context.AllocateVehicles
                .FirstOrDefaultAsync(m => m.AllocateVehicleID == id);
            if (allocateVehicle == null)
            {
                return NotFound();
            }

            return View(allocateVehicle);
        }

        // GET: AllocateVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllocateVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocateVehicleID,EmployeeName,BoardingPoint,DriverName,DriverContactNumber,VehicleNumber")] AllocateVehicle allocateVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocateVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocateVehicle);
        }

        // GET: AllocateVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateVehicle = await _context.AllocateVehicles.FindAsync(id);
            if (allocateVehicle == null)
            {
                return NotFound();
            }
            return View(allocateVehicle);
        }

        // POST: AllocateVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocateVehicleID,EmployeeName,BoardingPoint,DriverName,DriverContactNumber,VehicleNumber")] AllocateVehicle allocateVehicle)
        {
            if (id != allocateVehicle.AllocateVehicleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocateVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateVehicleExists(allocateVehicle.AllocateVehicleID))
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
            return View(allocateVehicle);
        }

        // GET: AllocateVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateVehicle = await _context.AllocateVehicles
                .FirstOrDefaultAsync(m => m.AllocateVehicleID == id);
            if (allocateVehicle == null)
            {
                return NotFound();
            }

            return View(allocateVehicle);
        }

        // POST: AllocateVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocateVehicle = await _context.AllocateVehicles.FindAsync(id);
            _context.AllocateVehicles.Remove(allocateVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateVehicleExists(int id)
        {
            return _context.AllocateVehicles.Any(e => e.AllocateVehicleID == id);
        }
    }
}
