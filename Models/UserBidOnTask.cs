using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mPloy_TeamProjectG5.Models
{
    public class UserBidOnTask
    {
        [Key]
        public int BidID { get; set; }
        public bool? isAccepted { get; set; }

        // Foreign Keys

        [ForeignKey(nameof(TaskID))]
        public int TaskID { get; set; }
        [ForeignKey(nameof(UserID))]
        public int UserID { get; set; }

        // Navigation Properties
        public virtual Task Task { get; set; }
        public virtual AppUser User { get; set; }
    }
}

