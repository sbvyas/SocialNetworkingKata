using SocialNetworking_Kata.Data.Services;
using System.Web.Mvc;
using SocialNetworking_Kata.Data.Models;


namespace SocialNetworking_Kata.Web.Controllers
{
	public class SocialNetworkingKataController : Controller
	{
		private ISocialNetworkingKata_UserProfile db;

		public SocialNetworkingKataController(ISocialNetworkingKata_UserProfile db)
		{
			this.db = db;
		}
		public ActionResult Index()
		{
			var model = db.GetAll();
			return View(model);					}

      [HttpGet]
      public ActionResult Details(int id)
      {
         var model = db.Get(id);
         if (model == null)
         {
            //return RedirectToAction("Index");
            return View("NotFound");
         }
         return View(model);
      }

      [HttpGet]
      public ActionResult Create()
      {
         return View();
      }
   }
}
