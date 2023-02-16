using Microsoft.AspNetCore.Mvc;
using Sksoft.DataAccess;
using Sksoft.Entity;

namespace Sksoft.UI.Controllers
{
    public class BaseController : Controller
    {
        public SksContext db;
        public BaseController()
        {
            db = new SksContext();
        }

        public void Ayarlar()
        {
            var ayarbul = db.Ayarlar.FirstOrDefault();
            ViewBag.SiteAdi = ayarbul.SiteAdi;
            ViewBag.Telefon = ayarbul.Telefon;
            ViewBag.Mail = ayarbul.Mail;
            ViewBag.Adres = ayarbul.Adres;
            ViewBag.SliderListesi = db.Slider.ToList();
            ViewBag.Hakkimizda = ayarbul.Hakkimizda;
            ViewBag.Bloglar = db.Blog.OrderByDescending(x => x.ID).Take(3).ToList();
        }

        public List<Slider> Slider_List()
        {
            return db.Slider.ToList();
        }

        public bool Slider_Ekle(Slider model)
        {
            try
            {
                db.Slider.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Slider Slider_Bul(int id)
        {
            return db.Slider.FirstOrDefault(x => x.ID == id);
        }

        public bool Slider_Duzenle(Slider model)
        {
            try
            {
                var bul = Slider_Bul(model.ID);
                if (model.Icerik != null)
                {
                    bul.Icerik = model.Icerik;
                }

                if (model.Baslik != null)
                {
                    bul.Baslik = model.Baslik;
                }

                if (model.Resim != null)
                {
                    bul.Resim = model.Resim;
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Slider_Sil(int id)
        {
            try
            {
                var bul = Slider_Bul(id);
                db.Slider.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Blog Blog_Bul(int id)
        {
            return db.Blog.FirstOrDefault(x => x.ID == id);
        }

        public List<Blog> Blog_Listesi()
        {
            return db.Blog.ToList();
        }

        public bool Blog_Ekle(Blog model)
        {
            try
            {
                model.Tarih = DateTime.Now;
                db.Blog.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Blog_Duzenle(Blog model)
        {
            try
            {
                var bul = Blog_Bul(model.ID);
                bul.Baslik = model.Baslik;
                bul.Icerik = model.Icerik;
                bul.Resim = model.Resim;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Blog_Sil(int id)
        {
            try
            {
                var bul = Blog_Bul(id);
                db.Blog.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Hakkimizda> Hakkimizda_Listesi()
        {
            return db.Hakkimizda.ToList();
        }
        public bool Hakkimizda_Ekle(Hakkimizda model)
        {
            try
            {
                db.Hakkimizda.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Hakkimizda Hakkimizda_Bul(int id)
        {
            return db.Hakkimizda.FirstOrDefault(x => x.ID == id);
        }

        public bool Hakkimizda_Sil(int id)
        {
            try
            {
                var bul = Hakkimizda_Bul(id);
                db.Hakkimizda.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Hakkimizda_Duzenle(Hakkimizda model)
        {
            try
            {
                var bul = Hakkimizda_Bul(model.ID);
                if (model.Icerik != null)
                {
                    bul.Icerik = model.Icerik;
                }

                if (model.Baslik != null)
                {
                    bul.Baslik = model.Baslik;
                }

                if (model.Resim != null)
                {
                    bul.Resim = model.Resim;
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Urunlerimiz> Urun_Listesi()
        {
            return db.Urunlerimiz.ToList();
        }
        public bool Urun_Ekle(Urunlerimiz model)
        {
            try
            {
                db.Urunlerimiz.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Urunlerimiz Urun_Bul(int id)
        {
            return db.Urunlerimiz.FirstOrDefault(x => x.ID == id);
        }
        public bool Urun_Sil(int id)
        {
            try
            {
                var bul = Urun_Bul(id);
                db.Urunlerimiz.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool Urun_Duzenle(Urunlerimiz model)
        {
            try
            {
                var bul = Urun_Bul(model.ID);
                if (model.Icerik != null)
                {
                    bul.Icerik = model.Icerik;
                }
                if (model.Baslik != null)
                {
                    bul.Baslik = model.Baslik;
                }
                if (model.Resim != null)
                {
                    bul.Baslik = model.Resim;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Iletisim> Iletisim_Listesi()
        {
            return db.Iletisim.ToList();
        }
        public Iletisim Iletisim_Bul(int id)
        {
            return db.Iletisim.FirstOrDefault(x => x.ID == id);
        }
        public bool Iletisim_Ekle(Iletisim model)
        {
            try
            {
                db.Iletisim.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
