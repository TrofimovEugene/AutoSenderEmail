using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Pages.Clients
{
	public class DeleteModel : PageModel
    {
        private readonly AutoSenderEmail.Models.AutoSenderEmailContext _context;

        public DeleteModel(AutoSenderEmail.Models.AutoSenderEmailContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
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

            Client = await _context.Client.FindAsync(id);

            if (Client != null)
            {
                _context.Client.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
