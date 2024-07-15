using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finanças.Models;

namespace Finanças.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult List_of_clients(string msg)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                ViewBag.msg = msg;
                List<v_clients> clients = db.v_clients.ToList();
                return View(clients);

            }
        }

        public ActionResult Add_client()
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                string[] roles = new string[] { "Admin", "Dad", "Mom" };
                ViewBag.roles = new SelectList(roles);
                return View();
            }
        }
        [HttpPost]
        public ActionResult Add_client(client newclient, HttpPostedFileBase fich)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                if (ModelState.IsValid)
                {

                    // Save the new client to the database
                    db.clients.Add(newclient);
                    db.SaveChanges();

                    if (fich != null && fich.FileName.Length > 0 && fich.ContentType.Contains("image"))
                    {
                        string path = Server.MapPath("~/Photos/");
                        string filepath = newclient.idcli.ToString() + System.IO.Path.GetExtension(fich.FileName);
                        newclient.fotopath = filepath;
                        path = System.IO.Path.Combine(path, filepath);
                        fich.SaveAs(path);

                        // Update the client with the file path
                        db.Entry(newclient).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("List_of_clients", "Clients", new { msg = "Insert new client" });
            }
            return View(newclient);
        }
        }

        public ActionResult Edit_client(int? id)
        {

            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                string[] roles = new string[] { "Admin", "Dad", "Mom" };
                ViewBag.roles = new SelectList(roles);
                client client_to_edit = db.clients.Find(id);
                if (client_to_edit != null) return View(client_to_edit);
                return new EmptyResult();
            }


        }
        [HttpPost]
        public ActionResult Edit_client(client editClient, HttpPostedFileBase fich)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                client client_to_edited = db.clients.Find(editClient.idcli);
                if (client_to_edited != null)
                {
                    // Handle the file upload if a new file is provided
                    if (fich != null && fich.FileName.Length > 0 && fich.ContentType.Contains("image"))
                    {
                        string path = Server.MapPath("~/Photos/");
                        string filepath = editClient.idcli.ToString() + System.IO.Path.GetExtension(fich.FileName);
                        client_to_edited.fotopath = filepath;
                        path = System.IO.Path.Combine(path, filepath);
                        fich.SaveAs(path);
                    }
                    var editClientProperties = typeof(client).GetProperties();
                    foreach (var property in editClientProperties)
                    {
                        
                        if (property.Name == "fotopath")
                            continue;

                        var newValue = property.GetValue(editClient);
                        property.SetValue(client_to_edited, newValue);
                    }

                    // Save the changes to the database
                    db.Entry(client_to_edited).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Detail_client", "Clients", new { id = editClient.idcli });
            }
        }

        public ActionResult Detail_client(int? id)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {
                client detail_client = db.clients.Find(id);
                if (detail_client != null) return View(detail_client);
                return RedirectToAction("List_of_clients", "Clients", new { msg = "No client found" });
            }
        }
        public ActionResult Delete_client(int? id)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {

                try
                {
                    client death_client = db.clients.Find(id);
                    if (death_client != null)
                    {
                        db.clients.Remove(death_client);
                        db.SaveChanges();
                        return Json(new { msg = "ok" }, JsonRequestBehavior.AllowGet);
                    }
                    else return Json(new { msg = "erro" }, JsonRequestBehavior.AllowGet);
                }
                catch (SqlException erro)
                {
                    return Json(new { msg = erro.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }


        public ActionResult List_of_expenses_to_client(int? id)
        {
            using (clientesBDEntities3 db = new clientesBDEntities3())
            {

                IEnumerable<v_expense> clientes = db.v_expense.Where(x => x.idcli == id).ToList();
               
                return PartialView(clientes);
            }
        }
    }
}