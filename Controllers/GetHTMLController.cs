using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace BT2MWG.Controllers
{
    public class GetHTMLController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public string Between(string src, string findfrom, string findto)
        {
            int start = src.IndexOf(findfrom);
            int to = src.IndexOf(findto, start + findfrom.Length);
            if (start < 0 || to < 0) return "";
            string s = src.Substring(
                           start + findfrom.Length,
                           to - start - findfrom.Length);
            return s;
        }

        [HttpGet]
        public ActionResult Search()
        {
            List<string> imgString = new List<string>();
            string html = string.Empty;
            string url = "https://www.avakids.com/";
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "C# console client";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(response.CharacterSet);
                    html = reader.ReadToEnd();
                }

                string[] lines = html.Split("\r\n".ToCharArray());
                List<string> matches = new List<string>();
                foreach (string s in lines)
                {
                    if (s.Contains(".png") || s.Contains(".jpg"))
                        matches.Add(s);
                }
                foreach (var item in matches)
                {
                    if(item.Contains(".png"))
                    {
                        string valueToFind = Between(item, "cdn.tgdd", ".png\"");
                        imgString.Add("https://cdn.tgdd"+valueToFind+".png");
                    }
                    if(item.Contains(".jpg"))
                    {
                        string valueToFind = Between(item, "cdn.tgdd", ".jpg\"");
                        imgString.Add("https://cdn.tgdd" + valueToFind + ".jpg");
                    }
                    
                }

                var a = 2;
            }

            catch (ArgumentNullException)
            {
                return Json("Nothing");
            }
            string value = string.Empty;
            value = JsonConvert.SerializeObject(imgString, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }

        

    }

}

