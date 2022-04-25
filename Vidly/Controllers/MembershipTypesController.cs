using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModels;

using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MembershipTypesController : Controller
    {
        // GET: MembershipTypes
        public ActionResult Index()
        {
            return View();
        }


        private MyDbContext dbContext;

        public MembershipTypesController()
        {
            dbContext = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }


        public ViewResult ListMembershipTypes()
        {
            var membershipTypesDBRecords = dbContext.membershipTypeDB;

            if (membershipTypesDBRecords == null) return View("NO DATA");

            return View(membershipTypesDBRecords);
        }


        //VIEW FOR FORM
        public ViewResult AddMembershipType()
        {
            return View();
        }


        //ACTION FOUND IN VIEW FOR FORM. USED FOR FORM OPERATIONS
        [HttpPost]
        public ActionResult CreateMembershipType(MembershipType membershiptype)
        {

            var a = membershiptype.MembershipName;
            var b = membershiptype.RegistrationFee;
            var c = membershiptype.SubscriptionDuration;
            var d = membershiptype.DiscountRate;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine();

            //dbContext.membershipTypeDB.Add(membershiptype);
            //dbContext.SaveChanges();

            //Once the data has been sent to the database for update,
            //return to the View listing all Membership Types
            return RedirectToAction("ListMembershipTypes", "MembershipTypes");
            

        }



    }
}