using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ArticlesProject.Repository.Interfaces;
using ArticlesProject.DatabaseEntities;
using System.Threading.Tasks;

namespace ArticlesProject.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private DatabaseContext context
        {
            get
            {
                return _db as DatabaseContext; 
            }
        }
        public UserRepository(DbContext db) : base(db)
        {

        }

        public IEnumerable<User> UsersWhoNeverReplied()
        {
            List<User> users = new List<User>();
            return context.Users.Where(user => !context.Replys.Any(obj => obj.UserId == user.UserId))?.Select(user => user);
        }

        public IEnumerable<User> UsersWhoRepliedAlteastOnce()
        {
           return (from user in context.Users
                     join reply in context.Replys on user.UserId equals reply.UserId
                     select user).ToList();
        }
    }
}
