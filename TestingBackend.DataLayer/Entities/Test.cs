using System.ComponentModel.DataAnnotations;

namespace TestingBackend.DataLayer.Entities
{
    public class Test : BaseEntity
    {
        /// <summary>
        /// bla
        /// </summary>
        [Required]
        public string OrderId { get; set; } = null!;

        /// <summary>
        /// Tbla
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Tbla
        /// </summary>
        [Required]
        public double Rate { get; set; }

        public double? Quantity { get; set; }
        public string? CustomerNumber { get; set; }

        public int? QuantityTravelAllowance { get; set; }

        public double? RateTravelAllowance { get; set; }

    }
}
