using Memories.Models;
using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web.Mvc;


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
    [ValidateAntiForgeryToken]
    public ActionResult AddImage(MemoryImage imageModel)
      {

        string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
        string extension = Path.GetExtension(imageModel.ImageFile.FileName);
        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        imageModel.ImagePath = "~/Image/" + fileName;
        fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
        imageModel.ImageFile.SaveAs(fileName);

      _db.Images.Add(imageModel);

      try
      {
        // Your code...
        // Could also be before try if you know the exception occurs in SaveChanges

        _db.SaveChanges();
      }
      catch (DbEntityValidationException e)
      {
        foreach (var eve in e.EntityValidationErrors)
        {
          ViewBag.ErrorMessage = ("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
              eve.Entry.Entity.GetType().Name, eve.Entry.State);
          foreach (var ve in eve.ValidationErrors)
          {
            ViewBag.ErrorMessage = ("- Property: \"{0}\", Error: \"{1}\"",
                ve.PropertyName, ve.ErrorMessage);
          }
        }
        return ViewBag.ErrorMessage;
      }
     



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
