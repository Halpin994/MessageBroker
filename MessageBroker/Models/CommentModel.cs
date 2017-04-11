using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Webpage { get; set; }
        public string Comment { get; set; }
    }
}
