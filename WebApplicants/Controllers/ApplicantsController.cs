//using AcmeLoans.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicants.Models;
using AcmeLoans.EFDataAccess;

namespace WebApplicants.Controllers
{
    public class ApplicantsController : Controller
    {
        // GET: Applicants
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public ActionResult GetApplicantList()
        {
            ApplicantsManager manager = new ApplicantsManager();
            List<Applicant> list = manager.GetApplicants();

            StateManager sm = new StateManager();
            List<State> stateList = sm.GetStates();

            //convert List of Applicant => List of ApplicantViewModel

            List<ApplicantViewModel> vmList = list.Select(m => new ApplicantViewModel
            {
                ApplicantId = m.ApplicantID,
                City = m.City,
                DateOfBirth = m.DateOfBirth,
                EMail = m.Email,
                FirstName = m.FirstName,
                HomePhone = m.HomePhone,
                LastName = m.LastName,
                MobilePhone = m.MobilePhone,
                SSN = m.SSN,
                StateID = m.StateId,
                StreetAddress = m.StreetAddress,
                Zip = m.Zip,
                DisplayBirthday = m.DateOfBirth.ToString("MM/dd/yyyy"),
                StateName = stateList.Where(x => x.StateID == m.StateId).FirstOrDefault().StateName
            }).ToList();

            return Json(vmList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            return View(id);
        }
        public ActionResult GetApplicantById(int id)
        {
            ApplicantsManager manager = new ApplicantsManager();
            Applicant app = manager.GetApplicantById(id);

            return Json(app, JsonRequestBehavior.AllowGet);
        }
    }
}