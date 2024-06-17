using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;



namespace ProjectoTecnologiasDaInternet3.Models
{
        public class BD
        {
            public List<Client> clients;

            public BD()
            {
            LoadFileClient();
            }

            public void SaveFileClient()
            {
                HttpServerUtility server = HttpContext.Current.Server;
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Client>));
                FileStream fs = new FileStream(server.MapPath("~/App_Data/Clientes.json"), FileMode.Create, FileAccess.Write);
                js.WriteObject(fs, clients);
                fs.Close();
            }


            public void LoadFileClient()
            {
                HttpServerUtility server = HttpContext.Current.Server;
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Client>));
                string path = server.MapPath("~/App_Data/Clientes.json");
                if (System.IO.File.Exists(path) && (new FileInfo(path).Length != 0))
                {
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    clients = (List<Client>)js.ReadObject(fs);
                    fs.Close();
                }
                else
                {
                    clients = new List<Client>();
                }


            }

            public void RemoveClient(int? id)
            {
            var client = clients.Where(c => c.Id == id).FirstOrDefault();
            if (client != null) 
            {
                clients.Remove(client);
                SaveFileClient();
            }
            

        }



        }
}
