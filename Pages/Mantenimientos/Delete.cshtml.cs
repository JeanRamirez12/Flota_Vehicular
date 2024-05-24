using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Mantenimientos
{
    public class DeleteModel : PageModel
    {
		private readonly FlotavehicularContext _context;
		public DeleteModel(FlotavehicularContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Mantenimiento Mantenimiento { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var Mantenimientos = await _context.Mantenimientos.FirstOrDefaultAsync(m => m.Id == id);


			if (Mantenimientos == null)
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

			var Mantenimiento = await _context.Mantenimientos.FindAsync(id);

			if (Mantenimiento != null)
			{
				Mantenimiento = Mantenimiento;
				_context.Mantenimientos.Remove(Mantenimiento);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
