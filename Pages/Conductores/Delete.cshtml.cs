using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Conductores
{
    public class DeleteModel : PageModel
    {
			private readonly FlotavehicularContext _context;
			public DeleteModel(FlotavehicularContext context)
			{
				_context = context;
			}

			[BindProperty]
			public Conductor Conductor { get; set; }

			public async Task<IActionResult> OnGetAsync(int? id)
			{
				if (id == null)
				{
					return NotFound();
				}

				var category = await _context.Conductores.FirstOrDefaultAsync(m => m.Id == id);


				if (category == null)
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

				var Conductor = await _context.Conductores.FindAsync(id);

				if (Conductor != null)
				{
				    Conductor = Conductor;
					_context.Conductores.Remove(Conductor);
					await _context.SaveChangesAsync();

				}

				return RedirectToPage("./Index");
			}
		}
}
