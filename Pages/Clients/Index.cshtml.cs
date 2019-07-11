using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Clients
{
	public class IndexModel : PageModel
	{
		private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

		public IndexModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
		{
			_context = context;
		}
		[BindProperty]
		public IList<Client> Client { get; set; }
		public IList<TemplatesEmail> templatesEmail { get; set; }
		[BindProperty]
		public IList<EmailModel> EmailModel { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			Client = await _context.Client.ToListAsync();
			templatesEmail = await _context.TemplateEmail.ToListAsync();

			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			Client = await _context.Client.ToListAsync();
			templatesEmail = await _context.TemplateEmail.ToListAsync();

			if (!ModelState.IsValid)
			{
				return Page();
			}
			int i = 0;
			if (Client != null)
			{
				foreach (var item in Client)
				{
					EmailService emailService = new EmailService();
					foreach (var temp in templatesEmail)
					{
						if (item.ID_template == temp.ID)
						{
							EmailModel.Add(new Models.EmailModel());
							EmailModel[i].Subject = temp.Subject;
							EmailModel[i].From = "praktika.rassilka2019@gmail.com";
							EmailModel[i].To = item.Email;
							EmailModel[i].Body = temp.Body;
							EmailModel[i].SendDate = DateTime.Now;
							_context.EmailModel.Add(EmailModel[i]);
							await _context.SaveChangesAsync();
							await emailService.SendEmailAsync(item.Email, item.Theme, temp.Body);
							i++;
						}
						
					}
					
				}
			}
			EmailModel = null;
			return RedirectToPage("./Index");
		}
	}
}
