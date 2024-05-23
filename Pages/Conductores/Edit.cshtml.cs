using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Conductores
{
    public class EditModel : PageModel
    {
        private readonly FlotavehicularContext _context;
        
        public EditModel(FlotavehicularContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conductor Conductores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Conductores == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductores.FirstOrDefaultAsync(m => m.Id == id);
            if (conductor == null)
            {
                return NotFound();
            }
            Conductores = conductor;
            return Page();
        }
    }
}
