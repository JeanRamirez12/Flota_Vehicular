using Flota_Vehicular.Data;
using Flota_Vehicular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Flota_Vehicular.Pages.Registro_de_usos
{
    public class EditModel : PageModel
    {
        public class IndexModel : PageModel
        {
            private readonly FlotavehicularContext _context;
            public IndexModel(FlotavehicularContext context)
            {
                _context = context;
            }
            public IList <Registro_de_uso> Registro_de_usos { get; set; }
            public async Task OnGetAsync()
            {

                Registro_de_usos = await _context.Registro_de_usos.ToListAsync();

            }
        }
    }
}
