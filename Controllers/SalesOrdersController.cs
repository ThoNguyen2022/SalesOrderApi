using Microsoft.AspNetCore.Mvc;

using SalesOrderApi.Models;
using SalesOrderApi.Services;

namespace SalesOrderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesOrdersController : ControllerBase
{
    private readonly SalesOrderService _service;

    public SalesOrdersController(SalesOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<SalesOrder>>> Get()
    {
        var a = await _service.GetAllAsync();
        return a;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesOrder>> GetById(int id)
    {
        var order = await _service.GetByIdAsync(id);
        return order is null ? NotFound() : order;
    }

    [HttpPost]
    public async Task<ActionResult<SalesOrder>> Create(SalesOrder order)
    {
        var created = await _service.CreateAsync(order);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}
