using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingBackend.BusinessLayer.Dtos
{
    public class TestDto : BaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerNumber { get; set; } = null!;
    }
}
