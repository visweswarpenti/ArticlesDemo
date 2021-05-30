namespace ArticlesProject.Models
{
	public class Comment
	{
		public int CommentId { get; set; }
		public string Text { get; set; }
		public int UserId { get; set; }
		public User UserObj { get; set; }
		public int ArticleId { get; set; }
		public Article ArticleObj { get; set; }
	}
}
