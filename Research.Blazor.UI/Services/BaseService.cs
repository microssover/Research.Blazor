using System.Net.Http.Json;

namespace Research.Blazor.UI.Services;
public class BaseService
{
    private string _apiName;
    private HttpClient _httpClient;
    public BaseService(string apiName, HttpClient httpClient)
    {
        _apiName = apiName;
        _httpClient = httpClient;
    }

    protected async Task<TItem?> GetAsync<TItem>(string url)
    {
        var response = await _httpClient.GetAsync($"{_apiName}/{url}");
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<TItem>();
        else
            throw new Exception("an error occured while getting");
    }

    protected async Task<TItem?> PostAsync<TRequest, TItem>(string url, TRequest payload)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_apiName}/{url}", payload);
        if (response.IsSuccessStatusCode)

            return await response.Content.ReadFromJsonAsync<TItem>();
        else

            return default!;
    }

    protected async Task<TItem?> PutAsync<TRequest, TItem>(string url, TRequest payload)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_apiName}/{url}", payload);
        if (response.IsSuccessStatusCode)

            return await response.Content.ReadFromJsonAsync<TItem>();
        else

            return default!;
    }


    protected async Task<TItem?> RejectAsync<TRequest, TItem>(string url, TRequest payload)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_apiName}/{url}", payload);
        if (response.IsSuccessStatusCode)

            return await response.Content.ReadFromJsonAsync<TItem>();
        else

            return default!;
    }


    protected async Task<TItem?> DeleteAsync<TRequest, TItem>(string url)
    {
        var response = await _httpClient.DeleteAsync($"{_apiName}/{url}");
        if (response.IsSuccessStatusCode)

            return await response.Content.ReadFromJsonAsync<TItem>();
        else

            return default!;
    }
}
