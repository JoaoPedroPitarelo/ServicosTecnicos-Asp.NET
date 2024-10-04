using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicosTecnicos.Models;

namespace ServicosTecnicos.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly Contexto _context;

        public ChamadosController(Contexto context)
        {
            _context = context;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Chamados.Include(c => c.funcionario).Include(c => c.maquina).Include(c => c.tecnico);
            return View(await contexto.ToListAsync());
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.funcionario)
                .Include(c => c.maquina)
                .Include(c => c.tecnico)
                .FirstOrDefaultAsync(m => m.id_chamado == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamados/Create
        public IActionResult Create()
        {
            ViewData["id_funcionario"] = new SelectList(_context.Funcionarios, "id_funcionario", "nome");
            ViewData["patrimonio"] = new SelectList(_context.Maquinas, "patrimonio", "modelo");
            ViewData["id_tecnico"] = new SelectList(_context.Tecnicos, "id_tecnico", "nome");
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_chamado,id_funcionario,patrimonio,id_tecnico,descricao")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_funcionario"] = new SelectList(_context.Funcionarios, "id_funcionario", "nome", chamado.id_funcionario);
            ViewData["patrimonio"] = new SelectList(_context.Maquinas, "patrimonio", "modelo", chamado.patrimonio);
            ViewData["id_tecnico"] = new SelectList(_context.Tecnicos, "id_tecnico", "nome", chamado.id_tecnico);
            return View(chamado);
        }

        // GET: Chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            ViewData["id_funcionario"] = new SelectList(_context.Funcionarios, "id_funcionario", "endereco", chamado.id_funcionario);
            ViewData["patrimonio"] = new SelectList(_context.Maquinas, "patrimonio", "marca", chamado.patrimonio);
            ViewData["id_tecnico"] = new SelectList(_context.Tecnicos, "id_tecnico", "endereco", chamado.id_tecnico);
            return View(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_chamado,id_funcionario,patrimonio,id_tecnico,descricao")] Chamado chamado)
        {
            if (id != chamado.id_chamado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.id_chamado))
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
            ViewData["id_funcionario"] = new SelectList(_context.Funcionarios, "id_funcionario", "endereco", chamado.id_funcionario);
            ViewData["patrimonio"] = new SelectList(_context.Maquinas, "patrimonio", "marca", chamado.patrimonio);
            ViewData["id_tecnico"] = new SelectList(_context.Tecnicos, "id_tecnico", "endereco", chamado.id_tecnico);
            return View(chamado);
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.funcionario)
                .Include(c => c.maquina)
                .Include(c => c.tecnico)
                .FirstOrDefaultAsync(m => m.id_chamado == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado != null)
            {
                _context.Chamados.Remove(chamado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return _context.Chamados.Any(e => e.id_chamado == id);
        }
    }
}
