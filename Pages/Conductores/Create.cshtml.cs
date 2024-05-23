using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Flota_Vehicular.Pages.Conductores
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
		public Conductor Conductor { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Conductores == null || Conductor == null)
			{
				return Page();
			}

			_context.Conductores.Add(Conductor);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
