using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lb2mvc.DAL.Entities;
namespace lb2mvc.Models
{
    public class CartItem
    {
        public Notebook Notebk { get; set; }
        public int Quantity { get; set; } //количество
    }
}