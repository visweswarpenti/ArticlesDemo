using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;



namespace ArticlesProject.DatabaseEntities
{
	public class User
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string ContactNo { get; set; }
	}
}
