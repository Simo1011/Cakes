using Cakes.Data.Entities;
using Cakes.Pages.CakesFolder.Vms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cakes.Pages.CakesFolder
{
    public class CreateModel : PageModel
    {
        private readonly MyDbContext _myDbContext;
        public CreateModel(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        [BindProperty]
        public CakeVm CakeVm { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _myDbContext.Add(new Cake());
            entry.CurrentValues.SetValues(CakeVm);
            await _myDbContext.SaveChangesAsync();
            return Redirect("home");
        }
    }
}
