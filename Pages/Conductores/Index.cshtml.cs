using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Conductores
{
    public class IndexModel : PageModel
    {
        private readonly FlotavehicularContext _context;
        public IndexModel(FlotavehicularContext context)
        {
            _context = context;
        }
        public IList<Conductor> Conductores { get; set; }
        public async Task OnGetAsync()
        {

            Conductores = await _context.Conductores.ToListAsync();

        }
    }
}
