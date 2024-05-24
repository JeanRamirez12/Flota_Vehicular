using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Mantenimientos
{
    public class EditModel : PageModel
    {
        private readonly FlotavehicularContext _context;

        public EditModel(FlotavehicularContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mantenimiento Conductores { get; set; } = default!;
        public Mantenimiento Mantenimientos { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mantenimientos == null)
            {
                return NotFound();
            }

            var Mantenimiento = await _context.Mantenimientos.FirstOrDefaultAsync(m => m.Id == id);
            if (Mantenimiento == null)
            {
                return NotFound();
            }
            Mantenimientos = Mantenimiento;
            return Page();
        }
    }
}
