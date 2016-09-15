using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rajubhaisample.Controllers
{
    public class playerController : Controller
    {
        //
        // GET: /player/
        
       

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public JsonResult insertsample(rajusample inserted)
        {
            AnalyticalEntities ane = new AnalyticalEntities();

            ane.rajusamples.Add(inserted);
            ane.SaveChanges();

            return Json(new { result = ""}, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult updatesample(rajusample inserted)
        {
            AnalyticalEntities ane = new AnalyticalEntities();

            var asd = (from actsss in ane.rajusamples.AsEnumerable() where actsss.Id == inserted.Id select actsss).FirstOrDefault();

            asd.playername = inserted.playername;
            asd.gender = inserted.gender;
            asd.dob = inserted.dob;
            asd.Status = inserted.Status;      
            ane.SaveChanges();

            return Json(new { result = ""}, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult datatable()
        {
            AnalyticalEntities ane = new AnalyticalEntities();

            List<genericclass> Act = new   List<genericclass>();

            Act = (from actsss in ane.rajusamples.AsEnumerable()                
              
                   select new genericclass
                   {
  
                       Id = actsss.Id.ToString(),
                       playername = actsss.playername,
                       gender = actsss.gender,
                       status = actsss.Status,
                       dob = actsss.dob.ToString(),
                     //  createdby = actsss.Createdby,
                     //  createdon = actsss.CreatedOn.ToString(),
                       edit = string.Empty,
                       delete = string.Empty

                   }).ToList();

            return Json(new { result = Act, JsonRequestBehavior.AllowGet });
            
        }

        [HttpPost]
        public JsonResult datatableactive()
        {
            AnalyticalEntities ane = new AnalyticalEntities();

            List<genericclass> Act = new List<genericclass>();

            Act = (from actsss in ane.rajusamples.AsEnumerable()
                   where actsss.Status.Equals("1")
                   select new genericclass
                   {

                       Id = actsss.Id.ToString(),
                       playername = actsss.playername,
                       gender = actsss.gender,
                       status = actsss.Status,
                       dob = actsss.dob.ToString(),
                       //  createdby = actsss.Createdby,
                       //  createdon = actsss.CreatedOn.ToString(),
                       edit = string.Empty,
                       delete = string.Empty

                   }).ToList();

            return Json(new { result = Act, JsonRequestBehavior.AllowGet });

        }

        [HttpPost]
        public JsonResult datatableinactive()
        {
            AnalyticalEntities ane = new AnalyticalEntities();

            List<genericclass> Act = new List<genericclass>();

            Act = (from actsss in ane.rajusamples.AsEnumerable()
                   where actsss.Status.Equals("0")
                   select new genericclass
                   {

                       Id = actsss.Id.ToString(),
                       playername = actsss.playername,
                       gender = actsss.gender,
                       status = actsss.Status,
                       dob = actsss.dob.ToString(),
                       //  createdby = actsss.Createdby,
                       //  createdon = actsss.CreatedOn.ToString(),
                       edit = string.Empty,
                       delete = string.Empty

                   }).ToList();

            return Json(new { result = Act, JsonRequestBehavior.AllowGet });

        }

    }

    public class genericclass
    {
        public string Id;
        public string playername;
        public string gender;
        public string status;
        public string dob;
        public string createdby;
        public string createdon;
        public string edit;
        public string delete;
    }
}


