using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodTrip.Data;
using GoodTrip.Models;

namespace GoodTrip.Controllers
{
    public class PassagemsController : Controller
    {
        private readonly Context _context;

        public PassagemsController(Context context)
        {
            _context = context;
        }

        // GET: Passagems
        public async Task<IActionResult> Index()
        {
            var context = _context.passagens.Include(p => p.Cliente);
            return View(await context.ToListAsync());
        }

        // GET: Passagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.passagens
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id_pass == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagems/Create
        public IActionResult Create()
        {
            ViewData["Id_cliente_pass"] = new SelectList(_context.clientes, "Id_cliente", "Nome");
            return View();
        }

        // POST: Passagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_pass,preco,Embarque,Desembarque,Id_cliente_pass")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_cliente_pass"] = new SelectList(_context.clientes, "Id_cliente", "Nome", passagem.Id_cliente_pass);
            return View(passagem);
        }

        // GET: Passagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.passagens.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            ViewData["Id_cliente_pass"] = new SelectList(_context.clientes, "Id_cliente", "Nome", passagem.Id_cliente_pass);
            return View(passagem);
        }

        // POST: Passagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_pass,preco,Embarque,Desembarque,Id_cliente_pass")] Passagem passagem)
        {
            if (id != passagem.Id_pass)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.Id_pass))
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
            ViewData["Id_cliente_pass"] = new SelectList(_context.clientes, "Id_cliente", "Nome", passagem.Id_cliente_pass);
            return View(passagem);
        }

        // GET: Passagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.passagens
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id_pass == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagem = await _context.passagens.FindAsync(id);
            _context.passagens.Remove(passagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
            return _context.passagens.Any(e => e.Id_pass == id);
        }
    }
}
