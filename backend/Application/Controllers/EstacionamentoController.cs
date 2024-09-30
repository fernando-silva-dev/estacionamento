namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class EstacionamentoController : ControllerBase
{
    private readonly EstacionamentoRepository repository;

    public EstacionamentoController(EstacionamentoRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<Estacionamento> Get()
    {
        return repository.Listar();
    }

    [HttpPost]
    public long Post([FromBody] Estacionamento estacionamento)
    {
        return repository.Add(estacionamento);
    }

    [HttpPatch("{id}")]
    public void Patch([FromRoute] long id, [FromBody] DateTime saida)
    {
        repository.MarcarSaida(id, saida);
    }
}