using System.ComponentModel.DataAnnotations;

namespace Drone.WebApp.Models
{
    public class TeklifModel
    {
        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        public string Name { get; set; }= " ";

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }= " ";

        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public int Urun { get; set; }= 1;

        

        public string Telno { get; set; }= " ";
        
        public string Subject { get; set; }= " ";

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        public string Message { get; set; }= " ";
    }
}
