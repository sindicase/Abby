using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWOrk;


        public IEnumerable<MenuItem> MenuItems { get; set; }


        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public void OnGet()
        {
            MenuItems = _unitOfWOrk.MenuItem.GetAll();
        }
    }
}
