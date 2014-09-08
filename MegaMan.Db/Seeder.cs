using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using MegaMan.Db.IDataAdapters.Interfaces;
using MegaMan.DataModels;

namespace MegaMan.Db
{
	public static class Seeder
	{
		internal static void Seed(ApplicationDbContext db, 
			bool seedVillans = true)
		{
			if (seedVillans)
			{
				db.Villans.AddOrUpdate(
					  p => p.Name,
					  new Villan { Name = "Lord Willy", Image = "http://img4.wikia.nocookie.net/__cb20140326172646/villains/images/thumb/a/a3/Lord_Wily.jpg/300px-Lord_Wily.jpg" },
					  new Villan { Name = "Dr. Wily", Image = "http://img3.wikia.nocookie.net/__cb20090330135047/villains/images/thumb/a/ac/DrWily.jpg/800px-DrWily.jpg" },
					  new Villan { Name = "Omega", Image = "http://img1.wikia.nocookie.net/__cb20100310145910/villains/images/thumb/2/23/Omega.jpg/800px-Omega.jpg" },
					  new Villan { Name = "Copy X", Image = "http://img3.wikia.nocookie.net/__cb20130607034526/villains/images/thumb/f/f5/Ultimate_Master_X.jpg/800px-Ultimate_Master_X.jpg" },
					  new Villan { Name = "Bass", Image = "http://img4.wikia.nocookie.net/__cb20131026172042/villains/images/thumb/6/63/Bass.jpg/800px-293%2C332-Bass.jpg" },
					  new Villan { Name = "Lumine", Image = "http://img1.wikia.nocookie.net/__cb20100315150722/villains/images/thumb/c/c0/Lumine.jpg/800px-Lumine.jpg" },
					  new Villan { Name = "Heat Genblen", Image = "http://img1.wikia.nocookie.net/__cb20140217081444/villains/images/thumb/c/c4/Heat_Genblen.png/800px-Heat_Genblen.png" },
					  new Villan { Name = "Tengu Man", Image = "http://img2.wikia.nocookie.net/__cb20140218215424/villains/images/thumb/6/64/Tengu_Man.png/800px-Tengu_Man.png" },
					  new Villan { Name = "Dive Man", Image = "http://img1.wikia.nocookie.net/__cb20140217043734/villains/images/thumb/d/d1/Dive-man.jpg/325px-Dive-man.jpg" },
					  new Villan { Name = "High Max", Image = "http://img3.wikia.nocookie.net/__cb20100122132527/villains/images/1/18/HighMax.jpg" });
				db.SaveChanges();
			}
		}
	}
}
