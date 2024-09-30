namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class PrecoController : ControllerBase
{
    private readonly PrecoRepository repository;

    public PrecoController(PrecoRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<Preco> Get()
    {
        return repository.Listar();
    }

    [HttpPost]
    public long Post([FromBody] Preco preco)
    {
        return repository.Add(preco);
    }
}