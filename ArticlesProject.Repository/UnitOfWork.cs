using ArticlesProject.DatabaseEntities;
using ArticlesProject.Repository.Implementations;
using ArticlesProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext _db;
        public UnitOfWork(DatabaseContext db)
        {
            //TO DO:
            _db = db;
        }

        private IRepository<Article> _articleRepo;
        public IRepository<Article> ArticleRepo
        {
            get
            {
                if (_articleRepo == null)
                    _articleRepo = new Repository<Article>(_db);
                return _articleRepo;
            }
        }

        private IUserRepository _userRepo;
        public IUserRepository UserRepo
        {
            get
            {
                if (_userRepo == null)
                    _userRepo = new UserRepository(_db);
                return _userRepo;
            }
        }

        private IRepository<Comment> _commentRepo;
        public IRepository<Comment> CommentRepo
        {
            get
            {
                if (_commentRepo == null)
                    _commentRepo = new Repository<Comment>(_db);
                return _commentRepo;
            }
        }

        private IReplyRepository _replyRepo;
        public IReplyRepository ReplyRepo
        {
            get
            {
                if (_replyRepo == null)
                    _replyRepo = new ReplyRepository(_db);
                return _replyRepo;
            }
        }


        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
