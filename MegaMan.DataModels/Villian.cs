using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan.DataModels
{
	public class Villan
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public void SetProps(Villan villan)
		{
			this.Name = villan.Name;
			this.Image = villan.Image;
		}
	}
}
