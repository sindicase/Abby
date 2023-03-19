using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWOrk;

        
        public FoodType FoodType { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public void OnGet(int id)
        {
            FoodType = _unitOfWOrk.FoodType.GetFirstOrDefault(u => u.Id == id);

            //Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault(); //DAL�� MO�NOST Z�PISU
            //Category = _db.Category.SingleOrDefault(U => U.Id==id);   //DAL�I MO�NOST ZAPISU
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);  //DAL�I MO�NOST ZAPISU
        }

        public async Task<IActionResult> OnPost() 
        {
            if(ModelState.IsValid)
            {

                _unitOfWOrk.FoodType.Update(FoodType);
                _unitOfWOrk.Save();
                TempData["success"] = "Food Type edited successfully";
                return RedirectToPage("Index");

            }
            return Page();
            
        }
    }
}
