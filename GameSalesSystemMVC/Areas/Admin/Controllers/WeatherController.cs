using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Areas.Admin.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Admin/Weather
        public async Task<ActionResult> Index()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:5179/WeatherForecast");
            //request.Headers.Add("email", "muratonal01@gmail.com");
            //request.Headers.Add("password", "27052705");
            //request.Headers.Add("isMobil", "true");

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] data = encoder.GetBytes("{\r\n  \"id\": 0,\r\n  \"name\": \"string\",\r\n  \"description\": \"string\"\r\n}");

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            
            return View();
        }
    }
}