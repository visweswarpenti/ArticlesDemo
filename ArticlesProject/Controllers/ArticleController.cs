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
	public class ArticleController : ControllerBase
	{
		IUnitOfWork _uow;
		public ArticleController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		// GET: api/<ArticleController>
		[HttpGet]
		public  ActionResult<IEnumerable<Article>> Get()
		{
			return Ok(_uow.ArticleRepo.GetAll());
		}

		// GET api/<ArticleController>/5
		[HttpGet("{id}")]
		public ActionResult<Article> Get(int id)
		{
			return _uow.ArticleRepo.Find(id);
		}

		// POST api/<ArticleController>
		[HttpPost]
		public IActionResult Post(Article article)
		{
			_uow.ArticleRepo.Add(article);
			_uow.SaveChanges();
			return Ok();
		}

		// PUT api/<ArticleController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Article value)
		{
			Article article = _uow.ArticleRepo.Find(id);
			if (article != null)
			{
				_uow.ArticleRepo.Update(value);
				_uow.SaveChanges();
			}
			
			return Ok();
		}

		// DELETE api/<ArticleController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Article article = _uow.ArticleRepo.Find(id);
			if (article != null)
			{
				_uow.ArticleRepo.DeleteById(id);
				_uow.SaveChanges();
			}

			return Ok();
		}
	}
}
