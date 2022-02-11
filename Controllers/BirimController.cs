using CorePersonel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePersonel.Controllers
{
    public class BirimController : Controller
    {
        Context context = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var values = context.Birims.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult BirimEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BirimEkle(Birim birim)
        {
            context.Birims.Add(birim);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult BirimSil(int id)
        {
            var birimsil = context.Birims.Find(id);
            context.Birims.Remove(birimsil);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult BirimGetir(int id)
        {
            var birimgetir = context.Birims.Find(id);
            return View("BirimGetir", birimgetir);
        }

        public IActionResult BirimGuncelle(Birim birim)
        {
            var birimguncelle = context.Birims.Find(birim.BirimId);
            birimguncelle.BirimAd = birim.BirimAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimDetay(int id)
        {
            var values = context.Personels.Where(x => x.BirimId == id).ToList();
            var ad = context.Birims.Where(x => x.BirimId == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brmad = ad;
            return View(values);
        }
    }
}
