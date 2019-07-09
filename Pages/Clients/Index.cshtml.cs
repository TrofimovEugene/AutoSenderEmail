﻿using System;
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
		public IList<Client> Client { get; set; }

		public async Task OnGetAsync()
		{
			Client = await _context.Client.ToListAsync();
		}

		public ActionResult SendMessages()
		{
			return Page();
		}
	}
}