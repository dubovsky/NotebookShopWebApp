using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using lb2mvc.Models;
using lb2mvc.DAL.Entities;
using lb2mvc.DAL.Interfaces;
using lb2mvc.DAL.Repositories;
using lb2mvc.Infrastructure.Binders;

namespace lb2mvc.Controllers
{
    public class CartController : Controller
    {

        EFNotebookRepository repository = new EFNotebookRepository("NotebookConnection");


        // Добавление товара в корзину
        public RedirectResult AddToCart(int id, string returnUrl, Cart cart)
        {
            var item = repository.Get(id);
            if(item!=null)
            {
                cart.AddItem(item);
            }
            TempData["ReturnUrl"] = returnUrl;          
            return Redirect(returnUrl);
        }
        //Информация о корзине в заголовке старницы
        public PartialViewResult CartSummary(Cart cart)
        {
            
            return PartialView(cart);
        }

        // GET: Cart
        [Authorize]
        public ActionResult Index(string returnUrl, Cart cart)
        {
            TempData["returnUrl"] = returnUrl;


            return View(cart);
        }
        //Delete item from list
        public ActionResult Delete(int note, string requestUrl, Cart cart)
        {
            
            var item = repository.Get(note);
            if (item != null)
            {
                cart.RemoveItem(item);
                ViewBag.Message = "Товар удален!";
                
            }

            return View("Index", cart);
        }
    }
}