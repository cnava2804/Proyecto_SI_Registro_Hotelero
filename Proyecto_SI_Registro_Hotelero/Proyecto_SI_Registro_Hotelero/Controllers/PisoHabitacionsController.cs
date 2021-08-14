using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_SI_Registro_Hotelero.Data;
using Proyecto_SI_Registro_Hotelero.Models;

namespace Proyecto_SI_Registro_Hotelero.Controllers
{
    public class PisoHabitacionsController : Controller
    {
        private readonly PRHoteleroDbContext _context;

        public PisoHabitacionsController(PRHoteleroDbContext context)
        {
            _context = context;
        }

        // GET: PisoHabitacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.PisoHabitaciones.ToListAsync());
        }

        // GET: PisoHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pisoHabitacion = await _context.PisoHabitaciones
                .FirstOrDefaultAsync(m => m.PisoHId == id);
            if (pisoHabitacion == null)
            {
                return NotFound();
            }

            return View(pisoHabitacion);
        }

        // GET: PisoHabitacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PisoHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PisoHId,Piso")] PisoHabitacion pisoHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pisoHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pisoHabitacion);
        }

        // GET: PisoHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pisoHabitacion = await _context.PisoHabitaciones.FindAsync(id);
            if (pisoHabitacion == null)
            {
                return NotFound();
            }
            return View(pisoHabitacion);
        }

        // POST: PisoHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PisoHId,Piso")] PisoHabitacion pisoHabitacion)
        {
            if (id != pisoHabitacion.PisoHId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pisoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PisoHabitacionExists(pisoHabitacion.PisoHId))
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
            return View(pisoHabitacion);
        }

        // GET: PisoHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pisoHabitacion = await _context.PisoHabitaciones
                .FirstOrDefaultAsync(m => m.PisoHId == id);
            if (pisoHabitacion == null)
            {
                return NotFound();
            }

            return View(pisoHabitacion);
        }

        // POST: PisoHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pisoHabitacion = await _context.PisoHabitaciones.FindAsync(id);
            _context.PisoHabitaciones.Remove(pisoHabitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PisoHabitacionExists(int id)
        {
            return _context.PisoHabitaciones.Any(e => e.PisoHId == id);
        }
    }
}
