using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papasi.Models
{
	public class Provider
	{
		public string? name { get; set; }
		public string? url { get; set; }
		public string? logo { get; set; }
		public string? contact { get; set; }
		public bool isOnline { get; set; }
	}
}
