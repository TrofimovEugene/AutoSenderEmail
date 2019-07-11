using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace AutoSenderEmail.Models
{
	public class EmailService
	{
		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("Администрация сайта", "praktika.rassilka2019@gmail.com"));
			emailMessage.To.Add(new MailboxAddress("", email));
			emailMessage.Subject = subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync("smtp.gmail.com", 587, false);
				await client.AuthenticateAsync("praktika.rassilka2019@gmail.com", "43DFPCF6w64vg3L");
				await client.SendAsync(emailMessage);
				await client.DisconnectAsync(true);
			}
		}
	}
}
