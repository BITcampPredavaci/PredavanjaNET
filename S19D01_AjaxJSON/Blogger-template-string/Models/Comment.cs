using Newtonsoft.Json;

namespace Blogger.Models {
	public class Comment {
		public int Id { get; set; }
		public string Body { get; set; }
		[JsonIgnore]
		public Post Post { get; set; }
	}
}
