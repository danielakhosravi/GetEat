using System;

namespace GetEat.WebUI.Models
{
    public class ReviewViewModel
    {
        public int CommentatorUserProfileId { get; set; }

        public int RestourantId { get; set; }

        public string Comment { get; set; }

        public int Score { get; set; }

        public string Commentator { get; set; }

        public DateTime WrittenDate { get; set; }
    }
}