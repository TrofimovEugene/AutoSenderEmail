using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoSenderEmail.Models
{
	public class EmailModel
	{
		public int ID { get; set; }
		public string Subject { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string Body { get; set; }
		[Display(Name = "Send Date")]
		[DataType(DataType.Date)]
		public DateTime SendDate { get; set; }
	}
}
