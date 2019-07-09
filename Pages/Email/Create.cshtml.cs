using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Email
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
        public EmailModel EmailModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmailModel.Add(EmailModel);
            await _context.SaveChangesAsync();

			EmailService emailService = new EmailService();
			await emailService.SendEmailAsync(EmailModel.To, EmailModel.Subject, EmailModel.Body);

            return RedirectToPage("./Index");
        }
    }
}