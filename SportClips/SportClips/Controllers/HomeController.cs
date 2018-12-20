using SportClips.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClips
{
    public class HomeController : Controller
    {
        private ISportClipsDAL _dal = null;

        public HomeController(ISportClipsDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IList<Store> model = _dal.GetAllStores();
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Submit(RequestOff model)
        {
            string action = "";
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            
            int numRowsAffected = _dal.AddRequestOffToDb(model);
            if (numRowsAffected > 0)
            {
                action = "CurrentRequests";
            }
            else
            {
                action = "Index";
            }

            return RedirectToAction(action);
        }

        [HttpGet]
        public ActionResult CurrentRequests()
        {
            return View("CurrentRequests");
        }


    }
}