using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mPloy_TeamProjectG5.Models;

namespace mPloy_TeamProjectG5.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<UserBidOnTask> UserBids { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task>()
                .HasOne<AppUser>(u => u.Creator)
                .WithMany(g => g.CompletedTasks)
                                            .OnDelete(DeleteBehavior.Restrict)
                                .HasForeignKey(p => p.CreatorID);


        }


    }
}
