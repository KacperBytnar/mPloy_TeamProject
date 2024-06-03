using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Common.Enums;

namespace mPloy_TeamProjectG5.Models
{
    public class Task
    {
        public Task()
        {
            //this.Users = new HashSet<AppUser>();
        }
        [Key]
        public int TaskID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        public string? PictureName { get; set; }
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Prize is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Prize must be a positive number")]
        public int Prize { get; set; }
        public TaskState State { get; set; }
        [Required(ErrorMessage = "Payment method is required")]
        public PaymentMethod Payment { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public TaskCategory Categories { get; set; }

        // Foreign Keys
        [ForeignKey(nameof(Creator))]
        public int CreatorID { get; set; }

        //[ForeignKey(nameof(Performer))]
       // public int? PerformerID { get; set; }

        // Navigation Properties
        public virtual AppUser Creator { get; set; }
        // public virtual AppUser Performer { get; set; }
    }
    //public class Task
    //{
    //    public Task()
    //    {
    //        //this.Users = new HashSet<AppUser>();
    //    }

    //    [Key]
    //    public int TaskID { get; set; }
    //    [Required(ErrorMessage = "Title is required")]
    //    public string Title { get; set; }
    //    [Required(ErrorMessage = "Description is required")]
    //    public string Description { get; set; }
    //    [Required(ErrorMessage = "Location is required")]
    //    public string? Location { get; set; }
    //    public string? PictureName { get; set; }
    //    public DateTime DueDate { get; set; }
    //    [Required(ErrorMessage = "Prize is required")]
    //    [Range(0, double.MaxValue, ErrorMessage = "Prize must be a positive number")]
    //    public int Prize { get; set; }
    //    public TaskState State { get; set; }
    //    [Required(ErrorMessage = "Payment method is required")]
    //    public PaymentMethod Payment { get; set; }
    //    [Required(ErrorMessage = "Category is required")]
    //    public TaskCategory Categories { get; set; }


    //    // Foreign Keys
    //    [ForeignKey(nameof(CreatorID))]
    //    public int CreatorID { get; set; }

    //    //[ForeignKey(nameof(PerformerID))]
    //    //public int? PerformerID { get; set; }

    //    // Navigation Properties
    //    public virtual AppUser User { get; set; }
    //    //public virtual ICollection<AppUser> Users{ get; set; }
    //}
}


