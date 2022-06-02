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
    public class ProspectEnderecosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProspectEnderecosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProspectEndereco
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enderecos.Include(e => e.Prospect);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProspectEndereco/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .Include(e => e.Prospect)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: ProspectEndereco/Create
        public IActionResult Create()
        {
            ViewData["ProspectId"] = new SelectList(_context.Prospects, "Id", "Nome");
            return View();
        }

        // POST: ProspectEndereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                endereco.Id = Guid.NewGuid();
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProspectId"] = new SelectList(_context.Prospects, "Id", "Nome", endereco.ProspectId);
            return View(endereco);
        }

        // GET: ProspectEndereco/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.Include(e => e.Prospect).Where(e => e.Id == id).FirstAsync(); // .FindAsync(id);
            //var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }
            //ViewData["ProspectId"] = new SelectList(_context.Prospects, "Id", "Nome", endereco.ProspectId);
            
            return View(endereco);
        }

        // POST: ProspectEndereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update<Endereco>(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //Talvez seja necessario passar Edit para o nameof abaixo
                return RedirectToAction(nameof(Edit));
            }
            //ViewData["ProspectId"] = new SelectList(_context.Prospects, "Id", "Nome", endereco.ProspectId);
            return View(endereco);
        }

        // GET: ProspectEndereco/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .Include(e => e.Prospect)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
            //return View(endereco);
        }

        // POST: ProspectEndereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(Guid id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
