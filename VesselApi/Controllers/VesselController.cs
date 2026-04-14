using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VesselApi.Data;
using VesselApi.Models;

namespace VesselApi.Controllers;

[ApiController]
[Route("api/vessel")]
public class VesselController : ControllerBase
{
    private readonly MaritimeDbContext _context;
    public VesselController(MaritimeDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vessel>>> GetAll() => Ok(await _context.Vessels.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Vessel>> GetById(int id)
    {
        var vessel = await _context.Vessels.FindAsync(id);

        if(vessel is null)
        {
            return NotFound();
        }

        return Ok(vessel);
    }

    [HttpPost]
    public async Task<ActionResult<Vessel>> Create(Vessel vessel)
    {
        _context.Vessels.Add(vessel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = vessel.Id }, vessel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Vessel vessel)
    {
        if (id != vessel.Id)
        {
            return BadRequest();
        }

        _context.Entry(vessel).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vessel = await _context.Vessels.FindAsync(id);

        if(vessel is null)
        {
            return NotFound();
        }

        _context.Vessels.Remove(vessel);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}