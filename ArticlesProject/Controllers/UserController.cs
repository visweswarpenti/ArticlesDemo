using ArticlesProject.DatabaseEntities;
using ArticlesProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArticlesProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IUnitOfWork _uow;
		public UserController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		// GET: api/<UserController>
		[HttpGet]
		public  ActionResult<IEnumerable<User>> Get()
		{
			var data  = _uow.UserRepo.GetAll();
			return Ok(data);
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public ActionResult<User> Get(int id)
		{
			return _uow.UserRepo.Find(id);
		}

		// POST api/<UserController>
		[HttpPost]
		public IActionResult Post(User article)
		{
			_uow.UserRepo.Add(article);
			_uow.SaveChanges();
			return Ok();
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] User value)
		{
			User article = _uow.UserRepo.Find(id);
			if (article != null)
			{
				_uow.UserRepo.Update(value);
				_uow.SaveChanges();
			}
			
			return Ok();
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			User article = _uow.UserRepo.Find(id);
			if (article != null)
			{
				_uow.UserRepo.DeleteById(id);
				_uow.SaveChanges();
			}

			return Ok();
		}

		[HttpGet("/UsersWhoNeverReplied")]
		public ActionResult<IEnumerable<User>> UsersWhoNeverReplied()
		{
			return Ok(_uow.UserRepo.UsersWhoNeverReplied());
		}

		[HttpGet("/UsersWhoRepliedAlteastOnce")]
		public ActionResult<IEnumerable<User>> UsersWhoRepliedAlteastOnce()
		{
			return Ok(_uow.UserRepo.UsersWhoRepliedAlteastOnce());
		}
	}
}
