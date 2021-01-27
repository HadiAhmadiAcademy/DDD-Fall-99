using System;
using Microsoft.AspNetCore.Mvc;
using Scoring.Application.Contracts.Rules;

namespace Scoring.Gateways.RestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        private readonly IRulesService _rulesService;
        public RulesController(IRulesService rulesService)
        {
            _rulesService = rulesService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]DefineRuleCommand command)
        {
            _rulesService.DefineRule(command);
            return Ok();
        }
    }
}
