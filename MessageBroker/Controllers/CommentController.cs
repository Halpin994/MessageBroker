using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using MessageBroker.Models;

namespace MessageBroker.Controllers
{
  public class CommentsController : ApiController
    {
        // Mock a data store:
        private static List<CommentModel> _Db = new List<CommentModel>
            {
                new CommentModel { Id = 1, UserName = "Morpheus", Webpage = "Index", Comment = "You are the chosen one" },
            };
 
 
        public IEnumerable<CommentModel> Get()
        {
            return _Db;
        }
 
 
        public CommentModel Get(int id)
        {
            var comment = _Db.FirstOrDefault(c => c.Id == id);
            if(comment == null)
            {
                throw new HttpResponseException(
                    System.Net.HttpStatusCode.NotFound);
            }
            return comment;
        }
 
 
        public IHttpActionResult Post(CommentModel comment)
        {
            if(comment == null)
            {
                return BadRequest("Argument Null");
            }
            var commentExists = _Db.Any(c => c.Id == comment.Id);
 
            if(commentExists)
            {
                return BadRequest("Exists");
            }
 
            _Db.Add(comment);
            return Ok();
        }
 
 
        public IHttpActionResult Put(CommentModel comment)
        {
            if (comment == null)
            {
                return BadRequest("Argument Null");
            }
            var existing = _Db.FirstOrDefault(c => c.Id == comment.Id);
 
            if (existing == null)
            {
                return NotFound();
            }
 
            existing.UserName = comment.UserName;
            return Ok();
        }
 
 
        public IHttpActionResult Delete(int id)
        {
            var comment = _Db.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            _Db.Remove(comment);
            return Ok();
        }
    }
}
