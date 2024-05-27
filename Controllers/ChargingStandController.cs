using charging_stand_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace charging_stand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargingStandController : ControllerBase, IChargingStandController
    {

        [HttpPatch(Name="Block")]
        public Task<ActionResult> BlockChargingStand()
        {
            throw new NotImplementedException();
        }

        [HttpPost(Name = "Create")]
        public Task<ActionResult> CreateChargingStand()
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "GetVerification")]
        public Task<ActionResult<ChargingStand>> VerifyChargingStand()
        {
            throw new NotImplementedException();
        }
    }
}
