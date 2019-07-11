using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoSenderEmail.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoSenderEmail.Pages
{
	public class IndexModel : PageModel
	{
		private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

		public IndexModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
		{
			_context = context;
		}
		[BindProperty]
		public User User1 { get; set; }
		public IList<User> Users { get; set; }
		public IActionResult OnGet()
		{

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			Users = await _context.User.ToListAsync();

			if (!ModelState.IsValid)
			{
				return Page();
			}
			if (Users != null)
			{
				foreach (var item in Users)
				{
					if (User1.Email == item.Email && User1.Passowrd == item.Passowrd)
					{
						return RedirectToPage("/Clients/Index");
					}
				}
			}


			return RedirectToPage("./Index");
		}
	}
}
