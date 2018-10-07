using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace lb2mvc.DAL.Entities
{
   public class PcContext:DbContext
    {
        public PcContext(string name): base(name)
        {
            Database.SetInitializer(new PcContextInitializer());
        }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}
