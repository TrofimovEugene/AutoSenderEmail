using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Templates
{
	public class CreateModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public CreateModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TemplatesEmail TemplatesEmail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TemplateEmail.Add(TemplatesEmail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}