using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingBackend.DataLayer.Entities
{
    /// <summary>
    /// Describes a <see cref="BaseEntity"/>
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// The unique key of the <see cref="BaseEntity"/>
        /// </summary>
        public Guid Id { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime ModifiedOn { get; set; }
    }
}