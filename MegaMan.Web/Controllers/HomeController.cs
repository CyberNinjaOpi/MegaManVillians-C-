using MegaMan.DataModels;
using MegaMan.Db;
using MegaMan.Db.IDataAdapters.Adapters;
using MegaMan.Db.IDataAdapters.Interfaces;
using MegaMan.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaMan.Web.Controllers
{
	public class HomeController : Controller
	{
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		IMegaManAdapter _adapter;
		public HomeController()
		{
			_adapter = new MegaManAdapter();
		}
		public HomeController(IMegaManAdapter adapter)
		{
			_adapter = adapter;
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

		public ActionResult Index(string searchString, string sortOrder)
		{
			ApplicationDbContext db = new ApplicationDbContext();
			ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			var Villans = from s in db.Villans
						   select s;
			if (!String.IsNullOrEmpty(searchString))
			{
				Villans = Villans.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
			}
			switch (sortOrder)
			{
				case "name_desc":
					Villans = Villans.OrderByDescending(s => s.Name);
					break;
				default:
					Villans = Villans.OrderBy(s => s.Name);
					break;
			}
			return View(Villans.ToList());

			// THIS IS WHAT MY SEARCH LOOKED LIKE BEFORE I ADDED SORT. IT WORKED.
			//List<Villan> villans = _adapter.GetAllVillans(); 
			//var query = from Name in villans orderby Name descending select Name;
			//if (!string.IsNullOrEmpty(search))
			//{
			//	villans = villans.Where(p => p.Name.Contains(search)).ToList();
			//}
			//return View(villans);
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		public ActionResult Details(int id)
		{
			VillanDetailsVM model = new VillanDetailsVM();
			model.Villan = _adapter.GetVillan(id);
			return View(model);
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		[HttpGet]
		public ActionResult AddVillan()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddVillan(string name, string image)
		{
			Villan villan = new Villan();
			villan.Name = name;
			villan.Image = image;
			villan = _adapter.AddVillan(villan);
			return RedirectToAction("Details/" + villan.Id);
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		[HttpGet]
		public ActionResult UpdateVillan(int id)
		{
			Villan villan;
			villan = _adapter.GetVillan(id);
			return View(villan);
		}
		[HttpPost]
		public ActionResult UpdateVillan(Villan villan)
		{
			villan = _adapter.UpdateVillan(villan);
			return RedirectToAction("Details/" + villan.Id);
		}
		/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		[HttpPost]
		public ActionResult DeleteVillan(int id)
		{
			_adapter.DeleteVillan(id);
			return RedirectToAction("Index");
		}
	}
}