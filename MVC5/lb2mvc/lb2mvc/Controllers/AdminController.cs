using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lb2mvc.Controllers
{
    using lb2mvc.DAL.Entities;
    using lb2mvc.DAL.Repositories;
    using lb2mvc.DAL.Interfaces;

    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        EFNotebookRepository repository = new EFNotebookRepository("NotebookConnection");

        

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

       

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Notebook());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Notebook note, HttpPostedFileBase imageUpload=null)
        {
            if(ModelState.IsValid)
            {
            if (imageUpload != null)
            {
                var count = imageUpload.ContentLength;
                note.Image = new byte[count];
                imageUpload.InputStream.Read(note.Image, 0, (int)count);
                note.MimeType = imageUpload.ContentType;
            }


            try
            {
                repository.Create(note);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            }
           else return View(note);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Notebook note, HttpPostedFileBase imageUpload=null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    note.Image = new byte[count];
                    imageUpload.InputStream.Read(note.Image, 0, (int)count);
                    note.MimeType = imageUpload.ContentType;
                }

                try
                {

                    repository.Update(note);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(note);
        }

        // GET: Admin/Delete
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

       
          
        
    }
}
