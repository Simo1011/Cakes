using Cakes.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cakes.Pages.CakesFolder
{
    public class IndexModel : PageModel
    {
        private readonly MyDbContext _myWDbContext;
        public IndexModel(MyDbContext myWorldDbContext)
        {
            _myWDbContext = myWorldDbContext;
        }

        public List<Cake> AllCakes = new List<Cake>();

        public async Task<IActionResult> OnGetAsync()
        {
            AllCakes = await _myWDbContext.Cake.ToListAsync();
            return Page();
        }
    }
}
