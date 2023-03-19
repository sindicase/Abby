using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAcess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable  //TENHLE INTERFACE ZASTRESUJE VSECHNY INTERFACI CO MÁME VYTVORENE
    {
        ICategoryRepository Category { get; }

        IFoodTypeRepository FoodType { get; }

        IMenuItemRepository MenuItem { get; }
        void Save();
    }
}
