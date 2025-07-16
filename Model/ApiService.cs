using RestSharp;
using Newtonsoft.Json;
using System.Net;

public class ApiService
{
    private RestClient _client;
    private RestResponse _response;

    public void InitializeCmeClient(string startDate, string endDate, string apiKey)
    {
        string url = $"https://api.nasa.gov/DONKI/CME?startDate={startDate}&endDate={endDate}&api_key={apiKey}";
        _client = new RestClient(url);
    }

    public void InitializeFlrClient(string startDate, string endDate, string apiKey)
    {
        string url = $"https://api.nasa.gov/DONKI/FLR?startDate={startDate}&endDate={endDate}&api_key={apiKey}";
        _client = new RestClient(url);
    }


    public async Task SendRequestAsync()
    {
        var request = new RestRequest();
        request.Method = Method.Get; 

        _response = await _client.ExecuteAsync(request);
    }

    public HttpStatusCode GetStatusCode()
    {
        return _response.StatusCode;
    }

    public bool HasNonEmptyResults()
    {
        var content = JsonConvert.DeserializeObject<List<object>>(_response.Content);
        return content.Count > 0;
    }

 


    public void Dispose()
    {
        _client = null;
        _response = null;
       
    }
}
