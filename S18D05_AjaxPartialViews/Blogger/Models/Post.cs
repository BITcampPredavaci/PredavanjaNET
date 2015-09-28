using System.Collections.Generic;

namespace Blogger.Models {
	public class Post {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public IList<Comment> Comments { get; set; }
	}
}
