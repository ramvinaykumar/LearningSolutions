using ATS.EFCore.DBFirst.API.Models;
using ATS.EFCore.DBFirst.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ATS.EFCore.DBFirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private IRecruiterService _recruiterService;
        private IMapper _mapper;
        private readonly ILogger<RecruiterController> _logger;

        public RecruiterController(ILogger<RecruiterController> logger, IRecruiterService recruiterService
            , IMapper mapper)
        {
            _logger = logger;
            _recruiterService = recruiterService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _recruiterService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _recruiterService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(Recruiter model)
        {
            _recruiterService.Create(model);
            return Ok(new { message = "Recruiter data created." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Recruiter model)
        {
            _recruiterService.Update(id, model);
            return Ok(new { message = "Recruiter data updated." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recruiterService.Delete(id);
            return Ok(new { message = "Recruiter data deleted." });
        }
    }
}
