using Microsoft.AspNetCore.Mvc;
using Drone.WebApp.Models;
using System.Linq;

namespace Drone.WebApp.Controllers
{
    public class ZihalarController : Controller
    {
        private readonly ZihalarContext _context;

        public ZihalarController(ZihalarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var zihalar = _context.Zihalar.ToList();
            return View(zihalar);
        }
        public IActionResult Get(int drone_id)
{
    // drone_id'ye göre ilgili veriyi veritabanından çekin
    Ziha ziha = _context.Zihalar.FirstOrDefault(z => z.Drone_Id == drone_id);

    if (ziha == null)
    {
        // Verilen drone_id'ye sahip ziha bulunamadı, uygun bir hata mesajı döndürün veya yönlendirme yapın
        return NotFound();
    }

    return View(new List<Ziha> { ziha });
}

        
    }
}
