using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPDatabase.Contexts;
using ASPDatabase.Models;
namespace ASPDatabase.controllers
{
    public class Worker : Controller

    {
        private readonly WorkerContext _context;
        public Worker(WorkerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Workers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WorkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kWorkerModel == null)
            {
                return NotFound();
            }

            return View(WorkerModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Messages")] WorkerModel WorkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(WorkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(WorkerModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WorkerModel = await _context.Workers.FindAsync(id);
            if (WorkerModel == null)
            {
                return NotFound();
            }
            return View(WorkerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Messages")] WorkerModel WorkerModel)
        {
            if (id != WorkerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(WorkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerModelExists(WorkerModel.Id))
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
            return View(WorkerModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WorkerModel = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (WorkerModel == null)
            {
                return NotFound();
            }

            return View(WorkerModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var WorkerModel = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(WorkerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerModelExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}
