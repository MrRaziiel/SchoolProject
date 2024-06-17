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
                LoadFile();
            }

            public void SaveFile()
            {
                HttpServerUtility server = HttpContext.Current.Server;
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Client>));
                FileStream fs = new FileStream(server.MapPath("~/App_Data/dados.json"), FileMode.Create, FileAccess.Write);
                js.WriteObject(fs, clients);
                fs.Close();
            }


            public void LoadFile()
            {
                HttpServerUtility server = HttpContext.Current.Server;
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Client>));
                string path = server.MapPath("~/App_Data/dados.json");
                if (System.IO.File.Exists(path))
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
            //void createList()
            //{
            //    clients = new List<Client>() {
            //      new Client(){ Id=1,Name="Ruben Amaro", Role = "Admin"},
            //      new Client(){ Id=2,Name="Anabela", Role = "Mom"},
            //      new Client(){ Id=3,Name="Carlos", Role = "Dad"}
            //    };
            //}

    }
}
