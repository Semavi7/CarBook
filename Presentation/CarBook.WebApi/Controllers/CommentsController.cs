using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentsRepository;

        public CommentsController(IGenericRepository<Comment> commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var Values = _commentsRepository.GetAll();
            return Ok(Values);
        }

        [HttpPost]
        public IActionResult CreateCommant(Comment comment)
        {
            _commentsRepository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentsRepository.GetById(id);
            _commentsRepository.Remove(value);
            return Ok("Yorum Başarı ile Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentsRepository.Update(comment);
            return Ok("Yorum Başarı ile Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentsRepository.GetById(id);
            return Ok(value);
        }

        [HttpGet("CommnetListByBlog")]
        public IActionResult CommnetListByBlog(int id)
        {
            var Values = _commentsRepository.GetCommentsByBlogId(id);
            return Ok(Values);
        }
    }
}
