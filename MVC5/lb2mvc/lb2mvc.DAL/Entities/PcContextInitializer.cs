using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2mvc.DAL.Entities
{
    using System.Data.Entity;
  public  class PcContextInitializer:DropCreateDatabaseIfModelChanges<PcContext>
    {
        protected override void Seed(PcContext context)
        {
            List<Notebook> notes = new List<Notebook> {
            new Notebook {  Name = "LenovoGLX", Description = "Lightweight", Price = 255, GroupName = "AMD" },
            new Notebook {  Name = "AcerAspire256", Description = "Modern", Price = 235, GroupName = "Intel" },
            new Notebook {  Name = "HpX1N8", Description = "UltraThin", Price = 275, GroupName = "Intel" },
            new Notebook {  Name = "ASUSxrz", Description = "Significant", Price = 295, GroupName = "Intel" },
            new Notebook {  Name = "DelXPS17", Description = "EasyToUse", Price = 225, GroupName = "AMD" },
            new Notebook {  Name = "Apple", Description = "Stylish", Price = 325, GroupName = "AMD" },
            new Notebook {  Name = "Mac", Description = "True", Price = 390, GroupName = "AMD" },
            new Notebook {  Name = "LenovoG580", Description = "Unbreakable", Price = 235, GroupName = "Intel" },
            new Notebook {  Name = "ASUSprint", Description = "Tech", Price = 310, GroupName = "Intel" },
            new Notebook {  Name = "HpA1N1", Description = "Physix", Price = 255, GroupName = "AMD" },
            new Notebook { Name = "HpSolo", Description = "GamersEdition", Price = 315, GroupName = "Intel" }};
            context.Notebooks.AddRange(notes);
            context.SaveChanges();
            }
        }
    }

