using ArticlesProject.DatabaseEntities;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesProject.Repository.Interfaces
{
	public interface IReplyRepository : IRepository<Reply>
	{
		IEnumerable<Reply> GetReplyList();
	}
}
