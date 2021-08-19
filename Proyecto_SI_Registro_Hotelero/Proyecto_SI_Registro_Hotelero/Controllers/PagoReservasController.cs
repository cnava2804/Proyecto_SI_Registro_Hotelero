using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_SI_Registro_Hotelero.Cammon;
using Proyecto_SI_Registro_Hotelero.Data;
using Proyecto_SI_Registro_Hotelero.Models;

namespace Proyecto_SI_Registro_Hotelero.Controllers
{
    public class PagoReservasController : Controller
    {
        private readonly PRHoteleroDbContext _context;
        private readonly int RecordsPerPage = 10;

        private Pagination<PagoReserva> PaginationPagoReserva;


        public PagoReservasController(PRHoteleroDbContext context)
        {
            _context = context;
        }

        // GET: PagoReservas
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            int totalRecords = 0;

            if (search == null)
            {
                search = "";
                
            }

            totalRecords = await _context.PagoReservas.Include(a => a.ReservaHabitacion).CountAsync(
                    d => d.PReservaCedula.Contains(search));

            //Obtener la pagina de registros(datos)
            var habi = await _context.PagoReservas.Include(a => a.ReservaHabitacion)
                .Where(d => d.PReservaCedula.Contains(search)).ToListAsync();

            var pagoreservaResult = habi.OrderBy(o => o.PReservaCedula)
                .Skip((page - 1) * RecordsPerPage)
                .Take(RecordsPerPage);

            //Obtener el total de paginas
            var totalPage = (int)Math.Ceiling((double)totalRecords / RecordsPerPage);

            //Instanciar la clase de paginacion
            PaginationPagoReserva = new Pagination<PagoReserva>()
            {
                RecordsPerPage = this.RecordsPerPage,
                TotalRecords = totalRecords,
                TotalPage = totalPage,
                CurrentPage = page,
                Search = search,
                Result = pagoreservaResult
            };
            return View(PaginationPagoReserva);


        }

        // GET: PagoReservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoReserva = await _context.PagoReservas
                .Include(p => p.ReservaHabitacion)
                .FirstOrDefaultAsync(m => m.PReservaId == id);
            if (pagoReserva == null)
            {
                return NotFound();
            }

            return View(pagoReserva);
        }

        // GET: PagoReservas/Create
        public IActionResult Create()
        {

        ViewData["ReservaHId"] = new SelectList(_context.ReservaHabitaciones, "ReservaHId", "ReservaNombre");
            return View();
        }

        // POST: PagoReservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PReservaId,PReservaFullName,PReservaCorreo,PReservaTitular,PReservaCedula,PReservaNumeroTarjeta,PReservaFechaVencimiento,PReservaCodigoTarjeta,ReservaHId")] PagoReserva pagoReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagoReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservaHId"] = new SelectList(_context.ReservaHabitaciones, "ReservaHId", "ReservaNombre", pagoReserva.ReservaHId);
            return View();
        }

        // GET: PagoReservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoReserva = await _context.PagoReservas.FindAsync(id);
            if (pagoReserva == null)
            {
                return NotFound();
            }
            ViewData["ReservaHId"] = new SelectList(_context.ReservaHabitaciones, "ReservaHId", "ReservaHId", pagoReserva.ReservaHId);
            return View(pagoReserva);
        }

        // POST: PagoReservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PReservaId,PReservaFullName,PReservaCorreo,PReservaTitular,PReservaCedula,PReservaNumeroTarjeta,PReservaFechaVencimiento,PReservaCodigoTarjeta,ReservaHId")] PagoReserva pagoReserva)
        {
            if (id != pagoReserva.PReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagoReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoReservaExists(pagoReserva.PReservaId))
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
            ViewData["ReservaHId"] = new SelectList(_context.ReservaHabitaciones, "ReservaHId", "ReservaHId", pagoReserva.ReservaHId);
            return View(pagoReserva);
        }

        // GET: PagoReservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagoReserva = await _context.PagoReservas
                .Include(p => p.ReservaHabitacion)
                .FirstOrDefaultAsync(m => m.PReservaId == id);
            if (pagoReserva == null)
            {
                return NotFound();
            }

            return View(pagoReserva);
        }

        // POST: PagoReservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagoReserva = await _context.PagoReservas.FindAsync(id);
            _context.PagoReservas.Remove(pagoReserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoReservaExists(int id)
        {
            return _context.PagoReservas.Any(e => e.PReservaId == id);
        }
    }
}
