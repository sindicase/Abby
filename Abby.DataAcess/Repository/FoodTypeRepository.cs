using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAcess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(FoodType obj)
        {
            var objFromDb = _db.FoodType.FirstOrDefault(u=> u.Id == obj.Id);  //tohle prida foodtype object z databaze
            objFromDb.Name = obj.Name;

        }
    }
}
