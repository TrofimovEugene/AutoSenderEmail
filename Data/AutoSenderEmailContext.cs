using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoSenderEmail.Models;

namespace AutoSenderEmail.Models
{
    public class AutoSenderEmailContext : DbContext
    {
        public AutoSenderEmailContext (DbContextOptions<AutoSenderEmailContext> options)
            : base(options)
        {
        }

        public DbSet<AutoSenderEmail.Models.Client> Client { get; set; }

        public DbSet<AutoSenderEmail.Models.EmailModel> EmailModel { get; set; }

        public DbSet<AutoSenderEmail.Models.TemplatesEmail> TemplateEmail { get; set; }

        public DbSet<AutoSenderEmail.Models.User> User { get; set; }

    }
}
