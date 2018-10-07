using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lb2mvc.DAL.Entities;

namespace lb2mvc.Models
{
    public class Cart
    {
        List<CartItem> items;
        public Cart()
        {
            items = new List<CartItem>();
        }
        // Добавить в корзину
         public void AddItem(Notebook note) 
         {
            var item = items.Find(i=>i.Notebk.NotebookId == note.NotebookId );
            if (item == null)
            {
                items.Add(new CartItem { Notebk = note, Quantity = 1 });
            }
            else item.Quantity += 1;
        } 
        
        /// Удалить из корзины
         public void RemoveItem(Notebook note)
        {
            var item = items.Find(i => i.Notebk.NotebookId == note.NotebookId);
            if (item.Quantity == 1)
                items.Remove(item);
            else item.Quantity -= 1;
        }
        // Очистить корзину 
        public void Clear()
        {
            items.Clear();
        } 
        /// Получение общей суммы 
        public int GetTotal()
        {
            return items.Sum(i =>(int)i.Notebk.Price * i.Quantity);
        } 
       /// Получение содержимого корзины 
        
        public IEnumerable<CartItem> GetItems()
        {
            return items;
        }
    }
}