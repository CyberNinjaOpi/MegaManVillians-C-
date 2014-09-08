using MegaMan.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan.Db.IDataAdapters.Interfaces
{
	public interface IMegaManAdapter
	{/*CRUD*/
		Villan AddVillan(Villan villan);
		List<Villan> GetAllVillans();
		Villan GetVillan(int id);
		Villan UpdateVillan(Villan villan);
		void DeleteVillan(int id);
	}
}
