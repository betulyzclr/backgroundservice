using System.Diagnostics;
using backgroundservice.Models;
using Microsoft.AspNetCore.Mvc;
using backgroundservice.Data; // DbContext'i kullanmak için gerekli
using Microsoft.EntityFrameworkCore; // ToListAsync() için gerekli
using System.Threading.Tasks; // Asenkron işlemler için gerekli

namespace backgroundservice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // DbContext nesnesini tanımladık

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Constructor'da DbContext'i alıyoruz
        }

        // Anasayfayı görüntüler ve veritabanındaki tüm Job'ları listeler.
        public async Task<IActionResult> Index()
        {
            // isDeleted kolonu false olan kayıtları listeler.
            var jobs = await _context.Jobs.Where(j => !j.IsDeleted).ToListAsync();
            return View(jobs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
