using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
	public class CommentNode
	{
		public Guid AncestorId { get; set; }

		public virtual Comment Ancestor { get; set; }

		public Guid OffspringId { get; set; }

		public virtual Comment Offspring { get; set; }

		public int Separation { get; set; }
	}
}
