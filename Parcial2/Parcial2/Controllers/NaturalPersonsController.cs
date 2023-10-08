using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2.DAL;
using Parcial2.DAL.Entities;

namespace Parcial2.Controllers
{
    public class NaturalPersonsController : Controller
    {
        private readonly DataBaseContext _context;

        public NaturalPersonsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: NaturalPersons
        public async Task<IActionResult> Index()
        {
              return _context.NaturalPersons != null ? 
                          View(await _context.NaturalPersons.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.NaturalPersons'  is null.");
         
            // el metodo ToListAsync sirve para consultar una LISTA
        }

        // GET: NaturalPersons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NaturalPersons == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPersons.FirstOrDefaultAsync(m => m.Id == id);
            // el metodo FirstOrDefaultAsync sirve para consultar un OBJETO

            if (naturalPerson == null)
            {
                return NotFound();
            }

            return View(naturalPerson);
        }

        // GET: NaturalPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaturalPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Email,BirthDate,Age,Name,Id,CreatedDate,ModifiedDate")] NaturalPerson naturalPerson)
        {
            if (ModelState.IsValid)
            {
                naturalPerson.Id = Guid.NewGuid();
               // naturalPerson.Age = CalculateAge(naturalPerson.BirthDate);
               naturalPerson.CreatedDate = DateTime.Now; // automatizo el createdDate
                _context.Add(naturalPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naturalPerson);
        }

        // GET: NaturalPersons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NaturalPersons == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPersons.FindAsync(id); //voy a la bd traigo la natural person
                                                                             //con el id
            
            
            if (naturalPerson == null)
            {
                return NotFound();
            }
            return View(naturalPerson);
        }

        // POST: NaturalPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FullName,Email,BirthDate,Age,Name,Id,CreatedDate,ModifiedDate")] NaturalPerson naturalPerson)
        {
            if (id != naturalPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naturalPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaturalPersonExists(naturalPerson.Id))
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
            return View(naturalPerson);
        }

        // GET: NaturalPersons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NaturalPersons == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPersons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            return View(naturalPerson);
        }

        // POST: NaturalPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NaturalPersons == null)
            {
                return Problem("Entity set 'DataBaseContext.NaturalPersons'  is null.");
            }
            var naturalPerson = await _context.NaturalPersons.FindAsync(id);
            if (naturalPerson != null)
            {
                _context.NaturalPersons.Remove(naturalPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaturalPersonExists(Guid id)
        {
          return (_context.NaturalPersons?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        /*private int AgePerson() 
        { 
            DateTime currentDate = DateTime.Now;
            DateTime bornDate = new DateTime(bornYear, 01, 01);

            int age = currentDate.Year - bornDate.Year; 

            return age;
        }
        */
    }
}
