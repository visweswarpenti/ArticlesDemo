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
	public class CommentController : ControllerBase
	{
		IUnitOfWork _uow;
		public CommentController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		// GET: api/<CommentController>
		[HttpGet]
		public  ActionResult<IEnumerable<Comment>> Get()
		{
			return Ok(_uow.CommentRepo.GetAll());
		}

		// GET api/<CommentController>/5
		[HttpGet("{id}")]
		public ActionResult<Comment> Get(int id)
		{
			return _uow.CommentRepo.Find(id);
		}

		// POST api/<CommentController>
		[HttpPost]
		public IActionResult Post(Comment comment)
		{
			_uow.CommentRepo.Add(comment);
			_uow.SaveChanges();
			return Ok();
		}

		// PUT api/<CommentController>/5
		[HttpPut("{id}")]
		public ActionResult<Comment> Put(int id, [FromBody] Comment value)
		{
			Comment article = _uow.CommentRepo.Find(id);
			if (article != null)
			{
				_uow.CommentRepo.Update(value);
				_uow.SaveChanges();
			}
			
			return Ok(value);
		}

		// DELETE api/<CommentController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Comment article = _uow.CommentRepo.Find(id);
			if (article != null)
			{
				_uow.CommentRepo.DeleteById(id);
				_uow.SaveChanges();
			}

			return Ok();
		}
	}
}
