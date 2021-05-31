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
    public class EmployeesController : Controller
    {
        private readonly TransportContext _context;

        public EmployeesController(TransportContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,DateOfBirth,Age,MailID,Gender,Bloodgroup,PhoneNumber,Address,BoardingPoint")] Employee employee)
        {
            
                if (employee.BoardingPoint != null)
                {
                    var RoutesAvailability = _context.Routes.Where(m => m.StartingPoint == employee.BoardingPoint || m.Stop1 == employee.BoardingPoint || m.Stop2 == employee.BoardingPoint || m.Stop3 == employee.BoardingPoint || m.EndingPoint==employee.BoardingPoint); //|| m.StopOne == employee.BoardingPoint || m.StopTwo == employee.BoardingPoint || m.StopThree == employee.BoardingPoint);
                    
                    if (RoutesAvailability != null && RoutesAvailability.Count() > 0)
                    {
                        var VehicleAvailability = _context.Vehicles.Where(m => m.AvailableSeats > 0 & m.Location == employee.BoardingPoint);
                        
                        if (VehicleAvailability != null & VehicleAvailability.Count() > 0)
                        {
                            _context.Add(employee);
                           
                            var final_seat = 0;
                            var driver_name = "";
                            var driver_contact_number = "";
                            var vechile_no = "";
                            foreach (var val in VehicleAvailability)
                            {
                                final_seat = val.AvailableSeats;
                                driver_name = val.DriverName;
                                driver_contact_number = val.DriverContactNumber;
                                vechile_no = val.VehicleNumber;
                            }

                            final_seat = final_seat - 1;

                            await _context.Vehicles.Where(m => m.Location == employee.BoardingPoint).ForEachAsync(s => s.AvailableSeats = final_seat); ;
                            await _context.SaveChangesAsync();

                            
                            var a_employee_name = employee.EmployeeName;
                            var a_boarding_location = employee.BoardingPoint;
                            var a_driver_name = driver_name;
                            var a_contact_number = driver_contact_number;
                            var a_vechile_no = vechile_no;
                            var a_allocations = new AllocateVehicle { BoardingPoint = a_boarding_location, DriverContactNumber = a_contact_number, DriverName = a_driver_name, EmployeeName = a_employee_name, VehicleNumber = a_vechile_no };
                            _context.AllocateVehicles.Add(a_allocations);
                            await _context.SaveChangesAsync();

                            return RedirectToAction(nameof(Index));

                        }

                    }
                    else
                    {
                        // Route Availablity
                    }

                }



            
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,DateOfBirth,Age,MailID,Gender,Bloodgroup,PhoneNumber,Address,BoardingPoint")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}