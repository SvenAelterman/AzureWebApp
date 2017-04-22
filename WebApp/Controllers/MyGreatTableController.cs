using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class MyGreatTableController : Controller
	{
		// GET: MyGreatTable
		public ActionResult Index()
		{
			using (MyDbContext context = new MyDbContext())
			{
				return View(context.MyGreatTables.ToList());
			}
		}

		// GET: MyGreatTable/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: MyGreatTable/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: MyGreatTable/Create
		[HttpPost]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(MyGreatTable model)
		{
			if (ModelState.IsValid)
				try
				{
					using (MyDbContext context = new MyDbContext())
					{
						context.MyGreatTables.Add(model);
						context.SaveChanges();
					}

					return RedirectToAction("Index");
				}
				catch
				{
					return View();
				}
			else
				return View(model);
		}

		// GET: MyGreatTable/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: MyGreatTable/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, MyGreatTable model)
		{
			try
			{
				// TODO: Add edit logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View(model);
			}
		}

		// GET: MyGreatTable/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: MyGreatTable/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
