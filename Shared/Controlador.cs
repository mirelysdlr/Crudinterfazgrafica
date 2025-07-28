using JoyeriaApp.Server.Services;
using JoyeriaApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace JoyeriaApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JoyasController : ControllerBase
{
    private readonly IJoyaService _service;

    public JoyasController(IJoyaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var joya = await _service.GetById(id);
        return joya == null ? NotFound() : Ok(joya);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Joya joya) => Ok(await _service.Create(joya));

    [HttpPut]
    public async Task<IActionResult> Put(Joya joya)
    {
        var updated = await _service.Update(joya);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.Delete(id);
        return deleted ? Ok() : NotFound();
    }
}

