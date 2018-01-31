using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        // GET: LuckyNumber
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };
            //now adding the instance myLuck to the set
            dbc.LuckyNumbers.Add(myLuck);
           
            //to get the last entry in the database
            int id = myLuck.LuckyNumberId;
            //may have to do casting
            Session["currentID"] = myLuck.LuckyNumberId;
            //now we have made a change so the change will take place in the datab
            dbc.SaveChanges();
            return View(myLuck);
        }

        [HttpPost]
        //parameter coming from form
        public ActionResult Spin(LuckyNumber lucky)
        {
            //is an istance coming from database
            //first is looking for1 item
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m => m.LuckyNumberId == 1).First();
                //change the balance in the database
            if(databaseLuck.Balance>0)
            {
               databaseLuck.Balance -= 1;
            }
            //update the Number in the database using the form submission value
            databaseLuck.Number = lucky.Number;
            //save to the database
            dbc.SaveChanges();

            return View(databaseLuck);
        }

        //get
        public ActionResult Index()
        {
            return View();
        }

        //Write the controller syntax to move from the Index page to the Spin after submission.
        [HttpPost]
        public ActionResult Index(LuckyNumber lucky)
        {
            return RedirectToAction("Spin");
        }

    }
}