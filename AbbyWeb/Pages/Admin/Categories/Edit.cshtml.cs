using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWOrk;

        
        public Category Category { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWOrk.Category.GetFirstOrDefault(u =>u.Id==id);

            //Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault(); //DALŠÍ MOŽNOST ZÁPISU
            //Category = _db.Category.SingleOrDefault(U => U.Id==id);   //DALŠI MOŽNOST ZAPISU
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);  //DALŠI MOŽNOST ZAPISU
        }

        public async Task<IActionResult> OnPost() 
        {
            if(Category.Name == Category.DisplayOrder.ToString())                 //SERVER SIDE VALIDATION
            {
                ModelState.AddModelError(Category.Name, "Display order cannot be same as Name");
            }
            if(ModelState.IsValid)
            {

                _unitOfWOrk.Category.Update(Category);
                _unitOfWOrk.Save();
                TempData["success"] = "Category edited successfully";
                return RedirectToPage("Index");

            }
            return Page();
            
        }
    }
}
