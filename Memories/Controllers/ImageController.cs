using Memories.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using SystemMonitor.Models;

namespace Memories.Controllers
{
  
    public class ImageController : Controller
    {
    // GET: Image
    private readonly EFDbContext _db;

    public ImageController()
    {
      _db = new EFDbContext();
    }
    protected override void Dispose(bool disposing)
    {
      _db.Dispose();
    }


    // GET: Image
    public ActionResult AddImage()
      {
        return View();
      }
      [HttpPost]
      public ActionResult AddImage(MemoryImage imageModel)
      {

        string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
        string extension = Path.GetExtension(imageModel.ImageFile.FileName);
        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        imageModel.ImagePath = "~/Image/" + fileName;
        fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
        imageModel.ImageFile.SaveAs(fileName);

      _db.Images.Add(imageModel);
      _db.SaveChanges();



        return View();
      }

        [HttpGet]
        public ActionResult Gallary()
        {
            

            var imagemodel = _db.Images.ToList();
             if (imagemodel == null)
               {
                 return HttpNotFound();
                }
              
                  return View(imagemodel);
          }
    }

  }
