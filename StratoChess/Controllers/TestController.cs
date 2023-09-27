using Microsoft.AspNetCore.Mvc;

namespace StratoChess {

    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTestName()
        {
            var testName = new TestName("Mr Lambda");
            return Ok(testName);
        }
    }

}
