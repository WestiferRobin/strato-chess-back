using Microsoft.AspNetCore.Mvc;

namespace StratoChess {

    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTestName()
        {
            return Ok(new TestName("Wes", "Lambda"));
        }
    }

}
