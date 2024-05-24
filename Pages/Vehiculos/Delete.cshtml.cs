using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Vehiculos
{
    public class DeleteModel : PageModel
    {
        private readonly FlotavehicularContext _context;
        public DeleteModel(FlotavehicularContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehiculo Vehiculos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(m => m.Id == id);


            if (vehiculo == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo != null)
            {
                Vehiculos = vehiculo;
                _context.Vehiculos.Remove(Vehiculos);
                await _context.SaveChangesAsync();

            }

            return RedirectToPage("./Index");
        }
    }
}
