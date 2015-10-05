using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularSample2.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }

        public bool UpVote { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        public virtual Post Post { get; set; }

        [NotMapped]
        public ApiUser ApiUser
        {
            get
            {
                if(User != null)
                    return new ApiUser() { Email = User.Email, Id = UserId };
                return null;
            }
        }
    }
}
