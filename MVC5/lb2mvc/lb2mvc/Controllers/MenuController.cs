using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lb2mvc.DAL.Repositories;

namespace lb2mvc.Controllers
{
    using lb2mvc.DAL.Interfaces;
    using lb2mvc.DAL.Entities;
    using lb2mvc.Models;
    
    public class MenuController : Controller
    {
         EFNotebookRepository repository = new EFNotebookRepository("NotebookConnection");
        
        List <MenuItem> items = new List<MenuItem>
            {
                new MenuItem{Name="Домой",Controller="Home",Action="Index",Active=string.Empty},
                new MenuItem{Name="Каталог",Controller="Notebook",Action="List",Active=string.Empty},
                new MenuItem{Name="Администрирование",Controller="Admin",Action="Index",Active=string.Empty}
            };

        //Заглушки методов
        public PartialViewResult Main(string c="Home")
        {
            var result = items.Where(m => m.Controller == c);
            if(result.Any())
            {
                result.First().Active = "active";
            }
           
            return PartialView(items);
        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }
        public PartialViewResult Side()
        {
            var groups = repository.GetAll().Select(d => d.GroupName).Distinct();
            return PartialView(groups);
        }
        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}