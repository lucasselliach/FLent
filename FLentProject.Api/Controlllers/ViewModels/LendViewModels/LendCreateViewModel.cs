using System;

namespace FLentProject.Api.Controlllers.ViewModels.LendViewModels
{
    public class LendCreateViewModel
    {
        public string GamerId { get; set; }
        public string FriendId { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
