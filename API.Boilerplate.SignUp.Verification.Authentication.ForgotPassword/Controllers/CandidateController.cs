using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities;
using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;
        private IMapper _mapper;
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService candidateService
            , IMapper mapper)
        {
            _logger = logger;
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _candidateService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _candidateService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(Candidate model)
        {
            _candidateService.Create(model);
            return Ok(new { message = "Candidate data created." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Candidate model)
        {
            _candidateService.Update(id, model);
            return Ok(new { message = "Candidate data updated." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _candidateService.Delete(id);
            return Ok(new { message = "Candidate data deleted." });
        }
    }
}
