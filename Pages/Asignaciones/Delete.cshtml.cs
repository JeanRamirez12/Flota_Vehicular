using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Asignaciones
{
    public class DeleteModel : PageModel
    {
		private readonly FlotavehicularContext _context;
		public DeleteModel(FlotavehicularContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Asignacion Asignaciones { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var Asignacion = await _context.Asignaciones.FirstOrDefaultAsync(m => m.Id == id);


			if (Asignacion == null)
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

			var Asignacion = await _context.Asignaciones.FindAsync(id);

			if (Asignacion != null)
			{
				Asignaciones = Asignacion;
				_context.Asignaciones.Remove(Asignaciones);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
