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
    public class EstadoHabitacionsController : Controller
    {
        private readonly PRHoteleroDbContext _context;

        public EstadoHabitacionsController(PRHoteleroDbContext context)
        {
            _context = context;
        }

        // GET: EstadoHabitacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoHabitaciones.ToListAsync());
        }

        // GET: EstadoHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHabitacion = await _context.EstadoHabitaciones
                .FirstOrDefaultAsync(m => m.EstadoHId == id);
            if (estadoHabitacion == null)
            {
                return NotFound();
            }

            return View(estadoHabitacion);
        }

        // GET: EstadoHabitacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoHId,Estado")] EstadoHabitacion estadoHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoHabitacion);
        }

        // GET: EstadoHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHabitacion = await _context.EstadoHabitaciones.FindAsync(id);
            if (estadoHabitacion == null)
            {
                return NotFound();
            }
            return View(estadoHabitacion);
        }

        // POST: EstadoHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoHId,Estado")] EstadoHabitacion estadoHabitacion)
        {
            if (id != estadoHabitacion.EstadoHId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoHabitacionExists(estadoHabitacion.EstadoHId))
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
            return View(estadoHabitacion);
        }

        // GET: EstadoHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHabitacion = await _context.EstadoHabitaciones
                .FirstOrDefaultAsync(m => m.EstadoHId == id);
            if (estadoHabitacion == null)
            {
                return NotFound();
            }

            return View(estadoHabitacion);
        }

        // POST: EstadoHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoHabitacion = await _context.EstadoHabitaciones.FindAsync(id);
            _context.EstadoHabitaciones.Remove(estadoHabitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoHabitacionExists(int id)
        {
            return _context.EstadoHabitaciones.Any(e => e.EstadoHId == id);
        }
    }
}
