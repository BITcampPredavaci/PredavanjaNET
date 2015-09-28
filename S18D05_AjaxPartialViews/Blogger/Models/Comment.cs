namespace Blogger.Models {
	public class Comment {
		public int Id { get; set; }
		public string Body { get; set; }
		public Post Post { get; set; }
	}
}
