using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Asignaciones
{
	//index
    public class IndexModel : PageModel
    {
		private readonly FlotavehicularContext _context;
		public IndexModel(FlotavehicularContext context)
		{
			_context = context;
		}
		public IList<Asignacion> Asignaciones { get; set; }
		public async Task OnGetAsync()
		{
			//if (_context.Categories != null)
			//{
			Asignaciones = await _context.Asignaciones.ToListAsync();
			//}
		}
	}
}
