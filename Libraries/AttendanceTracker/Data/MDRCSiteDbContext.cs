using Microsoft.EntityFrameworkCore;
using MDRC.Data.Models;

namespace MDRC.Data
{
    public class MDRCSiteDbContext : DbContext
    {
        public MDRCSiteDbContext(DbContextOptions<MDRCSiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ClubEventAttendee> ClubEventAttendees { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubEvent>().ToTable(nameof(ClubEvent));
            modelBuilder.Entity<Member>().ToTable(nameof(Member));
            modelBuilder.Entity<ClubEventAttendee>().ToTable(nameof(ClubEventAttendee));
            modelBuilder.Entity<EmailTemplate>().ToTable(nameof(EmailTemplate));
            modelBuilder.Entity<Project>().ToTable(nameof(Project));
            modelBuilder.Entity<ProjectMember>().ToTable(nameof(ProjectMember));
            modelBuilder.Entity<UserAccount>().ToTable(nameof(UserAccount));
        }
    }
}
