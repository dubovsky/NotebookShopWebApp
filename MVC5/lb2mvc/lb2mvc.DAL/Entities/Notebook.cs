using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lb2mvc.DAL.Entities
{
    public class Notebook
    {
        [HiddenInput]
        public int NotebookId { get; set; }

        [Required(ErrorMessage ="Введите название")]
        [Display(Name="Название ноутбука")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Range(minimum: 180, maximum: 3000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Группа")]
        public string GroupName { get; set; } //группа,например, AMD, Intel и т.д.

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }

        [ScaffoldColumn(false)]
        public string MimeType { get; set; } //Mipe-тип изображения

    }
}
