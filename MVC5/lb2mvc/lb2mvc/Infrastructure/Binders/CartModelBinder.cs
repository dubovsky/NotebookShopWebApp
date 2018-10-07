using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using lb2mvc.DAL.Entities;
using lb2mvc.Models;

namespace lb2mvc.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

 
            // get the Cart from the session
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session["Cart"];
            }           
            // create the Cart if there wasn't one in the session data 
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session["Cart"] = cart;
                }
            }
            // return the cart 
            return cart;

        }
    }
}