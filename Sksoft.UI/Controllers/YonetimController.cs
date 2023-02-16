using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sksoft.Entity;
namespace Sksoft.UI.Controllers
{
    [Authorize]
    public class YonetimController : BaseController
    {


        public IActionResult Index()
        {
            return View();
        }

        [Route("slider-listesi")]
        public IActionResult SliderListesi()
        {
            return View(Slider_List());
        }

        [Route("slider-ekle")]
        public IActionResult SliderEkle()
        {
            return View();
        }
        [Route("slider-ekle")]
        [HttpPost]
        public IActionResult SliderEkle(Slider model)
        {
            bool kontrol = Slider_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("SliderListesi");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }

        [Route("slider-duzenle/{id}")]
        public IActionResult SliderDuzenle(int id)
        {
            return View(Slider_Bul(id));
        }

        [Route("slider-duzenle")]
        [HttpPost]
        public IActionResult SliderDuzenle(Slider model)
        {
            var kontrol = Slider_Duzenle(model);
            if (kontrol == true)
            {
                return RedirectToAction("SliderListesi");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }

        [Route("slider-sil/{id}")]
        public IActionResult SliderSil(int id)
        {
            var kontrol = Slider_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("SliderListesi");
            }
            else
            {
                TempData["Durum"] = "Slider Silinemedi!";
                return RedirectToAction("SliderListesi");
            }
        }

        [Route("blog-list")]
        public IActionResult Bloglar()
        {
            return View(Blog_Listesi());
        }

        [Route("blog-ekle")]
        public IActionResult BlogEkle()
        {
            return View();
        }

        [Route("blog-ekle")]
        [HttpPost]
        public IActionResult BlogEkle(Blog model)
        {
            var kontrol = Blog_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("Bloglar");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }

        [Route("blog-duzenle/{id}")]
        public IActionResult BlogDuzenle(int id)
        {
            return View(Blog_Bul(id));
        }

        [Route("blog-duzenle")]
        [HttpPost]
        public IActionResult BlogDuzenle(Blog model)
        {
            var kontrol = Blog_Duzenle(model);
            if (kontrol == true)
            {
                return RedirectToAction("Bloglar");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }

        [Route("blog-sil/{id}")]
        public IActionResult BlogSil(int id)
        {
            var kontrol = Blog_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("Bloglar");
            }
            else
            {
                TempData["Durum"] = "Veritabansal bir hata oluştu";
                return RedirectToAction("Bloglar");
            }
        }

        [Route("hakkimizda-listesi")]
        public IActionResult HakkimizdaListesi()
        {
            return View(Hakkimizda_Listesi());
        }

        [Route("hakkimizda-duzenle")]
        public IActionResult HakkimizdaDuzenle()
        {
            return View(db.Hakkimizda.FirstOrDefault());
        }

        [Route("hakkimizda-duzenle")]
        [HttpPost]
        public IActionResult HakkimizdaDuzenle(Ayarlar model)
        {
            try
            {
                var bul = db.Ayarlar.FirstOrDefault();
                bul.Hakkimizda = model.Hakkimizda;
                db.SaveChanges();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        [Route("hakkimizda-ekle")]
        public IActionResult HakkimizdaEkle(Hakkimizda model)
        {
            bool kontrol = Hakkimizda_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("HakkimizdaListesi");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }

        [Route("hakkimizda-sil/{id}")]
        public IActionResult HakkimizdaSil(int id)
        {
            var kontrol = Hakkimizda_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("HakkimizdaListesi");
            }
            else
            {
                TempData["Durum"] = "Hakkımızda Silinemedi!";
                return RedirectToAction("HakkimizdaListesi");
            }
        }

        [Route("urun-listesi")]
        public IActionResult UrunListesi()
        {
            return View(Urun_Listesi());
        }

        [Route("urun-ekle")]
        public IActionResult UrunEkle()
        {
            return View();
        }

        [Route("urun-ekle")]
        [HttpPost]
        public IActionResult UrunEkle(Urunlerimiz model)
        {
            bool kontrol = Urun_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("UrunListesi");
            }
            else
            {
                ViewBag.Durum = "Ürün Eklenemedi !";
                return View();
            }
        }

        [Route("urun-duzenle/{id}")]
        public IActionResult UrunDuzenle(int id)
        {
            return View(Urun_Bul(id));
        }

        [Route("urun-duzenle")]
        [HttpPost]
        public IActionResult UrunDuzenle(Urunlerimiz model)
        {
            var kontrol = Urun_Duzenle(model);
            if (kontrol == true)
            {
                return RedirectToAction("UrunListesi");
            }
            else
            {
                ViewBag.Durum = "Ürün Düzenlenemedi";
                return View();
            }
        }

        [Route("urun-sil/{id}")]
        public IActionResult UrunSil(int id)
        {
            var kontrol = Urun_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("UrunListesi");
            }
            else
            {
                TempData["Durum"] = "Ürün Silinemedi";
                return RedirectToAction("UrunListesi");
            }
        }

        [Route("iletisim-talep")]
        public IActionResult Iletisim()
        {
            return View(Iletisim_Listesi());
        }

        [Route("iletisim-detay/{id}")]
        public IActionResult IletisimDetay(int id)
        {
            var bul = db.Iletisim.FirstOrDefault(x => x.ID == id);
            return View(bul);
        }

        [Route("iletisim-cevaplama")]
        public IActionResult IletisimCevaplama()
        {

            Ayarlar();
            return View();
        }

        [Route("mail")]
        public IActionResult Mail()
        {
            return View();
        }

        [Route("ayarlar")]
        public IActionResult Ayarlar()
        {
            return View();
        }

        [Route("site-bilgileri")]
        public IActionResult SiteBilgileri()
        {
            return View(db.Ayarlar.FirstOrDefault());
        }

        [Route("site-bilgileri")]
        [HttpPost]
        public IActionResult SiteBilgileri(Ayarlar Model)
        {
            var bul = db.Ayarlar.FirstOrDefault();
            if (bul != null)
            {
                bul.SiteAdi = Model.SiteAdi;
                bul.Aciklama = Model.Aciklama;
                bul.Adres = Model.Adres;
                bul.Telefon = Model.Telefon;
                bul.Mail = Model.Mail;

                db.SaveChanges();
                return RedirectToAction("SiteBilgileri");
            }
            else
            {
                ViewBag.Durum = "Site bilgileri güncellenirken bir hata oluştu";
                return View();
            }
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();

        }

        [Route("log-out")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");

        }
    }
}