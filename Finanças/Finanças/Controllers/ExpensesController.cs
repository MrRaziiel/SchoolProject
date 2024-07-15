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
                var expenses = db.type_of_expenses.ToList();
                ViewBag.Expenses = new SelectList(expenses, "name", "name");
                var fees = db.type_Of_Payment.ToList();
                ViewBag.Fees = new SelectList(fees, "idpayment", "payment");

                return View();
            }
        }

        [HttpPost]
        public ActionResult Add_Expenses(expense new_expense, int id)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                new_expense.idcli = id;
                db.expenses.Add(new_expense);
               
                return View();
            }
        }
    }
}