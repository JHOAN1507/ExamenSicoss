using Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ListasCitas = GetItemsAPI();
            return View(ListasCitas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Cita> GetItemsAPI()
        {
            List<Cita> result = new List<Cita>();
            var url = "https://localhost:44344/api/Citas";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return result;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            result = JsonConvert.DeserializeObject<List<Cita>>(responseBody);
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {

            }

            return result;
        }
        private void PostItem(string data)
        {
            var url = $"https://localhost:44344/api/Citas";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        public ActionResult Crear()
        {
            ViewBag.Medicos = new HelperData().GetMedico();
            ViewBag.Pacientes = new HelperData().GetPaciente();
            ViewBag.Especialidad = new HelperData().GetEspecialidad();

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cita citas)
        {

            PostItem(JsonConvert.SerializeObject(citas));
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            var Citasid = new HelperData().GetCita(id);
            ViewBag.Medicos = new HelperData().GetMedico();
            ViewBag.Pacientes = new HelperData().GetPaciente();
            ViewBag.Especialidad = new HelperData().GetEspecialidad();



            return View(Citasid);
        }

        [HttpPost]
        public ActionResult Editar(int id, Cita citas)
        {
            citas.IdCita = id;
            PostActualizar(id, JsonConvert.SerializeObject(citas));
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            var Citasid = new HelperData().GetCitaLazy(id);
        
            return View(Citasid);
        }

        [HttpGet]

        public ActionResult Eliminar(int id, Cita citas)
        {
            PostEliminar(id, JsonConvert.SerializeObject(citas));
            return RedirectToAction("Index");
        }

        private void PostActualizar(int id, String data)
        {

            var url = $"https://localhost:44344/api/Citas/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

        }
        private void PostEliminar(int id, string data)
        {

            var url = $"https://localhost:44344/api/Citas/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        public ActionResult CrearPaciente()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult CrearPaciente(Paciente paciente)
        {

            new HelperData().InsertPaciente(paciente);
            return RedirectToAction("Index");
        }
        public ActionResult CrearMedico()
        {
           
            ViewBag.Especialidad = new HelperData().GetEspecialidad();

            return View();
        }
        [HttpPost]
        public ActionResult CrearMedico(Medico medico)
        {

            new HelperData().InsertMedico(medico);
            return RedirectToAction("Index");
        }

        public ActionResult CrearEspe()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CrearEspe(Especialidad especialidad)
        {

            new HelperData().InsertEspecialidades(especialidad);
            return RedirectToAction("Index");
        }
    }
}