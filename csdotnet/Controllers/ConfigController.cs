using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace csdotnet.Controllers
{
    /// <summary>
    /// Demo of using Configuration Server
    /// </summary>
    [Produces("application/json")]
    [Route("api/Config")]
    public class ConfigController : Controller
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="env">IHostingEnvironment</param>
        /// <param name="logger">ILogger</param>
        public ConfigController(IHostingEnvironment env, ILogger<ConfigController> logger)
        {
            _env = env;
            _logger = logger;
        }

        Lib.ConfigHelper _config = null;
        private IHostingEnvironment _env;
        private readonly ILogger _logger;

        private Lib.ConfigHelper Config
        {
            get {
                if(_config == null)
                {
                    var webRoot = _env.WebRootPath;
                    if (!string.IsNullOrWhiteSpace(webRoot)) webRoot = new DirectoryInfo(webRoot).Parent.FullName;
                    else webRoot = Directory.GetCurrentDirectory();

                    _logger.LogTrace("WebRoot: {0}", webRoot);

                    _config = new Lib.ConfigHelper(webRoot);
                }
                return _config;
            }
        }

        /// <summary>
        /// Gets the configuration for this app from the Configuration Server
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<Models.ConfigurationModel> ConfigGet()
        {
            IEnumerable<Models.ConfigurationModel> config = null;
            try
            {
                config = Config.Get();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "ConfigGet()");
                throw;
            }
            return config;
        }

        /// <summary>
        /// Get a configuration by name
        /// </summary>
        /// <param name="name">Name of configuration</param>
        /// <returns>ConfigurationModel</returns>
        [HttpGet]
        [Route("Name")]
        public Models.ConfigurationModel ConfigGetByName(string name)
        {
            Models.ConfigurationModel m = null;

            try
            {
                m = Config.Get().Where(p => p.Name == name).Select(s => new Models.ConfigurationModel()
                {
                    Source = s.Source,
                    Name = s.Name,
                    Value = s.Value
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ConfigGetByName({0})", name);
                throw;
            }

            return m;
        }

        /// <summary>
        /// Get by Source
        /// </summary>
        /// <param name="source">Contains</param>
        /// <returns>List of matching configuration</returns>
        [HttpGet]
        [Route("Source")]
        public IEnumerable<Models.ConfigurationModel> ConfigGetBySource(string source)
        {
            IEnumerable<Models.ConfigurationModel> m = null;

            try
            {
                m = Config.Get().Where(p => p.Source.Contains(source)).Select(s => new Models.ConfigurationModel()
                {
                    Source = s.Source,
                    Name = s.Name,
                    Value = s.Value
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ConfigGetBySource({0})", source);
                throw;
            }
            return m;
        }

    }
}