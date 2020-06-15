using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDBlab03.DTO;
using AngularDBlab03.Models;
using AngularDBlab03.Repository;
using AngularDBlab03.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularDBlab03.Controllers
{
    [Route("club")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepozitory clubRepozitory;
        private readonly IClubService clubService;
        public ClubController(IClubRepozitory _clubRepozitory, IClubService _clubService)
        {
        clubRepozitory = _clubRepozitory;
        clubService = _clubService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateClub(ClubPostDTO clubToAdd)
        {
            try
            {
                var guid = await clubRepozitory.addClub(clubToAdd);
                return guid == Guid.Empty ? (IActionResult)StatusCode(500) : Ok(guid);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("all")]
        public async Task<IActionResult> getAllClub()
        {
            var clubs = await clubRepozitory.getAllClubs();
            return Ok(clubs.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getClubById(Guid id)
        {
            var club = await clubRepozitory.getClubById(id);
            return Ok(club);
        }
        [HttpPut]
        public async Task<IActionResult> updateClub(Club club)
        {

            var _club = await clubService.updateClub(club);
            return Ok(_club);

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClub(Guid id)
        {
            var club = clubService.deleteByClubId(id);
            return Ok(club);
        }
        /*

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
