using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Email
{
	public class DeleteModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public DeleteModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmailModel EmailModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmailModel = await _context.EmailModel.FirstOrDefaultAsync(m => m.ID == id);

            if (EmailModel == null)
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

            EmailModel = await _context.EmailModel.FindAsync(id);

            if (EmailModel != null)
            {
                _context.EmailModel.Remove(EmailModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
