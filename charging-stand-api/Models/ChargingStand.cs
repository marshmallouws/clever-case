using System.ComponentModel.DataAnnotations;

namespace charging_stand_api.Models
{
    public class ChargingStand
    {
        [Key]
        public required string Id { get; set; }
        public bool IsAvailable { get; set; }
    }
}
