using System.Threading;
using TestServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestServer.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class TestController : ControllerBase {
    [HttpPost("withToken")]
    public IActionResult PostWithToken(TransactionCollection request, CancellationToken token) {
      return Ok(new { IsValid = ModelState.IsValid, MaxErrorsReached = ModelState.HasReachedMaxErrors, Errors = ModelState.ErrorCount });
    }

    [HttpPost("noToken")]
    public IActionResult PostWithoutToken(TransactionCollection request) {
      return Ok(new { IsValid = ModelState.IsValid, MaxErrorsReached = ModelState.HasReachedMaxErrors, Errors = ModelState.ErrorCount });
    }

    [HttpPost("tokenFirst")]
    public IActionResult PostWithTokenFirst(CancellationToken token, TransactionCollection request) {
      return Ok(new { IsValid = ModelState.IsValid, MaxErrorsReached = ModelState.HasReachedMaxErrors, Errors = ModelState.ErrorCount });
    }
  }
}