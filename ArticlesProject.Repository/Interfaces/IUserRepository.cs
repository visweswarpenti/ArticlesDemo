using ArticlesProject.DatabaseEntities;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesProject.Repository.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		IEnumerable<User> UsersWhoNeverReplied();
		IEnumerable<User> UsersWhoRepliedAlteastOnce();
	}
}
