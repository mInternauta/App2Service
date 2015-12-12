using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2Service.Logic
{
    /// <summary>
    /// A Defined Service
    /// </summary>
    public class ServiceSet 
    {
        /// <summary>
        /// Name of the service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Executable
        /// </summary>
        public string Executable { get; set; }

        /// <summary>
        /// Parameters
        /// </summary>
        public string Parameters { get; set; }
    }
}
