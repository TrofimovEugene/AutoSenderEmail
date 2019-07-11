using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Templates
{
	public class EditTempModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public EditTempModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TemplatesEmail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplatesEmailExists(TemplatesEmail.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TemplatesEmailExists(int id)
        {
            return _context.TemplateEmail.Any(e => e.ID == id);
        }
    }
}
