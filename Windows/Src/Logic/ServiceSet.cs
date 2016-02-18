using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace App2Service.Logic
{
    /// <summary>
    /// A Defined Service
    /// </summary>
    [XmlRoot("Service")]
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

        /// <summary>
        /// Attempt to close the process when the service stop
        /// </summary>
        public bool StopWithService { get; set; }

        /// <summary>
        /// Try to redirect the standard output
        /// </summary>
        public bool RedirectStandardOutput { get; set; }
    }
}
