using JoyeriaApp.Server.Services;
using JoyeriaApp.Shared;
using joyeriafront.Shared;
using System.Net.Http.Json;

public class JoyaService : IJoyaService
{
    private readonly HttpClient _http;
    private const string url = "https://localhost:7274/api/Joyas";

    public JoyaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Joya>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Joya>>(url) ?? new List<Joya>();
    }

    public async Task<Joya?> GetById(int id)
    {
        return await _http.GetFromJsonAsync<Joya>($"{url}/{id}");
    }

    public async Task<Joya?> Create(Joya joya)
    {
        var response = await _http.PostAsJsonAsync(url, joya);
        return await response.Content.ReadFromJsonAsync<Joya>();
    }

    public async Task<Joya?> Update(Joya joya)
    {
        var response = await _http.PutAsJsonAsync(url, joya);
        return await response.Content.ReadFromJsonAsync<Joya>();
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"{url}/{id}");
    }
}

