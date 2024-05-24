using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Vehiculos
{
    public class EditModel : PageModel
    {
		private readonly FlotavehicularContext _context;

		public EditModel(FlotavehicularContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Vehiculo Vehiculos { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Vehiculos == null)
			{
				return NotFound();
			}

			var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(m => m.Id == id);
			if (vehiculo == null)
			{
				return NotFound();
			}
			Vehiculos = vehiculo;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Vehiculos).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(Vehiculos.Id))
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
			return (_context.Vehiculos?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
