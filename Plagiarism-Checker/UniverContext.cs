using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Plagiarism_Checker.Models
{
    public partial class UniverContext : IdentityDbContext
    {
        public UniverContext()
        {
        }

        public UniverContext(DbContextOptions<UniverContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> User { get; set; }

        // Unable to generate entity type for table 'dbo.User'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Univer;Trusted_Connection=True;");
            }
        }
    }
}
