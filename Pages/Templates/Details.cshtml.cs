using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Templates
{
	public class DetailsModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public DetailsModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        public TemplatesEmail TemplatesEmail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TemplatesEmail = await _context.TemplateEmail.FirstOrDefaultAsync(m => m.ID == id);

            if (TemplatesEmail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
