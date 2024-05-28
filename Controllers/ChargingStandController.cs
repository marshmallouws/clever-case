using charging_stand_api.Db;
using charging_stand_api.Exceptions;
using charging_stand_api.Logic;
using charging_stand_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace charging_stand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargingStandController : ControllerBase, IChargingStandController
    {
        private readonly ChargingStandService service;

        public ChargingStandController(ChargingStandContext context)
        {
            service = new ChargingStandService(context);
        }


        /// <summary>
        /// Creates a new charging post with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200 if the charging post is created</returns>
        [HttpPost(Name = "Create")]
        public async Task<ActionResult> CreateChargingStand(string id)
        {
            try
            {
                var res = await service.CreateChargingPost(id);
                return Ok(res);
            } catch
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Blocks the charging stand with the given id if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200 returns object if the charging stand has been blocked, 404 if the id does not exist</returns>
        [HttpPatch(Name="Block")]
        public async Task<ActionResult<ChargingStand>> BlockChargingStand(string id)
        {
            try
            {
                var res = await service.BlockChargingPost(id);
                return Ok(res);
            } 
            catch (ChargingStandNotFoundException e)
            {
                return NotFound();
            }
            
        }


        /// <summary>
        /// Checks if a charging post exists with the given id and whether or not it can be used for charging.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200 returns object that verifies that the charging stand exists and whether or not it can be used for charging. 404 if the charging stand does not exist</returns>
        [HttpGet(Name = "GetVerification")]
        public async Task<ActionResult<ChargingStand>> VerifyChargingStand(string id)
        {
            try
            {
                var res = await service.VerifyChargingPost(id);
                return Ok(res);
            }
            catch (ChargingStandNotFoundException e)
            {
                return NotFound(e);
            }
        }
    }
}
