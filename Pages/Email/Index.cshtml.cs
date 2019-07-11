using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Email
{
	public class IndexModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public IndexModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        public IList<EmailModel> EmailModel { get;set; }

        public async Task OnGetAsync()
        {
            EmailModel = await _context.EmailModel.ToListAsync();
        }
    }
}
