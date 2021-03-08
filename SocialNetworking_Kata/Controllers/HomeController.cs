using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SocialNetworking_Kata.Data.Models;
using SocialNetworking_Kata.Data.Services;

namespace SocialNetworking_Kata.Web.Controllers
{
	public class HomeController : Controller
	{
		ISocialNetworkingKata_UserProfile db;
		ISocialNetworkingKata_Publish db1;
		ISocialNetworkingKata_Follow db2;
		public HomeController(ISocialNetworkingKata_UserProfile db, ISocialNetworkingKata_Publish db1, ISocialNetworkingKata_Follow db2)
		{
			this.db = db;
			this.db1 = db1;
			this.db2 = db2;

		}
		public ActionResult Index()
		{
			var model = db.GetAll();
			return View(model);
		}


		public ActionResult Publish(int id)
		{
			Publish publish = new Publish();
			publish.UserPublishId = id;
			return View(publish);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Publish(Publish publish, int id)
		{
			publish.UserPublishId = id;
			publish.CreatedTime = DateTime.Now;			
			if (ModelState.IsValid)
			{
				db1.Add(publish);
				return RedirectToAction("DisplayTimeLine", new { id = publish.UserPublishId });
			}
			return View();
		}

		[HttpGet]
		public ActionResult DisplayTimeLine(int id)
		{
			var model = db1.Get(id);			
			if (model == null)
				return View("NotFound");
			return View(model);
		}

		[HttpGet]
		public ActionResult User(int id = 0)
		{
			var model = db.GetAll(id);
			if (model == null)
			{
				return View();
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult UserFollower()
		{
			var model = db.GetAll();
			if (model == null)
			{
				return HttpNotFound();
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult Follows(int id)
		{
			var followid = Request.UrlReferrer.AbsoluteUri.Split('?');
			var aid = followid[1].Split('=');
			Follow follow = new Follow();
			follow.FollowId = Convert.ToInt32(aid[1]);
			follow.UserFollowId = id;
			return View(follow);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Follows(Follow follower, int id)
		{
			int redirectid = follower.FollowId;
			if (ModelState.IsValid)
			{
				db2.Add(follower);
				return RedirectToAction("DisplayTimeLine", new { id = redirectid});
			}
			return View();
		}

		[HttpGet]
		public ActionResult AddProfile()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddProfile(UserProfile userprofile)
		{
			if (ModelState.IsValid)
			{
				db.Add(userprofile);
				return RedirectToAction("UserDetails", new { id = userprofile.UserId });
			}
			return View();
		}

		[HttpGet]
		public ActionResult UserDetails(int id)
		{
			var model = db.Get(id);
			if (model == null)
			{
				return View("NotFound");
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var model = db.Get(id);
			if (model == null)
			{
				return HttpNotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(UserProfile userprofile)
		{
			if (ModelState.IsValid)
			{
				db.Update(userprofile);
				return RedirectToAction("UserDetails", new { id = userprofile.UserId });
			}
			return View(userprofile);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var model = db.Get(id);
			if (model == null)
			{
				return View("NotFound");
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, FormCollection form)
		{
			db.Delete(id);
			return RedirectToAction("Index");
		}
	}
}