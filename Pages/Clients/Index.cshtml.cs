using System;
using System.Collections.Generic;
using System.Linq;
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
		public EmailModel EmailModel { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			Client = await _context.Client.ToListAsync(); 

			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			Client = await _context.Client.ToListAsync();

			if (Client != null)
			{
				foreach(var item in Client)
				{
					EmailService emailService = new EmailService();
					await emailService.SendEmailAsync(item.Email, item.Theme, "hello!");
				}
			}
			return RedirectToPage("./Index");
		}
	}
}
