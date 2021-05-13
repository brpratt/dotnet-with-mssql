using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using App.Repositories;

namespace App.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public HealthController(
            ILogger<HealthController> logger,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _logger = logger;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        [HttpGet("/health")]
        public async Task<IActionResult> Get()
        {
            var canConnect = await CanConnectToDb();

            return Ok(
                new Dictionary<string, string>
                {
                    { "db", canConnect ? "ok" : "error" }
                });
        }

        private async Task<bool> CanConnectToDb()
        {
            try
            {
                using var connection = _sqlConnectionFactory.GetConnection();

                var query = "SELECT 1";
                var cmd = new SqlCommand(query, connection);

                await cmd.ExecuteScalarAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not connect to database");
                return false;
            }

            return true;
        }
    }
}
