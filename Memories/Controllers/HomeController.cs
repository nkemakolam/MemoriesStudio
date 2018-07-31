using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemMonitor.Models;

namespace Memories.Controllers
{
    public class HomeController : Controller
    {
    private readonly EFDbContext _db;

    public HomeController()
    {
      _db = new EFDbContext();
    }
    protected override void Dispose(bool disposing)
    {
      _db.Dispose();
    }

    // GET: Home
    public ActionResult Index()
        {

            int numberOfrecords = 16;

            var imagemodel = _db.Images.ToList().OrderByDescending(x => x.ImageId).Take(numberOfrecords);
            if (imagemodel == null)
      {
        return HttpNotFound();
      }

      return View(imagemodel);
    }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Single()
        {
            return View();
        }

        public ActionResult TopTen()
        {
            return View();
        }
    }

   
}
