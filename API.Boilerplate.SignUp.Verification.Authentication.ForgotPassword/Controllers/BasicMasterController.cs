using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities;
using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicMasterController : ControllerBase
    {
        private IMasterTableService _masterTableService;
        private IMapper _mapper;
        private readonly ILogger<BasicMasterController> _logger;

        public BasicMasterController(ILogger<BasicMasterController> logger, IMasterTableService masterTableService
            , IMapper mapper)
        {
            _logger = logger;
            _masterTableService = masterTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _masterTableService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _masterTableService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(BasicMaster model)
        {
            _masterTableService.Create(model);
            return Ok(new { message = "Data created into basic master table." });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BasicMaster model)
        {
            _masterTableService.Update(id, model);
            return Ok(new { message = "Data updated into basic master table." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _masterTableService.Delete(id);
            return Ok(new { message = "Basic master data deleted" });
        }
    }
}
