namespace ArticlesProject.DBEntities
{
	public class Reply
	{
		public int ReplyId { get; set; }
		public string Text { get; set; }
		public int CommentId { get; set; }
		public Comment CommentObj { get; set; }
		public int UserId { get; set; }
		public User UserObj { get; set; }
	}
}
