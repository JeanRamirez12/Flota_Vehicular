using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Flota_Vehicular.Pages.Registro_de_usos
{
    public class CreateModel : PageModel
    {
		private readonly FlotavehicularContext _context;
		public CreateModel(FlotavehicularContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Registro_de_uso Registro_de_uso { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Registro_de_usos == null || Registro_de_uso == null)
			{
				return Page();
			}

			_context.Registro_de_usos.Add(Registro_de_uso);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
