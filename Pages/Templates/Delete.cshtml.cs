using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Templates
{
    public class DeleteModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public DeleteModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TemplatesEmail = await _context.TemplateEmail.FindAsync(id);

            if (TemplatesEmail != null)
            {
                _context.TemplateEmail.Remove(TemplatesEmail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
