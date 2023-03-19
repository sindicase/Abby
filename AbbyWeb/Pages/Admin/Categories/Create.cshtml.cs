using Abby.DataAcess.Data;
using Abby.DataAcess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWOrk;

        
        public Category Category { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            if(Category.Name == Category.DisplayOrder.ToString())                 //SERVER SIDE VALIDATION
            {
                ModelState.AddModelError(Category.Name, "Display order cannot be same as Name");
            }
            if(ModelState.IsValid)
            {

                _unitOfWOrk.Category.Add(Category);
                _unitOfWOrk.Save();      //ADD/SAVE ODKAZ NA ICATEGORYREPOSITORY
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");

            }
            return Page();
            
        }
    }
}
