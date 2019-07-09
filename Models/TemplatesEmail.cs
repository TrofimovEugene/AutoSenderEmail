using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSenderEmail.Models
{
	public class TemplatesEmail
	{
		public int ID { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
	}
}
