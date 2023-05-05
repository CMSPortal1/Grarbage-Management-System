using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Garbage.Common;
using System.IO;

namespace Garbage.Common
{
   public class HttpHelper
    {
        // private static string url = "http://localhost:62960//api/";
        //private static readonly string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("infinity|Infin1ty"));
        //public static string Post(string methodName, object RequestBody)
        //{

        //    WebClient client = new WebClient();
        //    client.Headers[HttpRequestHeader.ContentType] = "application/json";

        //    //client.Headers.Add("credentials", credentials);
        //    //client.Headers[HttpRequestHeader.Accept] = "application/json";
        //    //client.Headers[HttpRequestHeader.ContentType] = "application/json";


        //    var obj = JsonConvert.SerializeObject(RequestBody);
        //    try
        //    {
        //        string response = client.UploadString(url + methodName, "POST", obj);
        //        if (response.Contains("ERROR:"))
        //        {

        //            int code = Convert.ToInt32(response.Replace("ERROR:", ""));

        //            //throw new APIException(code.ToString());

        //        }

        //        return response;
        //    }
        //    catch (WebException ex)
        //    {

        //        //string res = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
        //        //return ex.Message;
        //        throw new Exception(ex.Message);
        //    }




        //    //if (response.ToString().Contains("ERROR"))
        //    //{
        //    //    throw new APIException(response.ToString().Replace("ERROR:", ""));
        //    //}
        //    //JavaScriptSerializer serialize = new JavaScriptSerializer();
        //    //object responseObj = serialize.DeserializeObject(response);
        //    //return responseObj;

        //}
        public static List<T> DownloadSerializedJsonViaGET<T>(string url) where T : new()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = AppConstant.ContentType;
                    client.Headers[HttpRequestHeader.Accept] = AppConstant.ContentType;
                    //if (System.Web.HttpContext.Current.Session[SessionItemKeys.APICredentials] != null)
                    //{
                    //    client.Headers[HttpRequestHeader.Authorization] = (string)HttpContext.Current.Session[SessionItemKeys.APICredentials];
                    //}

                    string jsonData = client.DownloadString(url);
                    var response = JsonConvert.DeserializeObject<List<T>>(jsonData);
                    ResponseList<T> responseForCurrentObject = new ResponseList<T>();
                    responseForCurrentObject.data = response;
                    responseForCurrentObject.Message = "Successful Transaction";
                    return responseForCurrentObject.data;
                }
                catch (WebException exception)
                {
                    #region EXCEPTION HANDLING
                    var errorResponseText = "";
                    if (exception.Response != null)
                    {
                        var responseStream = exception.Response.GetResponseStream(); // Get API error and show as message
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                errorResponseText = reader.ReadToEnd();
                            }
                        }
                    }
                    return JsonConvert.DeserializeObject<List<T>>(errorResponseText);
                    #endregion
                }

            }
        }
        public static Response<T> DownloadSerializedJsonViaPOST<T>(string url, object data, string method = "POST") where T : new()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = AppConstant.ContentType;
                    client.Headers[HttpRequestHeader.Accept] = AppConstant.ContentType;

                    var obj = JsonConvert.SerializeObject(data);

                    string jsonData = client.UploadString(url, method, obj);
                    var response = JsonConvert.DeserializeObject<T>(jsonData);
                    Response<T> responseForCurrentObject = new Response<T>();
                    responseForCurrentObject.data = response;
                    return responseForCurrentObject;
                }
                catch (WebException exception)
                {
                    #region EXCEPTION HANDLING
                    var errorResponseText = "";
                    if (exception.Response != null)
                    {
                        var responseStream = exception.Response.GetResponseStream(); // Get API error and show as message
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                errorResponseText = reader.ReadToEnd();
                            }
                        }
                    }
                    return JsonConvert.DeserializeObject<Response<T>>(errorResponseText);
                    #endregion
                }

            }
        }


        public static Response<T> GetRequest<T>(string url, string method = "GET") where T : new()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = AppConstant.ContentType;
                    client.Headers[HttpRequestHeader.Accept] = AppConstant.ContentType;

                   // var obj = JsonConvert.SerializeObject(data);

                    string jsonData = client.DownloadString(url);
                    var response = JsonConvert.DeserializeObject<T>(jsonData);
                    Response<T> responseForCurrentObject = new Response<T>();
                    responseForCurrentObject.data = response;
                    return responseForCurrentObject;
                }
                catch (WebException exception)
                {
                    #region EXCEPTION HANDLING
                    var errorResponseText = "";
                    if (exception.Response != null)
                    {
                        var responseStream = exception.Response.GetResponseStream(); // Get API error and show as message
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                errorResponseText = reader.ReadToEnd();
                            }
                        }
                    }
                    return JsonConvert.DeserializeObject<Response<T>>(errorResponseText);
                    #endregion
                }

            }
        }
    }
}
