using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csdotnet.Models
{
    /// <summary>
    /// Settings: Configuration Server 
    /// </summary>
    public class ConfigurationServerSettings
    {
        /// <summary>
        /// UAA Server Endpoint
        /// </summary>
        public string Access_Token_Uri { get; set; }
        /// <summary>
        /// Client Id (username)
        /// </summary>
        public string Client_Id { get; set; }
        /// <summary>
        /// Client Secret (password)
        /// </summary>
        public string Client_Secret { get; set; }
        /// <summary>
        /// Configuration Server Endpoint
        /// </summary>
        public string Configuration_Server_Url { get; set; }
        /// <summary>
        /// Security Token (Bearer)
        /// </summary>
        public string SecurityToken { get; set; }

        /// <summary>
        /// Is config from local file (true) or from the environment (false)
        /// </summary>
        public bool IsLocal { get; set; }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns>Debugging Text</returns>
        public override string ToString()
        {
            return string.Format("Uaa: {0} as {1}, CS: {2}, Local: {3}", this.Access_Token_Uri, this.Client_Id, this.Configuration_Server_Url, this.IsLocal);
        }
    }
}
