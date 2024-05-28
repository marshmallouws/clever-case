using charging_stand_api.Controllers;
using charging_stand_api.Db;
using charging_stand_api.Logic;
using charging_stand_api.Models;
using Moq;
using NuGet.Frameworks;

namespace Test
{
    public class ChargingStandServiceTest
    {
  
        [Fact]
        public async Task Test1Async()
        {
            var dbContextMock = new Mock<ChargingStandContext>();

            var chargingStandServiceMock = new Mock<IChargingStandService>();
            var id = "dk-1111111111-clever";
            chargingStandServiceMock.Setup(p => p.CreateChargingPost(id)).Returns(Task.FromResult(new ChargingStand { Id = id, IsAvailable = true }));


            //var controller = new ChargingStandController();

            //var res = await controller.CreateChargingStand(id);
 
        }
    }
}