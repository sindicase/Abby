using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWOrk;

        
        public FoodType FoodType { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            if(ModelState.IsValid)
            {

                _unitOfWOrk.FoodType.Add(FoodType);
                _unitOfWOrk.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");

            }
            return Page();
            
        }
    }
}
