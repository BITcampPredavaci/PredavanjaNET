using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularSample2.Models
{



    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string AuthorId { get; set; }
        
        [JsonIgnore]
        public virtual ApplicationUser Author { get; set; }

        public virtual List<Vote> Votes { get; set; }

        [NotMapped]
        public int UpVotes
        {
            get
            {
                return Votes.Count(vote => vote.UpVote == true);
            }
        }

        [NotMapped]
        public int DownVotes
        {
            get
            {
                return Votes.Count(vote => vote.UpVote == false);
            }
        }

        [NotMapped]
        public ApiUser User { get
            {
                return new ApiUser() { Email = Author.Email, Id = AuthorId };
            }
        }

        public Post()
        {
            Votes = new List<Vote>();
        }
    }
}
