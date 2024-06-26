using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Vehiculos
{
    public class IndexModel : PageModel
    {
        private readonly FlotavehicularContext _context;
        public IndexModel(FlotavehicularContext context)
        {
            _context = context;
        }
        public IList<Vehiculo> Vehiculos { get; set; }
        public async Task OnGetAsync()
        {
            //if (_context.Categories != null)
            //{
            Vehiculos = await _context.Vehiculos.ToListAsync();
            //}
        }
    }
}
