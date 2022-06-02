using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prospectus.Data;
using Prospectus.Models;

namespace Prospectus.Controllers
{
    [Authorize]
    public class IndicadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IndicadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Indicadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Indicadores.ToListAsync());
        }

        // GET: Indicadores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicador = await _context.Indicadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indicador == null)
            {
                return NotFound();
            }

            return View(indicador);
        }

        // GET: Indicadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Indicadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                indicador.Id = Guid.NewGuid();
                _context.Add(indicador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indicador);
        }

        // GET: Indicadores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicador = await _context.Indicadores.FindAsync(id);
            if (indicador == null)
            {
                return NotFound();
            }
            return View(indicador);
        }

        // POST: Indicadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Indicador indicador)
        {
            if (id != indicador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicadorExists(indicador.Id))
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
            return View(indicador);
        }

        // GET: Indicadores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicador = await _context.Indicadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indicador == null)
            {
                return NotFound();
            }

            return View(indicador);
        }

        // POST: Indicadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var indicador = await _context.Indicadores.FindAsync(id);
            _context.Indicadores.Remove(indicador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicadorExists(Guid id)
        {
            return _context.Indicadores.Any(e => e.Id == id);
        }
    }
}
