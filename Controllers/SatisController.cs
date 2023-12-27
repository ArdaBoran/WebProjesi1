using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using WebProjesi1.Models;
using WebProjesi1.Utility;

namespace WebProjesi1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class SatisController : Controller
    {
        private readonly ISatisRepository _SatisRepository;
        private readonly IUrunRepository _UrunRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public SatisController(ISatisRepository SatisRepository, IUrunRepository UrunRepository, IWebHostEnvironment webHostEnvironment)
        {
            _SatisRepository = SatisRepository;
            _UrunRepository = UrunRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {

           
            List<Satis> objSatisList = _SatisRepository.GetAll(includeProps:"Urun").ToList();

            return View(objSatisList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> UrunList = _UrunRepository.GetAll().Select(k => new SelectListItem
            {

                Text = k.UrunAdi,
                Value = k.Id.ToString()
            });

            ViewBag.UrunList = UrunList;
            //controllerdan viewa veri aktarır
            if(id == null ||id==0)
            {
                //ekleme kısmı
                return View();
            }
            else
            {
                //guncelleme
                Satis? SatisVt = _SatisRepository.Get(u => u.Id == id);//(Expression<Func<T, bool>> filtre)
                if (SatisVt == null)
                {
                    return NotFound();
                }
                return View(SatisVt);
            }
            
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Satis Satis)
        {
            //modelstate kaynaklı hatayı yakalamak icin kullanılıyor 
           // var errors = ModelState.Values.SelectMany(x => x.Errors);   

            if(ModelState.IsValid)  
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string UrunPath = Path.Combine(wwwRootPath, @"img");

         
                if (Satis.Id == 0)
                {
                    _SatisRepository.Ekle(Satis);
                    TempData["basarili"] = "Yeni Satis Kaydı Başarıyla Oluşturuldu!";
                }
                else
                {
                    _SatisRepository.Guncelle(Satis);
                    TempData["basarili"] = " Satis Kaydı Güncelleme Tamamlandı!";
                }
                
                _SatisRepository.Kaydet();
                
                return RedirectToAction("Index", "Satis");

            }
            return View();
           
        }
        /*
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
           
        }*/

        /*
        [HttpPost]
        public IActionResult Guncelle(Urun Urun)
        {
            if (ModelState.IsValid)
            {

                _UrunRepository.Guncelle(Urun);
                _UrunRepository.Kaydet();
                TempData["basarili"] = "Yeni Urun  Başarıyla Güncellendi!";
                return RedirectToAction("Index", "Urun");

            }
            return View();

        }*/

        public IActionResult Sil(int? id)
        {
            IEnumerable<SelectListItem> UrunList = _UrunRepository.GetAll().Select(k => new SelectListItem
            {

                Text = k.UrunAdi,
                Value = k.Id.ToString()
            });

            ViewBag.UrunList = UrunList;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Satis? SatisVt = _SatisRepository.Get(u => u.Id == id); ;
            if (SatisVt == null)
            {
                return NotFound();
            }
            return View(SatisVt);
        }


        [HttpPost,ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {

            Satis Satis = _SatisRepository.Get(u => u.Id == id); ;
            if(Satis == null)
            {
                return NotFound();
            }
            _SatisRepository.Sil(Satis);
            _SatisRepository.Kaydet();
            TempData["basarili"] = " Satis Kaydı Başarıyla Silindi!";
            return RedirectToAction("Index", "Satis");

        }





    }
}
