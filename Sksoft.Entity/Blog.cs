using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sksoft.Entity
{
	public class Blog : BaseEntity
	{
		public int ID { get; set; }

		public int OkunmaSayisi { get; set; }

		public DateTime Tarih { get; set; }
	}
}
