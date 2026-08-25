using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Entities.Customers;
using ProductCatalog.API.Services.Interfaces;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerServices _customerServices;
    private readonly ILogger<CustomerController> _logger;
    public CustomerController(ICustomerServices customerServices, ILogger<CustomerController> logger)
    {
        _customerServices = customerServices;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Iniciando busca de todos os clientes.");
        return Ok(_customerServices.FindAll());

    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation("Iniciando busca do cliente com ID {Id}.", id);
        var customer = _customerServices.FindById(id);

        if (customer == null)
        {
            _logger.LogWarning("Cliente com ID {Id} não encontrado.", id);
            return NotFound();
        }
        _logger.LogInformation("Cliente com ID {Id} encontrado com sucesso.", id);
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        _logger.LogInformation("Iniciando cadastro de um novo cliente.");
        try
        {
            var createCustomer = _customerServices.Create(customer);
            _logger.LogInformation("Cliente cadastrado com sucesso. ID: {Id}.", customer.Id);
            return CreatedAtAction(nameof(Get),
                new { id = createCustomer.Id },
                createCustomer);

        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning("Não foi possível cadastrar o cliente. O e-mail {Email} já está cadastrado.", customer.Email);
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Customer customer)
    {
        _logger.LogInformation("Iniciando atualização do cliente com ID {Id}.", id);
        customer.Id = id;

        var updateCustomer = _customerServices.Updade(customer);

        if (updateCustomer == null)
            _logger.LogWarning("Não foi possível atualizar o cliente com ID {Id}, pois ele não foi encontrado.", id);
        return NotFound();

        _logger.LogInformation("Cliente com ID {Id} atualizado com sucesso.", id);
        return Ok(updateCustomer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _logger.LogInformation("Iniciando exclusão do cliente com ID {Id}.", id);
        var deleted = _customerServices.Delete(id);

        if (deleted == null)
        {
            _logger.LogWarning("Não foi possível excluir o cliente com ID {Id}, pois ele não foi encontrado.", id);
            return NotFound();
        }

        _logger.LogInformation("Cliente com ID {Id} excluído com sucesso.", id);
        return NoContent();
    }
}