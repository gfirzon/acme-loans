//using AcmeLoans.Common;
using AcmeLoans.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicants.Models;
using WebApplicants.Helpers;

namespace WebApplicants.Controllers
{
    public class ApplicationsController : Controller
    {
        // GET: Applications
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
      
        public ActionResult GetApplicationList()
        {
            LoanApplicationsManager manager = new LoanApplicationsManager();
            List<Application> list = manager.GetLoanApplications();

            LoanTypeManager loanType = new LoanTypeManager();
            List<LoanType> loanList = loanType.GetLoanTypes();

            List<ApplicationViewModel> viewList = list.Select(m => m.ToViewModel(loanList)).ToList();

            return Json(viewList, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
           
            return View(id);
        }
        public ActionResult GetApplicationById(int id)
        {
            LoanApplicationsManager manager = new LoanApplicationsManager();
            Application app = manager.GetApplicationById(id);

            return Json(app, JsonRequestBehavior.AllowGet);
        }

    }
}