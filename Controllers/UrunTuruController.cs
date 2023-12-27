using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebProjesi1.Models;
using WebProjesi1.Utility;

namespace WebProjesi1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class UrunTuruController : Controller
    {
        private readonly IUrunTuruRepository _UrunTuruRepository;

        public UrunTuruController(IUrunTuruRepository context)
        {
            _UrunTuruRepository = context;
        }


        public IActionResult Index()
        {

            List<UrunTuru> objUrunTuruList = _UrunTuruRepository.GetAll().ToList();
            return View(objUrunTuruList);
        }

        public IActionResult Ekle()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Ekle(UrunTuru UrunTuru)
        {
            if(ModelState.IsValid)  
            {

                _UrunTuruRepository.Ekle(UrunTuru);
                _UrunTuruRepository.Kaydet();
                TempData["basarili"] = "Yeni Urun Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "UrunTuru");

            }
            return View();
           
        }
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            UrunTuru? UrunTuruVt = _UrunTuruRepository.Get(u=>u.Id==id);//(Expression<Func<T, bool>> filtre)
            if (UrunTuruVt == null)
            {
                return NotFound();
            }
            return View(UrunTuruVt);
        }

        [HttpPost]
        public IActionResult Guncelle(UrunTuru UrunTuru)
        {
            if (ModelState.IsValid)
            {

                _UrunTuruRepository.Guncelle(UrunTuru);
                _UrunTuruRepository.Kaydet();
                TempData["basarili"] = "Yeni Urun Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "UrunTuru");

            }
            return View();

        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UrunTuru? UrunTuruVt = _UrunTuruRepository.Get(u => u.Id == id); ;
            if (UrunTuruVt == null)
            {
                return NotFound();
            }
            return View(UrunTuruVt);
        }


        [HttpPost,ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {

            UrunTuru? UrunTuru = _UrunTuruRepository.Get(u => u.Id == id); ;
            if(UrunTuru == null)
            {
                return NotFound();
            }
            _UrunTuruRepository.Sil(UrunTuru);
            _UrunTuruRepository.Kaydet();
            TempData["basarili"] = "Urun Türü Başarıyla Silindi!";
            return RedirectToAction("Index", "UrunTuru");

        }





    }
}
