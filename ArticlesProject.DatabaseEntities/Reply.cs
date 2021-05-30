using System.ComponentModel.DataAnnotations.Schema;

namespace ArticlesProject.DatabaseEntities
{
	public class Reply
	{
		public int ReplyId { get; set; }
		public string Text { get; set; }
		public int? UserId { get; set; }
		public virtual User User { get; set; }
		public int CommentId { get; set; }	
		public virtual Comment Comment { get; set; }
	}
}
