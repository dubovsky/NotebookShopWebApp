using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lb2mvc.Models;
using System.Threading.Tasks;
using lb2mvc.DAL.Repositories;
using lb2mvc.DAL.Entities;
using lb2mvc.DAL.Interfaces;

namespace lb2mvc.Controllers
{
    

    public class NotebookController : Controller
    {
        IRepository<Notebook> repository;
        //EFNotebookRepository repository = new EFNotebookRepository("NotebookConnection");
        int pageSize = 3;

        public NotebookController(IRepository<Notebook> repo)
        {
            repository = repo;
        }
        

        // GET: Notebook
        public ActionResult List(string group, int page=1)
        {
            var lst = repository.GetAll().
                Where(d => group == null
                || d.GroupName.Equals(group)).
                OrderBy(d => d.Price);

            var model = PageListViewModel<Notebook>.CreatePage(lst, page, pageSize);

            if(Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }

            return View(model);
        }

        public async Task<FileResult> GetImage(int productId)
        {
            // Notebook prod = repository.Find(d => d.NotebookId == productId).FirstOrDefault();
            var prod = await repository.GetAsync(productId);
            if (prod != null)
                return File(prod.Image, prod.MimeType);
            else
                return null;
        }

    }
}