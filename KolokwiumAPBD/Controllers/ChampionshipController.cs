using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolokwiumAPBD.Data;
using KolokwiumAPBD.DTO.Request;
using KolokwiumAPBD.Models;
using KolokwiumAPBD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumAPBD.Controllers
{
    [ApiController]
    [Route("api/championships")]
    public class ChampionshipController : ControllerBase
    {
        private readonly ChampionshipDbService _service;

        public ChampionshipController(ChampionshipDbService championshipDbService)
        {
            _service = championshipDbService;
        }
        KolokwiumDbContext _KolokwiumDbContext = new KolokwiumDbContext();
        [HttpGet("{id}")]
        public IActionResult GetTeams(int id)
        {
            GetTeamsRequest request = new GetTeamsRequest();
            request.IDChampionship = id;
            IEnumerable<Team> lista = _service.GetTeams(request);
            return Ok(lista);
        }
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("Dziala");
        }
    }
}
