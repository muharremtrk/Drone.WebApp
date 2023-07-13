using Microsoft.AspNetCore.Mvc;
using Drone.WebApp.Models;
using System.Net;
using System.Net.Mail;

namespace Drone.WebApp.Controllers
{
    public class TeklifController : Controller
    {
        private readonly ZihalarContext _context;

        public TeklifController(ZihalarContext context)
        {
            _context = context;
        }
        public IActionResult Index(int drone_id)
        {
             var ziha = _context.Zihalar.FirstOrDefault(z => z.Drone_Id == drone_id);
             if (ziha == null)
    {
        return View();
    }

            var model = new TeklifModel
            {
                // Verileri model örneğine ekle
                Urun = ziha.Drone_Id,
            };
            return View();
        }
        
        

        [HttpPost]
        public IActionResult Submit(TeklifModel model)
        {
            if (ModelState.IsValid)
            {
                // Verileri işleme kodlarını buraya ekleyin
                // Örneğin, veritabanına kaydetme

                // E-posta gönderme işlemi
                MailMessage message = new MailMessage();
                message.From = new MailAddress("ziraidrone@hotmail.com"); // Gönderen e-posta adresi
                message.To.Add("ziraidrone@hotmail.com"); // Alıcı e-posta adresi
                message.Subject = "Teklif Talebi"; // E-posta konusu
                message.Body = $"Ad Soyad: {model.Name}\nE-posta: {model.Email}\nTelefon:{model.Telno}Konu: {model.Subject}\nMesaj: {model.Message}\nÜrün: {model.Urun}"; // E-posta içeriği

                SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587); // Hotmail SMTP sunucusu ve port numarası
                smtpClient.Credentials = new NetworkCredential("ziraidrone@hotmail.com", "Ziraat123."); // Hotmail kullanıcı adı ve şifre
                smtpClient.EnableSsl = true; // SSL kullanımı

                try
                {
                    smtpClient.Send(message); // E-postayı gönder
                }
                catch (Exception ex)
                {
                    // E-posta gönderimi sırasında bir hata oluştu
                    // Hata işleme kodlarını burada ekleyebilirsiniz
                    // Örneğin, hatayı loglama veya kullanıcıya hata mesajı gösterme
                }

                // İşlemler tamamlandıktan sonra teşekkür sayfasına yönlendirin
                return RedirectToAction("ThankYou");
            }

            // Doğrulama hataları varsa teklif sayfasını tekrar gösterin
            return View("Index", model);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
