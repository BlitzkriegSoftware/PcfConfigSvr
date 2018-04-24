using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csdotnet.Models
{
    /// <summary>
    /// Configuration Model
    /// </summary>
    public class ConfigurationModel
    {
        /// <summary>
        /// Source
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns>Debugging Info</returns>
        public override string ToString()
        {
            return string.Format("{0}:{1}={2}", this.Source, this.Name, this.Value);
        }
    }
}
