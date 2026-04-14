using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using VesselApi.Models;

namespace VesselApi.Controllers;

[ApiController]
[Route("api/vessel")]
public class VesselController : ControllerBase
{
    private static readonly List<Vessel> _vessels = new()
    {
        new Vessel { Id = 1, Name = "Poseidon", MMSI = "123456789", 
                     Latitude = 37.9838, Longitude = 23.7275, LastUpdated = DateTime.UtcNow }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Vessel>> GetAll() => Ok(_vessels);

    [HttpGet("{id}")]
    public ActionResult<Vessel> GetById(int id)
    {
        var vessel = _vessels.FirstOrDefault(v => v.Id == id);

        if(vessel is null)
        { 
            return NotFound();
        }

        return Ok(vessel);
    }
}