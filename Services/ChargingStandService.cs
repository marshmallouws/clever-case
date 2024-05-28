using charging_stand_api.Db;
using charging_stand_api.Exceptions;
using charging_stand_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace charging_stand_api.Logic
{

    public class ChargingStandService : IChargingStandService
    {
        private readonly ChargingStandContext DbContext;

        public ChargingStandService(ChargingStandContext dbContext)
        {
            DbContext = dbContext;
        }


        /// <summary>
        /// Create chargin post entry.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The newly created entity</returns>
        public async Task<ChargingStand> CreateChargingPost(string id)
        {
            Regex rg = new Regex(@"(d|D)(k|K)\-[0-9]{10}\-clever");
            if(rg.IsMatch(id))
            {
                var res = DbContext.Add(new ChargingStand { Id = id, IsAvailable = true });
                await DbContext.SaveChangesAsync();
                return res.Entity;
            }
            throw new Exception("Id " + id + " does not match expected standard");
        }

        /// <summary>
        /// Verify that existing charging post can be used for charging.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if the charging post can be used for charing, else it returns false.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ChargingStand> VerifyChargingPost(string id)
        {
            var res = await DbContext.ChargingStand.FirstOrDefaultAsync(x => x.Id.ToLower().Equals(id.ToLower()));
            if(res != null)
            {
                return res;
            } else
            {
                throw new ChargingStandNotFoundException("id: " + id);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws exception if</exception>
        public async Task<ChargingStand> BlockChargingPost(string id)
        {

            var c = await DbContext.ChargingStand.FirstOrDefaultAsync(x => x.Id.ToLower().Equals(id.ToLower()));
            if (c != null)
            {
                c.IsAvailable = false;
                await DbContext.SaveChangesAsync();
                return c;
            } else
            {
                throw new ChargingStandNotFoundException("id: " + id);
            }

        }
    }
}
