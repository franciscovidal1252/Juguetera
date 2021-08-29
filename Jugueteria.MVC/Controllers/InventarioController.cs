using Jugueteria.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Jugueteria.MVC.Controllers
{
    public class InventarioController : Controller
    {
        private readonly IConfiguration configuration; 
        
        
        public string urlWebApi { get; set; }
        public InventarioController(IConfiguration configuration)
        {
            this.configuration = configuration;
            urlWebApi = configuration.GetValue<string>("urlWebApi");
        }

        public async Task<IActionResult> Index()
        {
            WebRequest webRequest = WebRequest.Create(urlWebApi + "inventario");
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            List<Inventario> lst =
                JsonConvert.DeserializeObject<List<Inventario>>(await sr.ReadToEndAsync());
            return View(lst);
        }

        public IActionResult ModalPopUp()
        {
            return View();
        }

        public ActionResult borrarArticulo(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlWebApi);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Inventario/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult editarArticulo(int id)
        {
            Inventario inventario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlWebApi);
                //HTTP GET
                var responseTask = client.GetAsync("Inventario/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Inventario>();
                    readTask.Wait();

                    inventario = readTask.Result;
                }
            }
            return Json(inventario);
        }

        
        public ActionResult guardarArticuloEditado(Inventario inventario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlWebApi);

                var request = new StringContent(JsonConvert.SerializeObject(inventario),Encoding.UTF8,"application/json");

                //HTTP POST
                var putTask = client.PutAsync("Inventario/", request);
                putTask.Wait();
                //HTTP POST

                //var putTask = client.PutAsJsonAsync<Inventario>("inventario", inventario);
                //putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult guardarArticulo(Inventario inventario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlWebApi);

                var request = new StringContent(JsonConvert.SerializeObject(inventario), Encoding.UTF8, "application/json");

                //HTTP POST
                var putTask = client.PostAsync("Inventario/", request);
                putTask.Wait();
                //HTTP POST

                //var putTask = client.PutAsJsonAsync<Inventario>("inventario", inventario);
                //putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
