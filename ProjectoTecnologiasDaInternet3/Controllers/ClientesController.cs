using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ProjectoTecnologiasDaInternet3.Models;

namespace ProjectoTecnologiasDaInternet3.Controllers
{

    public class ClientesController : Controller
    {
        BD bd = new BD();
        public ActionResult AddClient()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddClient(Client novo)
        {
            int id = (bd.clients.Count() > 0) ? bd.clients.Max(x => x.Id) + 1 : 1;
            novo.Id = id;
            if (ModelState.IsValid)
            {

                bd.clients.Add(novo);
                bd.SaveFile();
                return RedirectToAction("Clients", "Clientes", new { msg = "Registo Inserido com sucesso" });
            }
            else
            {
                return View(novo);
            }
        }

        public ActionResult DeleteAjax(int? id)
        {
            List<Client> clients = bd.clients.ToList();
            Client droped = clients.Find(x => x.Id == (id ?? -1));
            if (droped != null)
            {
                bd.clients.Remove(droped);
                bd.SaveFile();
                return Json(new { msg = "ok" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "erro" }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult Clients()
        {
            List<Client> clients = bd.clients;
            return View(clients.ToList());
        }


        

        public ActionResult Client(String msg)
        {
            ViewBag.msg = msg;
            List<Client> client = bd.clients;
            return View(client);
        }


        [HttpGet]
        public ActionResult EditClient(int? id)
        {

            var std = bd.clients.Where(c => c.Id == id).FirstOrDefault();

            return View(std);
        }
        
        public ActionResult EditClient(Client std)
        {
            List<Client> clients = bd.clients;
            var client = bd.clients.Where(c => c.Id == std.Id).FirstOrDefault();
            clients.Remove(client);

            return RedirectToAction("Index");
        }

    }
}