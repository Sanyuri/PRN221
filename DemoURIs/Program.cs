// See https://aka.ms/new-console-template for more information
using System.Net;

internal class Program
{
    //private static void Main(string[] args)
    //{
    //    Uri info = new Uri("https://www.domain.com:80/info?id=123#fragment");
    //    Uri page = new Uri("https://www.domain.com:80/info/page.html");
    //    Console.WriteLine($"Host: {info.Host}");
    //    Console.WriteLine($"Port: {info.Port}");
    //    Console.WriteLine($"PathAndQuery: {info.PathAndQuery}");
    //    Console.WriteLine($"Query: {info.Query}");
    //    Console.WriteLine($"Fragment: {info.Fragment}");
    //    Console.WriteLine($"Default HTTP port: {page.Host}");
    //    Console.WriteLine($"IsBaseOf: {info.IsBaseOf(page)}");
    //    Uri relative = info.MakeRelativeUri(page);
    //    Console.WriteLine($"IsAbsoluteUri: {relative.IsAbsoluteUri}");
    //    Console.WriteLine($"RelativeUri: {relative.ToString()}");
    //}

    //static readonly HttpClient client = new HttpClient();
    //static async Task Main()
    //{
    //    string uri = "http://www.contoso.com";
    //    try
    //    {
    //        HttpResponseMessage response = await client.GetAsync(uri);
    //        response.EnsureSuccessStatusCode();
    //        string responseBody = await response.Content.ReadAsStringAsync();
    //        Console.WriteLine(responseBody);
    //    }
    //    catch (HttpRequestException e)
    //    {
    //        Console.WriteLine("\nException Caught!");
    //        Console.WriteLine("Message :{0} ", e.Message);
    //    }
    //}

    //WebRequest & WebResponse
    static void Main(string[] args)
    {
        WebRequest request = WebRequest.Create("http://www.contoso.com/default.html");
        request.Credentials = CredentialCache.DefaultCredentials;

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
 
        Console.WriteLine("Status: "+response.StatusDescription);
        Console.WriteLine(new string('*', 50));
 
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        
        string responseFromServer = reader.ReadToEnd();
        
        Console.WriteLine(responseFromServer);
        Console.WriteLine(new string('*', 50));
        reader.Close();
        dataStream.Close();
        response.Close();
    }
}