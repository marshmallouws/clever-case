using charging_stand_api.Models;

namespace charging_stand_api.Logic
{
    public interface IChargingStandService
    {
        public Task<ChargingStand> CreateChargingPost(string id);
        public Task<ChargingStand> VerifyChargingPost(string id);
        public Task<ChargingStand> BlockChargingPost(string id);
    }
}
