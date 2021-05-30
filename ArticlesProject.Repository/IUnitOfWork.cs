using ArticlesProject.DatabaseEntities;
using ArticlesProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesProject.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Article> ArticleRepo { get; }

        IRepository<Comment> CommentRepo { get; }

        IUserRepository UserRepo { get; }

        IReplyRepository ReplyRepo { get; }

        int SaveChanges();
    }
}
