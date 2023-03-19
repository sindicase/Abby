using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class   //REPOSITORY - SLOUŽÍ PROTO ABY SE UZIVATEL NEDOTAZOVAL PRIMO NA DBCONTEXT, TOHLE JE VLASTNE JEN VEC KTERÁ JE MEZI DBCONTEXT A UZIVATELSKYM REQUESTEM - VICEMENE TO DELA REDIRECT DOTAZU OD UZIVATELE
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;  //dbSet pak posila veci na DbContext

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
            this.dbSet = db.Set<T>();  //dbSet ted muze provadet vsechny operace 

        }

        //VŠECHNY TYHLE ADD/GET/FIRSTORDEFAULT ATD.. NAHRAZUJI VECI, KTERÉ JSOU VŽDY V jmeno.cshtml.cs - MÍSTO TOHO ABY SE PROVÁDĚLI TAM, TAK SE PROVEDOU TADY

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProterty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query= query.Include(includeProterty);
                }
            }
            return query.ToList();             //toto vrati vsechny categorie do listu
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filtert = null)
        {
            IQueryable<T> query = dbSet;
            if(filtert!= null)
            {
                query = query.Where(filtert);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
