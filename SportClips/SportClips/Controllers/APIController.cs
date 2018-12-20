using SportClips.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClips
{
    public class APIController : Controller
    {
        private ISportClipsDAL _dal = null;

        public APIController(ISportClipsDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        [Route("requests")]
        public ActionResult GetAllRequests()
        {
            var requests = _dal.GetAllRequests();
            return Json(requests, JsonRequestBehavior.AllowGet);
        }
    }
}