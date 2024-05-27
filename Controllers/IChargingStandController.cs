using charging_stand_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace charging_stand_api.Controllers
{
    public interface IChargingStandController
    {
        public Task<ActionResult> CreateChargingStand();
        public Task<ActionResult<ChargingStand>> VerifyChargingStand();
        public Task<ActionResult> BlockChargingStand();
    }
}
