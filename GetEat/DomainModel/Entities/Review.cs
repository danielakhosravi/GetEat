using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Review : BaseEntity
    {
        public int CommentatorUserProfileId { get; set; }

        [ForeignKey("CommentatorUserProfileId")]
        public virtual UserProfile CommentatorUserProfile { get; set; }


        public int RestourantId { get; set; }

        public string Comment { get; set; }

        public int Score { get; set; }
    }
}
