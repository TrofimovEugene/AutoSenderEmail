using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSenderEmail.Models
{
	public class User
	{
		public int ID { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string Passowrd { get; set; }
	}
}
