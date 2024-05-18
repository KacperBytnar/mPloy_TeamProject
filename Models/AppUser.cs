using Microsoft.AspNetCore.Identity;

namespace mPloy_TeamProjectG5.Models
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            this.CompletedTasks = new HashSet<Task>();
        }
        public override int Id { get; set; }
        public int? Age { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }


        // Navigation Properties
        public virtual ICollection<Task> CompletedTasks { get; set; }

    }
}
