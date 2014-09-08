using MegaMan.DataModels;
using MegaMan.Db.IDataAdapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan.Db.IDataAdapters.Adapters
{
	public class MegaManAdapter : IMegaManAdapter
	{
		public List<Villan> GetAllVillans()
		{
			List<Villan> villans;
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				villans = db.Villans.OrderBy(x => x.Name).ToList();
			}
			return villans;
		}
		public Villan GetVillan(int id)
		{
			Villan villan;
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				villan = db.Villans.Where(x => x.Id == id).FirstOrDefault();
			}
			return villan;
		}
		public Villan AddVillan(Villan villan)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				villan = db.Villans.Add(villan);
				db.SaveChanges();
			}
			return villan;
		}
		public Villan UpdateVillan(Villan villan)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				Villan oldvillan = db.Villans.Find(villan.Id);
				oldvillan.SetProps(villan);
				db.SaveChanges();
			}
			return villan;
		}
		public void DeleteVillan(int id)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				Villan villan = db.Villans.Find(id);
				db.Villans.Remove(villan);
				db.SaveChanges();
			}
		}
	}
}
