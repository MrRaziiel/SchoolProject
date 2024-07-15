using Finanças.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Finanças.Controllers
{
    public class ExpensesController : Controller
    {
        // GET: Expenses
        public ActionResult Add_Expenses()
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Add_Expenses(expense new_expense, int id)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                db.expenses.Add(new_expense);
               
                return View();
            }
        }
    }
}