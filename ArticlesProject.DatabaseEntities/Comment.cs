namespace ArticlesProject.DatabaseEntities
{
	public class Comment
	{
		public int CommentId { get; set; }
		public string Text { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int ArticleId { get; set; }
		public virtual Article Article { get; set; }
	}
}
