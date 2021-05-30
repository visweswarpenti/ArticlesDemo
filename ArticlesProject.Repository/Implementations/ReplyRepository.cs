using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ArticlesProject.Repository.Interfaces;
using ArticlesProject.DatabaseEntities;

namespace ArticlesProject.Repository.Implementations
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        private DatabaseContext context
        {
            get
            {
                return _db as DatabaseContext; 
            }
        }
        public ReplyRepository(DbContext db) : base(db)
        {

        }
        public IEnumerable<Reply> GetReplyList()
        {
            // lazy loading // when we access the child object then only the object values will be loaded.
            var result = from reply in context.Replys where reply.Comment.CommentId == 1 select reply;

            // eager loading // with include keyword we can achive eager loading // when returning the data with child objects then it will be usefull
            var data  = result.Include("Comment").Include("User").ToList();
            return data;
        }
    }
}
