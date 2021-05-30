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
	public class ReplyController : ControllerBase
	{
		IUnitOfWork _uow;
		public ReplyController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		// GET: api/<ReplyController>
		[HttpGet]
		public  ActionResult<IEnumerable<Reply>> Get()
		{
			return Ok(_uow.ReplyRepo.GetReplyList());
		}

		// GET api/<ReplyController>/5
		[HttpGet("{id}")]
		public ActionResult<Reply> Get(int id)
		{
			return _uow.ReplyRepo.Find(id);
		}

		// POST api/<ReplyController>
		[HttpPost]
		public IActionResult Post(Reply Reply)
		{
			_uow.ReplyRepo.Add(Reply);
			_uow.SaveChanges();
			return Ok();
		}

		// PUT api/<ReplyController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Reply value)
		{
			Reply Reply = _uow.ReplyRepo.Find(id);
			if (Reply != null)
			{
				_uow.ReplyRepo.Update(value);
				_uow.SaveChanges();
			}
			
			return Ok();
		}

		// DELETE api/<ReplyController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Reply Reply = _uow.ReplyRepo.Find(id);
			if (Reply != null)
			{
				_uow.ReplyRepo.DeleteById(id);
				_uow.SaveChanges();
			}

			return Ok();
		}
	}
}
