using mPloy_TeamProjectG5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mPloy_TeamProjectG5.Services.Interfaces
{
    public interface IBidService
    {
        public IEnumerable<UserBidOnTask> GetAllBids();
        public void CreateBid(UserBidOnTask bid);
        public void ApproveBid(UserBidOnTask bid);
        public void RejectBid(UserBidOnTask bid);
        public UserBidOnTask GetBid(int id);
        public UserBidOnTask GetBidByTaskId(int id);
        public AppUser GetApprovedUser(UserBidOnTask bid);
        public bool CheckWhetherUserAppliedForTheTask(int userId, int taskId);
        public List<int> GetListOfTasksUserHasAppliedFor(int userId);
        public ICollection<AppUser> GetListOfUsersApplyingForSpecificTask(int taskId);
        public bool IsAnyBidAccepted(int taskId);


    }
}
