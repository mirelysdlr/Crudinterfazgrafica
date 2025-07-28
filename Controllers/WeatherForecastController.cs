using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class JoyasController : ControllerBase
{
    private readonly IJoyaService _service;
    public JoyasController(IJoyaService service) => _service = service;

    [HttpGet] public async Task<IActionResult> Get() => Ok(await _service.GetAll());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetById(id));
    [HttpPost] public async Task<IActionResult> Post([FromBody] Joya joya) => Ok(await _service.Create(joya));
    [HttpPut] public async Task<IActionResult> Put([FromBody] Joya joya) => Ok(await _service.Update(joya));
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) => Ok(await _service.Delete(id));
}

