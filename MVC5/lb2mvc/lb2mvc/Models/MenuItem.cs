using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lb2mvc.Models
{
    public class MenuItem
    {
        public string Name { get; set; } //Текст надписи
        public string Controller { get; set; } //Имя контроллера
        public string Action { get; set; } //Имя метода
        public string Active { get; set; } //Текущий пункт
    }
}