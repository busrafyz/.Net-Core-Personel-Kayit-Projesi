using CorePersonel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePersonel.Controllers
{
    public class PersonController : Controller
    {
        Context context = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var values = context.Personels.Include(x => x.Birim).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult PersonelEkle()
        {
            List<SelectListItem> values = (from x in context.Birims.ToList()
                                           select new SelectListItem
                                           {
                                               Text= x.BirimAd,
                                               Value= x.BirimId.ToString()
                                           }
                                            ).ToList();
            ViewBag.vl = values;
            return View();
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personel)
        {
            var values = context.Birims.Where(x => x.BirimId == personel.Birim.BirimId).FirstOrDefault();
            personel.Birim = values;
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            var values = context.Personels.Find(id);
            context.Personels.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        //public IActionResult PersonelGetir(int id)
        //{
        //    var values = context.Personels.Find(id);
        //    return View("PersonelGetir", values);
        //}

        //public IActionResult PersonelGuncelle(Personel personel)
        //{
        //    var values = context.Personels.Find(personel.PersonelId);
        //    values.Name = personel.Name;
        //    values.Surname = personel.Surname;
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
