using Cakes.Data.Entities;
using Cakes.Pages.CakesFolder.Vms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cakes.Pages.CakesFolder
{
    public class DeleteModel : PageModel
    {
        private readonly MyDbContext _myDbContext;
        public DeleteModel(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public string ErrorMessage { get; set; }
        public CakeVm? CakeVm { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError)
        {
            CakeVm = await _myDbContext.Cake
                    .Where(_ => _.Id == id)
                    .Select(_ =>
                    new CakeVm
                    {
                        Description = _.Description,
                        Id = _.Id,
                        Name = _.Name,
                        Price = _.Price
                    }).FirstOrDefaultAsync();

            if (CakeVm == null)
            {
                return NotFound();
            }
            if (saveChangesError ?? false)
            {
                ErrorMessage = $"Error to delete the record id - {id}";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var recordToDelete = await _myDbContext.Cake.FindAsync(id);

            if (recordToDelete == null)
            {
                return Page();
            }

            try
            {
                _myDbContext.Cake.Remove(recordToDelete);
                await _myDbContext.SaveChangesAsync();
                return Redirect("cake/home");
            }
            catch
            {
                return Redirect($"delete?id={id}&saveChangesError=true");
            }
        }

    }
}
