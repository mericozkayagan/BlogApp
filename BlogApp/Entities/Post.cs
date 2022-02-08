using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entities
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContext { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool PostStatus { get; set; }
    }
}
