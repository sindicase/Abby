using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWOrk;

        
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWOrk.Category.GetFirstOrDefault(u => u.Id == id);

            //Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault(); //DALŠÍ MOŽNOST ZÁPISU
            //Category = _db.Category.SingleOrDefault(U => U.Id==id);   //DALŠI MOŽNOST ZAPISU
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);  //DALŠI MOŽNOST ZAPISU
        }

        public async Task<IActionResult> OnPost() 
        {
           
                var categoryFromDb = _unitOfWOrk.Category.GetFirstOrDefault(u => u.Id == Category.Id);
                if(categoryFromDb != null)
                {
                    _unitOfWOrk.Category.Remove(categoryFromDb);
                    _unitOfWOrk.Save();
                    TempData["success"]="Category deleted successfully";
                    return RedirectToPage("Index");
                     

                }
            return Page();
          

        }
    }
}
