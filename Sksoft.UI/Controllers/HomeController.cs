using Microsoft.AspNetCore.Mvc;
using Sksoft.DataAccess;
using Sksoft.Entity;

namespace Sksoft.UI.Controllers
{
    public class HomeController : Controller
    {
        public BaseController bs = new BaseController();
        public SksContext db;
        public HomeController()
        {
            db = new SksContext();
        }

        public IActionResult Index()
        {
            Ayarlar();
            return View();
        }

        public void Ayarlar()
        {
            var ayarbul = db.Ayarlar.FirstOrDefault();
            ViewBag.SiteAdi = ayarbul.SiteAdi;
            ViewBag.Telefon = ayarbul.Telefon;
            ViewBag.Mail = ayarbul.Mail;
            ViewBag.Adres = ayarbul.Adres;
            ViewBag.SiteAciklamasi = ayarbul.Aciklama;
            ViewBag.SliderListesi = db.Slider.ToList();
            ViewBag.Hakkimizda = ayarbul.Hakkimizda;
            ViewBag.Bloglar = db.Blog.OrderByDescending(x => x.ID).Take(3).ToList();
        }

        [Route("gizlilik")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("blog-detay/{id}")]
        public IActionResult BlogDetay(int id)
        {
            Ayarlar();
            var bul = bs.Blog_Bul(id);
            db.SaveChanges();
            return View(bul);
        }
        [Route("bloglar")]
        public IActionResult Bloglar()
        {
            Ayarlar();
            return View(bs.Blog_Listesi());
        }

        [Route("sliderler")]
        public IActionResult SliderListesi()
        {
            Ayarlar();
            return View(bs.Slider_List());
        }

        [Route("hakkimizda")]
        public IActionResult Hakkimizda()
        {
            Ayarlar();
            var bul = db.Hakkimizda.FirstOrDefault();
            var hak = new Hakkimizda() 
            { 
              Baslik = bul.Baslik,
              Icerik = bul.Icerik,
              Resim = bul.Resim,
            };
            return View(hak);
        }

        [Route("urunlerimiz")]
        public IActionResult Urunlerimiz()
        {
            Ayarlar();
            return View(bs.Urun_Listesi());
        }
        [Route("urun-detay/{id}")]
        public IActionResult UrunDetay(int id)
        {
            Ayarlar();
            var bul = bs.Urun_Bul(id);
            return View(bul);
        }

        [Route("iletisim")]
        public IActionResult Iletisim()
        {
            Ayarlar();
            return View();
        }

        [Route("iletisim")]
        [HttpPost]

        public IActionResult Iletisim(Iletisim model)
        {
            Ayarlar();
            bool eklendimi = bs.Iletisim_Ekle(model);
            if (eklendimi == true)
            {
                TempData["Mesaj"] = "İletişim talebiniz alınmıştır.En kısa zamanda tarafımızca dönüş sağlanacaktır.";
                return RedirectToAction("Iletisim", "Home");
            }
            else
            {
                ViewBag.Durum = "Bir sorun oluştu";
                return View();
            }
        }
        [Route("mailler")]
        public IActionResult Mail()
        {
            return View();
        }

    }
}
