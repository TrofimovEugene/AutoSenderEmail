using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Users
{
    public class RegistrationModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public RegistrationModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User1 { get; set; }
		public IList<User> Users { get; set; }

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
					if (!(User1.Email == item.Email || User1.Login == item.Login))
					{
						_context.User.Add(User1);
						await _context.SaveChangesAsync();
						return RedirectToPage("../Index");
					}
				}
			}
            

            return RedirectToPage("../Index");
        }
    }
}