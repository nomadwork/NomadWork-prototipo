using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NomadWork.Api.Context;
using NomadWork.Api.Models;
using NomadWork.Inputs.Api;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NomadWork.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EstablishmmentController : ControllerBase
    {
        private readonly NomadWorkDbContext _context;

        public EstablishmmentController(NomadWorkDbContext context)
        {
            _context = context;
        }

        // GET: api/Establishmment
        [HttpGet, Route("/all")]
        public async Task<ActionResult<IEnumerable<EstablishmmentModel>>> GetEstablishmment()
        {
            return await _context
                                .Establishmment
                                .Include(x => x.Owner)
                                .Include(x => x.Address)
                                .Include(x => x.Characteristics)
                                .ToListAsync();
        }

         // GET: api/Establishmment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstablishmmentModel>>> GetEstablishmmentNearBy(GeoLocation geolocation)
        {
            var setPrecision = new NumberFormatInfo
            {
                NumberDecimalDigits = 3
            };

            return await _context
                                .Establishmment
                                .Include(x => x.Owner)
                                .Include(x => x.Address)
                                .Include(x => x.Characteristics)
                                .Where(x => x.Address.Latitude
                                                     .ToString(setPrecision)
                                                     .Equals(geolocation
                                                                .Latitude
                                                                .ToString(setPrecision)) 
                                          && x.Address.Longitude
                                                    .ToString(setPrecision)
                                                    .Equals(geolocation
                                                                .Longitude
                                                                .ToString(setPrecision)))
                                .ToListAsync();
        }

        // GET: api/Establishmment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstablishmmentModel>> GetEstablishmmentModel(string id)
        {
            var establishmmentModel = await _context.Establishmment.FindAsync(id);

            if (establishmmentModel == null)
            {
                return NotFound();
            }

            return establishmmentModel;
        }

        // POST: api/Establishmment
        [HttpPost]
        public async Task<ActionResult<EstablishmmentModel>> PostEstablishmmentModel(EstablishmmentModel establishmmentModel)
        {
            _context.Establishmment.Add(establishmmentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstablishmmentModelExists(establishmmentModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstablishmmentModel", new { id = establishmmentModel.Id }, establishmmentModel);
        }

        //// PUT: api/Establishmment/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEstablishmmentModel(string id, EstablishmmentModel establishmmentModel)
        //{
        //    if (id != establishmmentModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(establishmmentModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EstablishmmentModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //// DELETE: api/Establishmment/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<EstablishmmentModel>> DeleteEstablishmmentModel(string id)
        //{
        //    var establishmmentModel = await _context.Establishmment.FindAsync(id);
        //    if (establishmmentModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Establishmment.Remove(establishmmentModel);
        //    await _context.SaveChangesAsync();

        //    return establishmmentModel;
        //}

        private bool EstablishmmentModelExists(string id)
        {
            return _context.Establishmment.Any(e => e.Id == id);
        }
    }
}
