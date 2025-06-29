using MVC_BusinessLayer.Concrete;
using MVC_DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            //toplam kategory sayısı          
            ViewBag.toplamKategoriSayisi = cm.GetList().Count();

            //yazılım kategorisine ait toplam başlık sayısı
            int yazilimCategoryId = int.Parse(cm.GetList().Where(x => x.CategoryName == "Yazılım").Select(y => y.CategoryId).FirstOrDefault().ToString());
            ViewBag.YazilimKategorisiToplamBaslikSayisi = hm.GetList().Where(x=>x.CategoryId== yazilimCategoryId).Count();

            //Adında a harfi geçen yazarlar
            ViewBag.icindeAHarfiGecenYazarSayisi = wm.GetList().Count(x => x.WriterName.Contains("a") || x.WriterName.Contains("A"));

            //En başlığa sahip kategori
            var enCokBaslikliKategori = hm.GetList().GroupBy(h => h.CategoryId).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            var kategoriAdi = cm.GetList().Where(c => c.CategoryId == enCokBaslikliKategori).Select(c => c.CategoryName).FirstOrDefault();
            ViewBag.enCokBaslikliKategoriAdi = kategoriAdi;

            // aktif ve pasif kategori sayısı farkı
            int aktifKategoriSayisi = cm.GetList().Count(x => x.CategoryStatus == true);
            int pasifKategoriSayisi = cm.GetList().Count(x => x.CategoryStatus == false);
            ViewBag.aktifPasifKategoriFarki = Math.Abs(aktifKategoriSayisi - pasifKategoriSayisi);

            return View();
        }
    }
}