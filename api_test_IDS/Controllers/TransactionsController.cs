using Microsoft.AspNetCore.Mvc;
using Dapper;
using Npgsql;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class dataController : ControllerBase
{
    private readonly IConfiguration _config;

    public dataController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var response = new ApiResponse();
        try
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var transactionsSql = "SELECT id, productID, productName, amount::text, customerName, status, transactionDate, createBy, createOn FROM data";
                var transactions = await connection.QueryAsync<dataTransaction>(transactionsSql);
                response.Data = transactions.AsList();

                var statusSql = "SELECT id, name FROM status";
                var statuses = await connection.QueryAsync<statusInfo>(statusSql);
                response.Status = statuses.AsList();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionByID(int id)
    {
        try
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var getTransactionSQL = "SELECT id, productID, productName, amount::text, customerName, status, transactionDate, createBy, createOn FROM data WHERE id = @Id";
                var transactionById = await connection.QueryFirstOrDefaultAsync<dataTransaction>(getTransactionSQL, new { Id = id });

                if (transactionById == null)
                {
                    return NotFound();
                }
                return Ok(transactionById);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}