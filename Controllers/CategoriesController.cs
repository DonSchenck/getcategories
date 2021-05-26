using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace getcategories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            // TODO Get connection string from Environment Variable
            string connectionString = Environment.GetEnvironmentVariable("DBConnectionString");
            //connectionString = "Server=tcp:netcandystore.database.windows.net,1433;Initial Catalog=CandiesDB;Persist Security Info=False;User ID=<userid>;Password=<dbpassword>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            Console.WriteLine(connectionString);
            SqlConnection conn = new SqlConnection(connectionString);

            // TODO Get categories from database
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT id, displayName FROM ProductCategories ORDER BY displayName;", conn);
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            List<Category> c = new List<Category>();
            while (r.Read())
            {
                c.Add(new Category{
                    Id = Convert.ToInt32(r[0]),
                    displayName = r[1].ToString()
                });
            }
            // TODO Return List
            return c;
        }
    }
}
