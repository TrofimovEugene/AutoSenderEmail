using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Templates
{
	public class IndexModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public IndexModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        public IList<TemplatesEmail> TemplatesEmail { get;set; }

        public async Task OnGetAsync()
        {
            TemplatesEmail = await _context.TemplateEmail.ToListAsync();
        }
    }
}
