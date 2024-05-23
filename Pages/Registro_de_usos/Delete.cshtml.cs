using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Registro_de_usos
{
    public class DeleteModel : PageModel
    {
		private readonly FlotavehicularContext _context;
		public DeleteModel(FlotavehicularContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Registro_de_uso Registro_de_uso { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.Registro_de_usos.FirstOrDefaultAsync(m => m.Id == id);


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

			var Registro_de_uso = await _context.Registro_de_usos.FindAsync(id);

			if (Registro_de_uso != null)
			{
				Registro_de_uso = Registro_de_uso;
				_context.Registro_de_usos.Remove(Registro_de_uso);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
