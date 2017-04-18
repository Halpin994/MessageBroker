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
                new CommentModel { Id = 1, UserName = "Morpheus", Webpage = "Index", Comment = "This...is the Index. It's our main page. We can load anything at runtime, from images...to comments...plugins...embedded youtube videos...anything we need." },
                new CommentModel { Id = 2, UserName = "Conor", Webpage = "Index", Comment = "Right now, we're inside a computer programme on an EC2 server?" },
                new CommentModel { Id = 3, UserName = "Morpheus", Webpage = "Index", Comment = "Is it really so hard to believe? Your clothes are different, the plugins on your projects and contact me page are visible, your hair is neat. Your appearance now is what we call 'very employable'. It is the mental projection of your digital self." },
                new CommentModel { Id = 4, UserName = "Darth Vader", Webpage = "Project", Comment = "Impressive, most impressive." },
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
