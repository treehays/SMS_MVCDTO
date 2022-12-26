/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Controllers
{
    public class AttendantsController : Controller
    {
        private readonly ApplicationContext _context;

        public AttendantsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Attendants
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Attendants.Include(a => a.User);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Attendants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendants == null)
            {
                return NotFound();
            }

            var attendant = await _context.Attendants
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendant == null)
            {
                return NotFound();
            }

            return View(attendant);
        }





        // GET: Attendants/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password");
            return View();
        }

        // POST: Attendants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,StaffId,Email,PhoneNumber,HomeAddress,ResidentialAddress,IsActive,DateOfBirth,Gender,MaritalStatus,userRole,BankAccountNumber,BankName,GuarantorName,GuarantorPhoneNumber,Id,IsDeleted,Created,Modified")] Attendant attendant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password", attendant.UserId);
            return View(attendant);
        }







        // GET: Attendants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendants == null)
            {
                return NotFound();
            }

            var attendant = await _context.Attendants.FindAsync(id);
            if (attendant == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password", attendant.UserId);
            return View(attendant);
        }

        // POST: Attendants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,StaffId,Email,PhoneNumber,HomeAddress,ResidentialAddress,IsActive,DateOfBirth,Gender,MaritalStatus,userRole,BankAccountNumber,BankName,GuarantorName,GuarantorPhoneNumber,Id,IsDeleted,Created,Modified")] Attendant attendant)
        {
            if (id != attendant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendantExists(attendant.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Password", attendant.UserId);
            return View(attendant);
        }

        // GET: Attendants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendants == null)
            {
                return NotFound();
            }

            var attendant = await _context.Attendants
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendant == null)
            {
                return NotFound();
            }

            return View(attendant);
        }

        // POST: Attendants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendants == null)
            {
                return Problem("Entity set 'ApplicationContext.Attendants'  is null.");
            }
            var attendant = await _context.Attendants.FindAsync(id);
            if (attendant != null)
            {
                _context.Attendants.Remove(attendant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendantExists(int id)
        {
            return _context.Attendants.Any(e => e.Id == id);
        }
    }
}


*/
