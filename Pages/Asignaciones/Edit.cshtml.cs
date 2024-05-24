using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Asignaciones
{
    public class EditModel : PageModel
    {
		private readonly FlotavehicularContext _context;

		public EditModel(FlotavehicularContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Asignacion Asignaciones { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Asignaciones == null)
			{
				return NotFound();
			}

			var Asignacion = await _context.Asignaciones.FirstOrDefaultAsync(m => m.Id == id);
			if (Asignacion == null)
			{
				return NotFound();
			}
			Asignaciones = Asignacion;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Asignaciones).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(Asignaciones.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool ProductExists(int id)
		{
			return (_context.Asignaciones?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
