using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb2mvc.DAL.Entities;
using lb2mvc.DAL.Interfaces;
using System.Data.Entity;
using lb2mvc.DAL.Repositories;

namespace lb2mvc.DAL.Repositories
{
   public class EFNotebookRepository: IRepository<Notebook>
    {
        PcContext context;
        public EFNotebookRepository(string name)
        {
            context = new PcContext(name);
        }
        public void Create(Notebook t)
        {
            context.Notebooks.Add(t);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var item = context.Notebooks.Find(id);
            if(item!=null)
            {
                context.Notebooks.Remove(item);
                context.SaveChanges();
            }
        }
        public IEnumerable<Notebook> Find(Func<Notebook, bool> predicate)
        {
            return context.Notebooks.Where(predicate).ToList();
        }
        public Notebook Get(int id)
        {
            return context.Notebooks.Find(id);
        }
        public IEnumerable<Notebook> GetAll()
        {
            return context.Notebooks;
        }
        public void Update(Notebook t)
        {
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Task<Notebook> GetAsync(int id)
        {
            return context.Notebooks.FindAsync(id);
        }
     }
}
