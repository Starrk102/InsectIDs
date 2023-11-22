using System;
using System.Text;
using System.Threading.Tasks;
using BestHTTP;
using Newtonsoft.Json;

public static class WebRequestSender
{
    private static string URL = "https://insect.kindwise.com/api/v1/";
    
    private static HTTPRequest HttpRequest<T>(string name, HTTPMethods methods, T data = default)
    {
        HTTPRequest request = new HTTPRequest(new Uri(URL + name), methods);
        request.SetHeader("Content-Type", "application/json; charset=UTF-8");
        request.AddHeader("Api-Key", "NJ21RCaOIhpYYRdMZclBNIybF371Kuh0d2KgbeYH92aUftOvRM");
        
        if (data != null)
        {
            request.RawData =  Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }
        
        request.Send();
            
        return request;
    }

    public static async void Identification(ImagesClass data, Action<HTTPResponse> onResult)
    {
        var request = HttpRequest<ImagesClass>("identification?details=common_names,url,description,image", HTTPMethods.Post, data);
        
        var result = await request.GetHTTPResponseAsync();
        
        onResult.Invoke(result);
    }
}
