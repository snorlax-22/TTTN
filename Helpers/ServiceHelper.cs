using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text.Json;

namespace TTTN.Helpers
{
    public class ServiceHelper
    {

        public static string baseURL = "http://127.0.0.1:8080/WS/";
        public static string bearerToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJEb2FuQ3VvbmdEYWkiLCJuYW1lIjoiSERWIEdyb3VwIiwiaWF0IjoyNTAxMjAyMjA5MTE3MTE5MDB9.2VaeS_V11otO0TX6P1w9eIPQQKtlNHbGfUoS55AzkGg";
        public static string contentType = "application/json";

        public static T Deserialize<T>(string json)
        {
            Newtonsoft.Json.JsonSerializer s = new Newtonsoft.Json.JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

        public HttpWebRequest initRequest(string apiCalled, string method)
        {
            //Tạo ra 1 http request + Add bearer token + add Accept Type + add contentType
            HttpWebRequest httpWebRequest = WebRequest.Create(baseURL + apiCalled) as HttpWebRequest;
            httpWebRequest.Method = method;
            httpWebRequest.Accept = contentType;

            httpWebRequest.Headers.Add("Authorization", bearerToken);
            httpWebRequest.ContentType = contentType;

            return httpWebRequest;
        }
    }
}
