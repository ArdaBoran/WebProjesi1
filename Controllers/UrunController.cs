using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using System.Linq.Expressions;
using WebProjesi1.Models;
using WebProjesi1.Utility;

namespace WebProjesi1.Controllers
{
    
    public class UrunController : Controller
    {
        private readonly IUrunRepository _UrunRepository;
        private readonly IUrunTuruRepository _UrunTuruRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public UrunController(IUrunRepository UrunRepository, IUrunTuruRepository UrunTuruRepository, IWebHostEnvironment webHostEnvironment)
        {
            _UrunRepository = UrunRepository;
            _UrunTuruRepository = UrunTuruRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,Musteri")]
        public IActionResult Index(string ara)
        {

            // List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
            List<Urun> objUrunList = _UrunRepository.GetAll(includeProps: "UrunTuru").ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                objUrunList = objUrunList.Where(x => x.Barkod.Contains(ara)).ToList();

            }

            return View(objUrunList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> UrunTuruList = _UrunTuruRepository.GetAll().Select(k => new SelectListItem
            {

                Text = k.Ad,
                Value = k.Id.ToString()
            });

            ViewBag.UrunTuruList = UrunTuruList;
            //controllerdan viewa veri aktarır
            if(id == null ||id==0)
            {
                //ekleme kısmı
                return View();
            }
            else
            {
                //guncelleme
                Urun? UrunVt = _UrunRepository.Get(u => u.Id == id);//(Expression<Func<T, bool>> filtre)
                if (UrunVt == null)
                {
                    return NotFound();
                }
                return View(UrunVt);
            }
            
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(Urun Urun, IFormFile? file )
        {
            //modelstate kaynaklı hatayı yakalamak icin kullanılıyor 
           // var errors = ModelState.Values.SelectMany(x => x.Errors);   

            if(ModelState.IsValid)  
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string UrunPath = Path.Combine(wwwRootPath, @"img");

                if(file!= null)
                {

              
                using (var fileStream = new FileStream(Path.Combine(UrunPath,file.FileName ),FileMode.Create))
                {
                    file.CopyTo(fileStream);

                }
                Urun.ResimUrl = @"\img\" + file.FileName;
                }

                if (Urun.Id == 0)
                {
                    _UrunRepository.Ekle(Urun);
                    TempData["basarili"] = "Yeni Urun Başarıyla Oluşturuldu!";
                }
                else
                {
                    _UrunRepository.Guncelle(Urun);
                    TempData["basarili"] = " Urun Güncelleme Tamamlandı!";
                }
                
                _UrunRepository.Kaydet();
                
                return RedirectToAction("Index", "Urun");

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
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Urun? UrunVt = _UrunRepository.Get(u => u.Id == id); ;
            if (UrunVt == null)
            {
                return NotFound();
            }
            return View(UrunVt);
        }


        [HttpPost,ActionName("Sil")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult SilPOST(int? id)
        {

            Urun? Urun = _UrunRepository.Get(u => u.Id == id); ;
            if(Urun == null)
            {
                return NotFound();
            }
            _UrunRepository.Sil(Urun);
            _UrunRepository.Kaydet();
            TempData["basarili"] = "Urun Başarıyla Silindi!";
            return RedirectToAction("Index", "Urun");

        }





    }
}
