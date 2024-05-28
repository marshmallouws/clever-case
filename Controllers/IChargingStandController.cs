using charging_stand_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace charging_stand_api.Controllers
{
    public interface IChargingStandController
    {
        public Task<ActionResult<ChargingStand>> CreateChargingStand(string id);
        public Task<ActionResult<ChargingStand>> VerifyChargingStand(string id);
        public Task<ActionResult<ChargingStand>> BlockChargingStand(string id);
    }
}
