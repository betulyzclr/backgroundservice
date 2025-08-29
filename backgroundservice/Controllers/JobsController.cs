using backgroundservice.Data;
using backgroundservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class JobsController : Controller
{
    private readonly ApplicationDbContext _context;

    public JobsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Jobs/Create
    public IActionResult Create()
    {
        // Views/Home/Create.cshtml yolunu kullandığını varsayıyoruz.
        return View("~/Views/Home/Create.cshtml");
    }

    // POST: Jobs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(JobViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            viewModel.LastCreatedDate = DateTime.Now;
            viewModel.LastUpdatedDate = DateTime.Now;

            _context.Jobs.Add(viewModel);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        return View("~/Views/Home/Create.cshtml", viewModel);
    }

    // GET: Jobs/Details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var job = await _context.Jobs.FirstOrDefaultAsync(m => m.ID == id);

        if (job == null)
        {
            return NotFound();
        }

        return View(job);
    }

    // Silme onayı için sayfayı gösterir.
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var job = await _context.Jobs.FirstOrDefaultAsync(m => m.ID == id);
        if (job == null)
        {
            return NotFound();
        }

        return View(job);
    }

    // POST: Jobs/Delete/{id}
    // isDeleted kolonunu true yapar.
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job != null)
        {
            job.IsDeleted = true; // Kaydı silinmiş olarak işaretle
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "Home");
    }


    // Belirtilen ID'deki Job verilerini düzenleme sayfasında göstermek için.
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var job = await _context.Jobs.FindAsync(id);
        if (job == null)
        {
            return NotFound();
        }
        return View(job);
    }

    // POST: Jobs/Edit/{id}
    // Formdan gelen güncellenmiş verileri veritabanına kaydetmek için.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, JobViewModel viewModel)
    {
        if (id != viewModel.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                viewModel.LastUpdatedDate = DateTime.Now;
                _context.Update(viewModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(viewModel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        return View(viewModel);
    }

    private bool JobExists(int id)
    {
        return _context.Jobs.Any(e => e.ID == id);
    }
}